using BasketballForEveryone.Controllers;
using BasketballForEveryone.Data.Base;
using BasketballForEveryone.Models;

namespace BasketballForEveryone.Data.Services
{
    public class TeamsService:EntityBaseRepository<Team>,ITeamsService
    {
        public TeamsService(AppDbContext context):base(context)
        {
            
        }
    }
}
