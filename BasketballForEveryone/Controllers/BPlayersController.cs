using BasketballForEveryone.Data;
using BasketballForEveryone.Data.Services;
using BasketballForEveryone.Data.Static;
using BasketballForEveryone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasketballForEveryone.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BPlayersController : Controller
    {
        private readonly IBPlayersService _service;

        public BPlayersController(IBPlayersService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        
        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]BPlayer player)
        {
            if(!ModelState.IsValid)
            {
                return View(player);
            }
           await _service.AddAsync(player);
            
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var playerDetails = await _service.GetByIdAsync(id);

            if (playerDetails == null) return View("NotFound");
            return View(playerDetails); 
        }
        public  async Task<IActionResult> Edit(int id)
        {
            var playerDetails = await _service.GetByIdAsync(id);

            if (playerDetails == null) return View("NotFound");
            return View(playerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,[Bind("Id,FullName,ProfilePictureURL,Bio")] BPlayer player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }
            await _service.UpdateAsync(id,player);
            
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var playerDetails = await _service.GetByIdAsync(id);
            if (playerDetails == null) return View("NotFound");
            return View(playerDetails);
        }

        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerDetails = await _service.GetByIdAsync(id);
            if (playerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

