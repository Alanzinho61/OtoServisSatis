using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstarct;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullaniciController : Controller
    {
        private readonly IService<Kullanici> _service;
        private readonly IService<Rol> _serviceRol;

        public KullaniciController(IService<Kullanici> service, IService<Rol> serviceRol)
        {
            _service = service;
            _serviceRol = serviceRol;
        }

        // GET: KullaniciController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: KullaniciController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KullaniciController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.RolId=new SelectList(await _serviceRol.GetAllAsync(), "Id","Adi");
            return View();
        }

        // POST: KullaniciController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Kullanici kullanici)
        {
            if (true)
            {
                try
                {
                    await _service.AddAsync(kullanici);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Olustu");
                }
                ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Adi");
                return View(kullanici);
            }
            
        }

        // GET: KullaniciController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FinAsync(id);
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsync(), "Id", "Adi");
            
            return View(model);
        }

        // POST: KullaniciController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Kullanici kullanici)
        {
            try
            {
                _service.Update(kullanici);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KullaniciController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FinAsync (id);
            return View(model);
        }

        // POST: KullaniciController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Kullanici kullanici)
        {
            try
            {
                _service.Delete(kullanici);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult deneme() 
        {
            ViewBag.Message = "ddffsffsd";
            return View();
        
        }
    }
}
