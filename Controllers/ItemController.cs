using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using Task.Models;
using Task.Services;
using Task.ViewModels;

namespace Task.Controllers
{
   // [SessionCheck]
    public class ItemController : BaseController
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        public ActionResult Index()
        {
            var item = _itemService.GetAll();
            return View(item);
        }
        public ActionResult Details(int id)
        {
            var item = _itemService.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        public ActionResult Create()
        {
            var viewModel = new ItemViewModel();
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var item = _itemService.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            var viewModel = new ItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                

                
            };
            return View("Create", viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
              
                return View("Create", model);
            }
            //create product
            if (model.Id == 0)
            {
                var item = new Item
                {
                    Name = model.Name,
                 

                };

                _itemService.Create(item);
                TempData["AlertMessage"] = Resource.Resource.ProductCreated;
               
            }

            else
            {
                var item = _itemService.GetById(model.Id);

                if (item == null)
                    return HttpNotFound();

                item.Name = model.Name;
               
                _itemService.Update(item);
                TempData["AlertMessage"] = Resource.Resource.ProductUpdated;


            }




            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _itemService.Delete(id);
            TempData["AlertMessage"] = Resource.Resource.ProductDeleted;
            return RedirectToAction("Index");
        }
    }
}