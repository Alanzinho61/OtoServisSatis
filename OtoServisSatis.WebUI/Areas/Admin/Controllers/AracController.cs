using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstarct;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AracController : Controller
    {
        private readonly IService<Arac> _service;
        private readonly IService<Marka> _serviceMarka;
        public AracController (IService<Arac> service, IService<Marka> serviceMarka)
        {
            _service = service;
            _serviceMarka = serviceMarka;
        }
        // GET: AracController
        public async Task<ActionResult> IndexAsync()
        {
            var model= await _service.GetAllAsync();
            return View(model);
        }

        // GET: AracController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AracController/Create
        public async Task<ActionResult> CreateAsync()
        {
            
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View();
        }

        // POST: AracController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Arac arac)
        {
            try
            {
                await _service.AddAsync(arac);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                ModelState.AddModelError("", "Hata olustu");

            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        await _service.AddAsync(arac);
            //        await _service.SaveAsync();
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {

            //        ModelState.AddModelError("", "Hata olustu");

            //    }

            //}
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
           return View(arac);
            
        }

        // GET: AracController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model =await _service.FinAsync(id);
            return View(model);
        }

        // POST: AracController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id,Arac arac)
        {
            try
            {
                _service.Update(arac);
                await _service.SaveAsync();
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: AracController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FinAsync(id);
            return View(model);
        }

        // POST: AracController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Arac arac)
        {
            try
            {
                _service.Delete(arac);
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
