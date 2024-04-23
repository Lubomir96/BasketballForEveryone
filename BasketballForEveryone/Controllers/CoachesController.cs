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
    public class CoachesController : Controller
    {
        private readonly ICoachesService _service;

        public CoachesController(ICoachesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allChoaches = await _service.GetAllAsync();
            return View(allChoaches);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var coachDetail = await _service.GetByIdAsync(id);
            if(coachDetail == null) return View("NotFound");
            return View(coachDetail);
     
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Coach coach)
        {
            if (!ModelState.IsValid)
            {
                return View(coach);
            }
            await _service.AddAsync(coach);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var coachDetails = await _service.GetByIdAsync(id);
            if (coachDetails == null) return View("NotFound");
            return View(coachDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id ,[Bind("Id,FullName,ProfilePictureURL,Bio")] Coach coach)
        {
            if (!ModelState.IsValid)
            {
                return View(coach);
            }
            if(id == coach.Id)
            {
                await _service.UpdateAsync(id, coach);
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
          
        }
        public async Task<IActionResult> Delete(int id)
        {
            var coachDetails = await _service.GetByIdAsync(id);
            if (coachDetails == null) return View("NotFound");
            return View(coachDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coachDetails = await _service.GetByIdAsync(id);
            if (coachDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }


}
