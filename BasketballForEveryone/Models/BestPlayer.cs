using BasketballForEveryone.Data.Base;
using BasketballForEveryone.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketballForEveryone.Models
{
    public class BestPlayer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Points { get; set; }
        public string? ImageURL { get; set; }
        public DateTime CareerStart { get; set; }
        public DateTime CareerEnd { get; set; }
        public Position Position { get; set; }

        //Relationships 
        public List<BPlayer_BestPlayer>? BPlayer_BestPlayers { get; set; }

        //Team
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team?  Team { get; set; }

        //Team
        public int CoachId { get; set; }
        [ForeignKey("CoachId")]
        public Coach? Coach { get; set; }
    }
}
