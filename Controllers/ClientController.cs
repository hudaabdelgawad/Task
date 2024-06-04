using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Models;
using Task.Services;

namespace Task.Controllers
{
   // [SessionCheck]
    public class ClientController : BaseController
    {
        // GET: Client
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        public ActionResult Index()
        {
            var item = _clientService.GetAll();
            return View(item);
        }
        public ActionResult Details(int id)
        {
            var item = _clientService.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.Create(client);
                TempData["AlertMessage"] = Resource.Resource.ClientCreated;
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public ActionResult Edit(int id)
        {
            var item = _clientService.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.Update(client);
                TempData["AlertMessage"] = Resource.Resource.ClientUpdated;
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public ActionResult Delete(int id)
        {
            _clientService.Delete(id);
            TempData["AlertMessage"] = Resource.Resource.ClientDeleted;
            return RedirectToAction("Index");
        }
    }
}