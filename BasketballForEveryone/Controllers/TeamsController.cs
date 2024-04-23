using BasketballForEveryone.Data;
using BasketballForEveryone.Data.Services;
using BasketballForEveryone.Data.Static;
using BasketballForEveryone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketballForEveryone.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class TeamsController : Controller
    {
        private readonly ITeamsService _service;

        public TeamsController(ITeamsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allTeams = await _service.GetAllAsync();
            return View(allTeams);
        }
        

        //Create
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Team team)
        {
            if (!ModelState.IsValid) return View(team);
            await _service.AddAsync(team);
            return RedirectToAction(nameof(Index));
        }
        //Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var teamDetails = await _service.GetByIdAsync(id);
            if(teamDetails == null) return View("NotFound");
            return View(teamDetails);
        }

        //Edit 
        public async Task<IActionResult> Edit(int id)
        {
            var teamDetails = await _service.GetByIdAsync(id);
            if (teamDetails == null) return View("NotFound");
            return View(teamDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id , [Bind("Id,Logo,Name,Description")] Team team)
        {
            if (!ModelState.IsValid) return View(team);
            await _service.UpdateAsync(id,team);
            return RedirectToAction(nameof(Index));
        }
        //Delete 
        public async Task<IActionResult> Delete(int id)
        {
            var teamDetails = await _service.GetByIdAsync(id);
            if (teamDetails == null) return View("NotFound");
            return View(teamDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var teamDetails = await _service.GetByIdAsync(id);
            if (teamDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
