using BasketballForEveryone.Data;
using BasketballForEveryone.Data.Services;
using BasketballForEveryone.Data.Static;
using BasketballForEveryone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BasketballForEveryone.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BestPlayersController : Controller
    {
        private readonly IBestPlayersService _service;

        public BestPlayersController(IBestPlayersService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBestPlayers = await _service.GetAllAsync(n => n.Team);
            return View(allBestPlayers);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBestPlayers = await _service.GetAllAsync(n => n.Team);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allBestPlayers.Where(n => n.Name.Contains(searchString) || n.Description.Contains
                // (searchString)).ToList();
                var filteredResultNew = allBestPlayers.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filteredResultNew);
            }

            return View("Index",allBestPlayers);
        }

        //Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var bestPlayersDetails = await _service.GetBestPlayersByIdAsync(id);
            return View(bestPlayersDetails);
        }

        //Create

        public async Task<IActionResult> Create()
        {
            var bestPlayersDropdownsData = await _service.GetNewBestPlayerDropdownsValues();

            ViewBag.Teams = new SelectList(bestPlayersDropdownsData.Teams, "Id", "Name");
            ViewBag.Coaches = new SelectList(bestPlayersDropdownsData.Coaches, "Id", "FullName");
            ViewBag.BPlayers = new SelectList(bestPlayersDropdownsData.BPlayers, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewBestPlayerVM bestPlayer)
        {
            if (!ModelState.IsValid)
            {
                var bestPlayersDropdownsData = await _service.GetNewBestPlayerDropdownsValues();

                ViewBag.Teams = new SelectList(bestPlayersDropdownsData.Teams, "Id", "Name");
                ViewBag.Coaches = new SelectList(bestPlayersDropdownsData.Coaches, "Id", "FullName");
                ViewBag.BPlayers = new SelectList(bestPlayersDropdownsData.BPlayers, "Id", "FullName");

                return View(bestPlayer);
            }
            await _service.AddNewBestPlayerAsync(bestPlayer);
            return RedirectToAction(nameof(Index));
        }

        //Edit

        public async Task<IActionResult> Edit(int id)
        {
            var bestPlayersDetails = await _service.GetBestPlayersByIdAsync(id);
            if (bestPlayersDetails == null) return View("NotFound");

            var response = new NewBestPlayerVM()
            {
                Id = bestPlayersDetails.Id,
                Name = bestPlayersDetails.Name,
                Description = bestPlayersDetails.Description,
                Points = bestPlayersDetails.Points,
                CareerStart = bestPlayersDetails.CareerStart,
                CareerEnd = bestPlayersDetails.CareerEnd,
                ImageURL = bestPlayersDetails.ImageURL,
                Position = bestPlayersDetails.Position,
                TeamId = bestPlayersDetails.TeamId,
                CoachId = bestPlayersDetails.CoachId,
                BPlayersIds = bestPlayersDetails.BPlayer_BestPlayers.Select(n => n.BPlayerId).ToList(),
            };

            var bestPlayersDropdownsData = await _service.GetNewBestPlayerDropdownsValues();

            ViewBag.Teams = new SelectList(bestPlayersDropdownsData.Teams, "Id", "Name");
            ViewBag.Coaches = new SelectList(bestPlayersDropdownsData.Coaches, "Id", "FullName");
            ViewBag.BPlayers = new SelectList(bestPlayersDropdownsData.BPlayers, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id , NewBestPlayerVM bestPlayer)
        {
            if (id != bestPlayer.Id) return View("NorFound");
            if (!ModelState.IsValid)
            {
                var bestPlayersDropdownsData = await _service.GetNewBestPlayerDropdownsValues();

                ViewBag.Teams = new SelectList(bestPlayersDropdownsData.Teams, "Id", "Name");
                ViewBag.Coaches = new SelectList(bestPlayersDropdownsData.Coaches, "Id", "FullName");
                ViewBag.BPlayers = new SelectList(bestPlayersDropdownsData.BPlayers, "Id", "FullName");

                return View(bestPlayer);
            }
            await _service.UpdateBestPlayerAsync(bestPlayer);
            return RedirectToAction(nameof(Index));
        }
    }
}
