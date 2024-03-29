﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstarct;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class MarkaController : Controller
    {
        private readonly IService<Marka> _service;
        public MarkaController(IService<Marka> service)
        {
            _service = service;
        }
        // GET: MarkaController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: MarkaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarkaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarkaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Marka marka)
        {
            try
            {
                await _service.AddAsync(marka);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata olustu.");
            }
            return View(marka);
        }

        // GET: MarkaController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model=await _service.FinAsync(id);
            return View(model);
        }

        // POST: MarkaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Marka marka)
        {
            try
            {
                _service.Update(marka);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MarkaController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FinAsync(id);
            return View(model);
        }

        // POST: MarkaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Marka marka)
        {
            try
            {
                _service.Delete(marka);
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
