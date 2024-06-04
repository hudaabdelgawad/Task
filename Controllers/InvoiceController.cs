using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Task.Models;
using Task.Services;
using Task.ViewModels;

namespace Task.Controllers
{
   // [SessionCheck]
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IClientService _clientService;
        private readonly IItemService _itemService;
        private readonly IProductService _productService;
        private readonly InvoiceDbContext _context;

        public IProductService ProductService { get; }

        public InvoiceController(IInvoiceService invoiceService, IClientService clientService, IItemService itemService, IProductService productService, InvoiceDbContext context)
        {
            _invoiceService = invoiceService;
            _clientService = clientService;
            _itemService = itemService;
            _productService = productService;
            _context = context;
        }
        // GET: Invoice
        public ActionResult Index()
        {
            var result = _invoiceService.GetAll();
            return View(result);
        }


        public JsonResult InvoiceTemp()
        {
            var result = _context.InvoiceTemps.Include(i => i.Product).Include(i => i.Item)

                .ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InvoiceTemp(InvoiceTemp model)
        {
            try
            {
                var result = _context.InvoiceTemps.FirstOrDefault(x => x.ProductId.Equals(model.ProductId) && x.ItemId.Equals(model.ItemId));

                if (result == null)
                {
                    _context.InvoiceTemps.Add(model);


                }
                else
                {
                    result.ProductId = model.ProductId;
                    result.ItemId = model.ItemId;
                    result.Quentit += model.Quentit;
                    result.Discount += model.Discount;
                    result.Total += (model.Price * model.Quentit) - (model.Discount);
                            }
                _context.SaveChanges();
                return Json(new { success = true });


            }



            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }
        [HttpPost]
        public JsonResult deleteInvoiceTemp(int id)
        {
            try
            {
                var result = _context.InvoiceTemps.Find(id);
                if(result != null)
                {
                    _context.InvoiceTemps.Remove(result);
                    _context.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = " not found" });
              
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
           
        }
        [HttpGet]
        public JsonResult GetAllTotal()
        {
            var total = _context.InvoiceTemps.Sum(x => x.Total);
            return Json(total, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult GetProduct(int id)
        {
            return Json(_productService.GetById(id));

        }
        public JsonResult GetProductsByCategory(int categoryId)
        {
            var products = _context.products
                .Where(p => p.ItemId == categoryId)
                .Select(p => new { p.Id, p.Name, p.Price })
                .ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductPice(int productId)
        {
            var products = _context.products.FirstOrDefault
                (p => p.Id == productId);
                

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var viewModel = new InvoiceViewModel
            {
                Clientlist = _clientService.GetAll(),
                Itemlist = _itemService.GetAll(),

            };
            return View("Create", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _context.InvoiceTemps.ToList();
                foreach (var item in result)
                {
                    model.NewBuyInovice.InvoiceProductList.Add(new InvoiceProduct()
                    {
                        Discount = item.Discount,
                        Price = item.Price,

                        ProductId = item.ProductId,

                        Quantity = (int)item.Quentit,
                        Total = (int)item.Total,

                    });
                    _context.InvoiceTemps.Remove(item);
                    _context.SaveChanges();
                }


                _context.Invoices.Add(model.NewBuyInovice);
                _context.SaveChanges();
                TempData["AlertMessage"] = Resource.Resource.InvoiceCreated;

                return RedirectToAction("Index", "Invoice");

            }
            return View(model.NewBuyInovice);
        }

    }
}