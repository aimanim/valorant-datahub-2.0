using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Agent_And_Abilities
    {
        [NotMapped]
        public agents agent {  get; set; }
        [NotMapped]
        public AgentAbilities abilities { get; set; }
    }
}
