namespace WebApplication1.Models
{
    public class GenericModel
    {
        public List<agents> agents { get; set; }
        public List<solo_Matches> solo_Matches { get; set; }
        public string optionClicked { get; set; }
        public List<Weaponary> Weaponary { get; set; }
        public List<Maps> Maps { get; set; }
        public List<Player> Player{ get; set; }
        public List<Location> Location { get; set; }
    }
}
