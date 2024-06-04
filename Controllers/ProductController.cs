using System.Web.Mvc;
using Task.Models;
using Task.Services;
using Task.ViewModels;

namespace Task.Controllers
{
  //  [SessionCheck]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public IItemService _itemService { get; }

        public ProductController(IProductService productService,IItemService itemService)
        {
            _productService = productService;
            _itemService = itemService;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                items = _itemService.GetAll()
            };

            return View("Create", viewModel);
        }
        //edit

        public ActionResult Edit(int id)
        {
           
            var product = _productService.GetById(id);

            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ItemId = product.ItemId,

                items = _itemService.GetAll()
            };

            return View("Create", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.items = _itemService.GetAll();
                return View("Create", model);
            }
            //create product
            if (model.Id == 0)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    ItemId = model.ItemId,
                   
                };

                _productService.Create(product);
                TempData["AlertMessage"] = Resource.Resource.ItemCreated;
               
            }

            else
            {
                var product = _productService.GetById(model.Id);

                if (product == null)
                    return HttpNotFound();

                product.Name = model.Name;
                product.Price = model.Price;
                product.ItemId = model.ItemId;
                _productService.Update(product);
                TempData["AlertMessage"] = Resource.Resource.ItemUpdated;


            }




            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _productService.Delete(id);
            TempData["AlertMessage"] = Resource.Resource.ItemDeleted;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int productId)
        {
            _productService.GetById(productId);
           
            return RedirectToAction("Index");
        }
    }








}