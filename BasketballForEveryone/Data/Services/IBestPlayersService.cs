using BasketballForEveryone.Data.Base;
using BasketballForEveryone.Data.ViewModels;
using BasketballForEveryone.Models;

namespace BasketballForEveryone.Data.Services
{
    public interface IBestPlayersService:IEntityBaseRepository<BestPlayer>
    {
        Task<BestPlayer> GetBestPlayersByIdAsync(int id );
        Task<NewBestPlayerDropdownsVM> GetNewBestPlayerDropdownsValues();

        Task AddNewBestPlayerAsync(NewBestPlayerVM data);

        Task UpdateBestPlayerAsync(NewBestPlayerVM data);
    }
}
