using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstarct;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class ServisController : Controller
    {
        private readonly IService<Servis> _service;
        public ServisController(IService<Servis> service)
        {
            _service = service;
        }

        // GET: ServisController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: ServisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServisController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ServisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Servis servis)
        {
            try
            {   await _service.AddAsync(servis);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServisController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FinAsync(id);
            return View(model);
        }

        // POST: ServisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Servis servis)
        {
            try
            {
                _service.Update(servis);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServisController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model=await _service.FinAsync(id);
            return View(model);
        }

        // POST: ServisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Servis servis)
        {
            try
            {
                _service.Delete(servis);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
