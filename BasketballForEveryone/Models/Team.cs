using BasketballForEveryone.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BasketballForEveryone.Models
{
    public class Team:IEntityBase 
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Team Logo")]
        [Required(ErrorMessage = "Logo is requared")]
        public string? Logo { get; set; }
        [Display(Name = "Team Name")]
        [Required(ErrorMessage = "Name is requared")]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Discriptio is requared")]
        public string? Description { get; set; }

        //Relationships 
        public List<BestPlayer>? BestPlayers { get; set; }
    }
}
