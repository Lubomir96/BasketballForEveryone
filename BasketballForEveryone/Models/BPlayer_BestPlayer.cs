using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketballForEveryone.Models
{
    public class BPlayer_BestPlayer
    {
        [Key]
        public int Id { get; set; }
        public int BestPlayerId { get; set; }
        [ForeignKey("BestPlayerId")]
        public BestPlayer? BestPlayer { get; set; }
        public int BPlayerId { get; set; }
        [ForeignKey("BPlayerId")]
        public BPlayer? BPlayer { get; set; }
    }
}
