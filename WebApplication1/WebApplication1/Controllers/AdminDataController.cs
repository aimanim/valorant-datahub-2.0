using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection;
using WebApplication1.Data;
using WebApplication1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
	public class AdminDataController : Controller
    {
        private readonly ApplicationDbContext _db;
		private List<string> headers;
        public AdminDataController(ApplicationDbContext db)
        {
            _db = db;
			headers = new List<string>();
			
		}
        public IActionResult Index(string option)
        {
			if(option == "soloMatches")
			{
				option = "solo_Matches";
			}
            Console.WriteLine("Option passed to index: " + option);
            HttpContext.Session.SetString("TransactionState", "InActive");
			var ViewModel = new GenericModel();
            ViewModel.optionClicked = option;
            switch (option)
            {
				//keep the name same as table name
                case "agents":
                    ViewModel.agents = _db.Agents.ToList();
					HttpContext.Session.SetString("PrimaryAttribute", "agent_name");
                    break;
                case "solo_Matches":
                    ViewModel.solo_Matches = _db.solomatches.ToList();
					HttpContext.Session.SetString("PrimaryAttribute", "Match_ID");
					break;
                case "Weaponary":
                    ViewModel.Weaponary = _db.weapons.ToList();
					HttpContext.Session.SetString("PrimaryAttribute", "Weapon_Name");
					break;
                case "Maps":
					ViewModel.Maps = _db.maps.ToList();
					HttpContext.Session.SetString("PrimaryAttribute", "Map_Name");
					break;
                case "Player":
					ViewModel.Player = _db.players.ToList();
					HttpContext.Session.SetString("PrimaryAttribute", "Pid");
					break;
				case "Location":
					ViewModel.Location = _db.locations.ToList();
					HttpContext.Session.SetString("PrimaryAttribute", "Location_id");
					break;
			}
            return View(ViewModel);
        }
		[HttpPost]
        public IActionResult Insert(List<string> data, string tempVar)	//keep the variable names same as the one's sent using AJAX query
        {
			string? transactionState = HttpContext.Session.GetString("TransactionState");
			if (transactionState == "Active")
				return BadRequest("Please commit your previous transaction first");
			string query = $"insert into {tempVar} values (";
			if (tempVar == "agents")
			{
				for (int i = 0; i < data.Count-2; i++)
				{
					query += $"'{data[i]}'";
					if (i < data.Count - 1)
					{
						query += ",";
					}
				}
				query += $"'{data[data.Count-1]}'";
				query += ",";
				query += $"'{data[data.Count-2]}')";
				
			}
			else
			{
				for (int i = 0; i < data.Count; i++)
				{
					query += $"'{data[i]}'";
					if (i < data.Count - 1)
					{
						query += ",";
					}
				}
				query += ")";
			}
				
            Console.WriteLine("The query: " + query);
			
			try
            {
				_db.Database.ExecuteSqlRaw(query);
				string temp = HttpContext.Session.GetString("PrimaryAttribute");
				HttpContext.Session.SetString("TransactionState", "Active");
				HttpContext.Session.SetString("LastPK", $"{data[0]}");
				HttpContext.Session.SetString("CurrentTable", $"{tempVar}");
				query = $"delete from {tempVar} where {temp} = '{data[0]}'";
				_db.Database.ExecuteSqlRaw(query);
				return Ok("Success");
			}
            catch(Exception ex)
            {
				return BadRequest(ex.Message);
            }
			
        }
		
		private List<string> GetAttributes(string tempVar)
		{
			List<string> attributes = new List<string>();
			Type? type = Type.GetType("WebApplication1.Models." + tempVar);
			if (type != null)
			{
				PropertyInfo[] properties = type.GetProperties();
				foreach( PropertyInfo property in properties)
				{
					attributes.Add(property.Name);
				}
			}
			return attributes;
		}
		private Tuple<object,int> GetValidationCount(string tempVar,List<string> data)
		{
			Tuple<object, int> res = new Tuple<object, int>(null, -1);
			int a = -1;
			object b = null;
			switch (tempVar)
			{
				case "solo_Matches":
					a = _db.solomatches.Count(m => m.Match_ID == int.Parse(data[0]));
					b = _db.solomatches.FirstOrDefault(m => m.Match_ID == int.Parse(data[0]));
					break;

				case "agents":
					a = _db.Agents.Count(m => m.agent_name == data[0]);
					b = _db.Agents.FirstOrDefault(m => m.agent_name == data[0]);
					break;
				case "Player":
					a = _db.players.Count(m => m.Pid == int.Parse(data[0]));
					b = _db.players.FirstOrDefault(m => m.Pid == int.Parse(data[0]));
					break;
				case "Weaponary":
					a= _db.weapons.Count(a => a.Weapon_Name == data[0]);
					b= _db.weapons.FirstOrDefault(a => a.Weapon_Name == data[0]);
					break;
				case "Location":
					a = _db.locations.Count(l => l.Location_id == int.Parse(data[0]));
					b = _db.locations.FirstOrDefault(l => l.Location_id == int.Parse(data[0]));
					break;
				case "Maps":
					a = _db.maps.Count(m => m.Map_Name == data[0]);
					b = _db.maps.FirstOrDefault(m => m.Map_Name == data[0]);
					break;
			}
			res = new Tuple<object, int>(b, a);
			return res; 
		}
		[HttpPost]
		public IActionResult Update(List<string> data, string tempVar)
		{
			string transactionState = HttpContext.Session.GetString("TransactionState");
			if (transactionState == "Active")
				return BadRequest("Please commit your previous transaction first");
			List<string> attributes = GetAttributes(tempVar);
			Tuple<object, int> hehe = GetValidationCount(tempVar, data);
			object validate = hehe.Item1;
			if (hehe.Item2 != 1)
				return BadRequest($"ERROR! Invalid attempt to change the primary key. Please refrain from modifying the primary key ({attributes[0]}. Please change back '{data[0]}'");
            string query = $"update {tempVar} set ";
			for(int i=1;i<data.Count;i++){
				string value = data[i];
				query += $"{attributes[i]} = '{value}',";
			}
			query = query.Substring(0, query.Length - 1);
			query += $" where {attributes[0]} = '{data[0]}'";
            Console.WriteLine(query);
			try
			{
				_db.Database.ExecuteSqlRaw(query);
				HttpContext.Session.SetString("CurrentTable", $"{tempVar}");
				HttpContext.Session.SetString("TransactionState", "Active");
				query = $"update {tempVar} set ";
				Type type = Type.GetType("WebApplication1.Models." + tempVar);
				for (int i=1;i<data.Count;i++)
				{
					PropertyInfo property = type.GetProperty(attributes[i]);
					query += $"{attributes[i]} = '{property.GetValue(validate)}',";
				}
				query = query.Substring(0, query.Length - 1);
				query += $" where {attributes[0]} = '{data[0]}'";
				_db.Database.ExecuteSqlRaw(query);
				return Ok("Press commit to see your changes");
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
				
			}
		}
		[HttpPost]
		public IActionResult Delete(string pk,string tempVar)
		{
			string? transactionState = HttpContext.Session.GetString("TransactionState");
			if (transactionState != null && transactionState == "Active")
				return BadRequest("Please commit your previous transaction first");
			HttpContext.Session.SetString("PrimaryAttributeValue", $"{pk}");
			Console.WriteLine("Primary key attribute, primary key: " + HttpContext.Session.GetString("PrimaryAttribute") + "," + pk);
			HttpContext.Session.SetString("TransactionState", "Active");
			HttpContext.Session.SetString("CurrentTable", $"{tempVar}");

			return Ok("Press Commit to view your changes");
		}
		private string GenerateQuery(string option,string tempVar,List<string> data)
		{
			string query = "";
			switch (option)
			{
				case "insert":
					query = $"insert into {tempVar} values (";
					if (tempVar == "agents")
					{
						for (int i = 0; i < data.Count - 2; i++)
						{
							query += $"'{data[i]}'";
							if (i < data.Count - 1)
							{
								query += ",";
							}
						}
						query += $"'{data[data.Count - 1]}'";
						query += ",";
						query += $"'{data[data.Count - 2]}')";

					}
					else
					{
						for (int i = 0; i < data.Count; i++)
						{
							query += $"'{data[i]}'";
							if (i < data.Count - 1)
							{
								query += ",";
							}
						}
						query += ")";
					}
					break;
				case "update":
					query = $"update {tempVar} set ";
					List<string> attributes = GetAttributes(tempVar);
					for (int i = 1; i < data.Count; i++)
					{
						string value = data[i];
						query += $"{attributes[i]} = '{value}',";
					}
					query = query.Substring(0, query.Length - 1);
					query += $" where {attributes[0]} = '{data[0]}'";
					break;
				case "delete":
					string pk_title = HttpContext.Session.GetString("PrimaryAttribute");
					string pk_value = HttpContext.Session.GetString("PrimaryAttributeValue");
					query = $"delete from {tempVar} where {pk_title} = '{pk_value}'";
					break;
			}
			return query;
		}
		[HttpPost]
		public IActionResult CommitTransaction(List<string> data,string btn_last)
		{
			string? transactionState = HttpContext.Session.GetString("TransactionState");
				if (transactionState == null || transactionState == "InActive")
				return BadRequest("No transaction to commit.");
			string tempVar = HttpContext.Session.GetString("CurrentTable");

			string query = GenerateQuery(btn_last,tempVar,data);
			Console.WriteLine(query);
			try
			{
				_db.Database.ExecuteSqlRaw(query);
				HttpContext.Session.SetString("TransactionState", "InActive");
				return Ok("Changes have been saved to database successfully.");

			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public IActionResult RollbackTransaction(List<string> data)
		{
			string? transactionState = HttpContext.Session.GetString("TransactionState");
			if (transactionState == null || transactionState == "InActive")
				return BadRequest("No transaction to Undo.");
			HttpContext.Session.SetString("TransactionState", "InActive");
			return Ok("Changes have been rolled back successfully.");
		}

	}
}
