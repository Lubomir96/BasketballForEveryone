using BasketballForEveryone.Data.Base;
using BasketballForEveryone.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketballForEveryone.Data.Services
{
    public class BPlayersService : EntityBaseRepository<BPlayer>, IBPlayersService
    {
       public BPlayersService(AppDbContext context) : base(context) { }
      
    }
}
