using BasketballForEveryone.Data.Base;
using BasketballForEveryone.Models;

namespace BasketballForEveryone.Data.Services
{
    public class CoachesService: EntityBaseRepository<Coach>, ICoachesService
    {
        public CoachesService(AppDbContext context):base(context) { }
        
    }
}
