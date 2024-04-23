using BasketballForEveryone.Data.Base;
using BasketballForEveryone.Data.ViewModels;
using BasketballForEveryone.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketballForEveryone.Data.Services
{
    public class BestPlayersService : EntityBaseRepository<BestPlayer>, IBestPlayersService
    {
        private readonly AppDbContext _context;
        public BestPlayersService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBestPlayerAsync(NewBestPlayerVM data)
        {
            var newBestPlayer = new BestPlayer()
            {
                Name = data.Name,
                Description = data.Description,
                Points = data.Points,
                ImageURL = data.ImageURL,
                TeamId = data.TeamId,
                CareerStart = data.CareerStart,
                CareerEnd = data.CareerEnd,
                Position = data.Position,
                CoachId = data.CoachId
            };
            await _context.BestPlayers.AddAsync(newBestPlayer);
            await _context.SaveChangesAsync();

            //Bplayer
            foreach (var bpalyerId in data.BPlayersIds)
            {
                var newBPlayerBestPlayer = new BPlayer_BestPlayer()
                {
                    BestPlayerId = newBestPlayer.Id,
                    BPlayerId = bpalyerId
                };
                await _context.BPlayers_BestPlayers.AddAsync(newBPlayerBestPlayer);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<BestPlayer> GetBestPlayersByIdAsync(int id)
        {
            var bestPlayersDetails = await _context.BestPlayers
                .Include(t => t.Team)
                .Include(c => c.Coach)
                .Include(pbp => pbp.BPlayer_BestPlayers).ThenInclude(p => p.BPlayer)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bestPlayersDetails;
        }

        public async Task<NewBestPlayerDropdownsVM> GetNewBestPlayerDropdownsValues()
        {
            var reponse = new NewBestPlayerDropdownsVM()
            {
                BPlayers = await _context.BPlayers.OrderBy(n => n.FullName).ToListAsync(),
                Teams = await _context.Teams.OrderBy(n => n.Name).ToListAsync(),
                Coaches = await _context.Coaches.OrderBy(n => n.FullName).ToListAsync()
            };
            return reponse;
        }

        public async Task UpdateBestPlayerAsync(NewBestPlayerVM data)
        {
            var dbBestPlayer = await _context.BestPlayers.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbBestPlayer != null)
            {
                dbBestPlayer.Name = data.Name;
                dbBestPlayer.Description = data.Description;
                dbBestPlayer.Points = data.Points;
                dbBestPlayer.ImageURL = data.ImageURL;
                dbBestPlayer.TeamId = data.TeamId;
                dbBestPlayer.CareerStart = data.CareerStart;
                dbBestPlayer.CareerEnd = data.CareerEnd;
                dbBestPlayer.Position = data.Position;
                dbBestPlayer.CoachId = data.CoachId;
                await _context.SaveChangesAsync();
            }
            // Remove existing BPlayers
            var existingBPlayersDb = _context.BPlayers_BestPlayers.Where(n => n.BestPlayerId == data.Id).ToList();
            _context.BPlayers_BestPlayers.RemoveRange(existingBPlayersDb);
            await _context.SaveChangesAsync();
            //Bplayer
            foreach (var bpalyerId in data.BPlayersIds)
            {
                var newBPlayerBestPlayer = new BPlayer_BestPlayer()
                {
                    BestPlayerId = data.Id,
                    BPlayerId = bpalyerId
                };
                await _context.BPlayers_BestPlayers.AddAsync(newBPlayerBestPlayer);
            }
            await _context.SaveChangesAsync();
        }
    }
}
