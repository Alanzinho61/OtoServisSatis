using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstarct;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MusteriController : Controller
    {
        private readonly IService<Musteri> _service;
        private readonly IService<Arac> _serviceArac;

        public MusteriController(IService<Musteri> service, IService<Arac> serviceArac)
        {
            _service = service;
            _serviceArac = serviceArac;
        }
        // GET: MusteriController
        public async Task<ActionResult> IndexAsync()
        {
            
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: MusteriController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusteriController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");//aracin kendisini eklemeye calis
            return View();
        }

        // POST: MusteriController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Musteri musteri)
        {
            try
            {
                ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");
                await _service.AddAsync(musteri);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusteriController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FinAsync(id);
            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");
            return View(model);
        }

        // POST: MusteriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Musteri musteri)
        {
            try
            {
                _service.Update(musteri);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusteriController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model=await _service.FinAsync(id);
            return View(model);
        }

        // POST: MusteriController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Musteri musteri)
        {
            try
            {
                _service.Delete(musteri);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
