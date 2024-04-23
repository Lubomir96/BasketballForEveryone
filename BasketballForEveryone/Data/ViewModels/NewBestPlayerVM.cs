using BasketballForEveryone.Data.Base;
using BasketballForEveryone.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketballForEveryone.Models
{
    public class NewBestPlayerVM
    {
        public int Id { get; set; }

        [Display(Name = "BestPlayer name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "BestPlayer description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Points { get; set; }

        [Display(Name = "BestPlayer image URL")]
        [Required(ErrorMessage = "BestPlayer image URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "BestPlayer start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime CareerStart { get; set; }

        [Display(Name = "BestPlayer end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime CareerEnd { get; set; }

        [Display(Name = "Select a Position")]
        [Required(ErrorMessage = "BestPlayer Position is required")]
        public Position Position { get; set; }

        //Relationships 
        [Display(Name = "Select player(s)")]
        [Required(ErrorMessage = "BestPlayer player(s) is required")]
        public List<int> BPlayersIds { get; set; }

        [Display(Name = "Select a team")]
        [Required(ErrorMessage = "BestPlayer team is required")]
        public int TeamId { get; set; }

        [Display(Name = "Select a coach")]
        [Required(ErrorMessage = "BestPlayer coach is required")]
        public int CoachId { get; set; }
    }
}
