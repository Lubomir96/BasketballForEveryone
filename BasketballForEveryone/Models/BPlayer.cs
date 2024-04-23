using BasketballForEveryone.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BasketballForEveryone.Models
{
    public class BPlayer :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile Picture ")]
        [Required(ErrorMessage ="Profile Picture is requared")]
        public string? ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is requared")]
        [StringLength(50,MinimumLength = 3,ErrorMessage ="<50 >3")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Bio is requared")]
        [Display(Name = "Biography")]
        public string? Bio { get; set; }

        //Relationships 
        public List<BPlayer_BestPlayer>? BPlayer_BestPlayers { get; set; }
    }
}
