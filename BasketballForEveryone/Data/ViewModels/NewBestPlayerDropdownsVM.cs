using BasketballForEveryone.Models;

namespace BasketballForEveryone.Data.ViewModels
{
    public class NewBestPlayerDropdownsVM
    {
        public NewBestPlayerDropdownsVM()
        {
            Coaches = new List<Coach>();
            Teams = new List<Team>();
            BPlayers = new List<BPlayer>();
        }

        public List<Coach> Coaches { get; set; }
        public List<Team> Teams { get; set; }
        public List<BPlayer> BPlayers { get; set; }
    }
}

