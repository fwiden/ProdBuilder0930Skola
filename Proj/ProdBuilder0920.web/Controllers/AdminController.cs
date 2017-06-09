using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdBuilder0920.Domain;
using ProdBuilder0920.Domain.ViewModels;
using ProdBuilder0920.Service;

namespace ProdBuilder0920.web.Controllers
{
    [Authorize(Roles = "admins")]
    public class AdminController : Controller
    {
        private readonly IProductService _productservice;
        
        public AdminController(IProductService productservice)
        {
            _productservice = productservice;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult AdminLogin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult AddPackage()
        {
            AdminAddPackageViewModel model=new AdminAddPackageViewModel();
            List<PackageSeries> list = _productservice.GetAllPackageSeries();
            foreach (var item  in list)
            {
                    model.SelectListItems.Add(new SelectListItem
                    {
                        Text = item.PackageSeriesName , Value = item.PackageSeriesId.ToString()
                    });
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPackage(AdminAddPackageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                List<PackageSeries> list = _productservice.GetAllPackageSeries();
                foreach (var item in list)
                {
                    model.SelectListItems.Add(new SelectListItem
                    {
                        Text = item.PackageSeriesName,
                        Value = item.PackageSeriesId.ToString()
                    });
                }
                return View(model);
            }

           _productservice.AddPackage(model);
            return RedirectToAction("Thankyou");
        }

        public ActionResult AddPackageSeries()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPackageSeries(PackageSeries packageSeries)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _productservice.AddPackageSeries(packageSeries);
           return RedirectToAction("Thankyou");
        }

        public ActionResult AddParttype()
        {
            AdminAddParttypwViewModel model = new AdminAddParttypwViewModel();
            List<Package> list = _productservice.GetAllPackages_();
            foreach (var item in list)
            {
                model.SelectListItems.Add(new SelectListItem
                {
                    Text = item.PackageName,
                    Value = item.PackageID.ToString()
                });
            }
           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddParttype(AdminAddParttypwViewModel model)
        {
            if (!ModelState.IsValid)
            {
                List<Package> list = _productservice.GetAllPackages_();
                foreach (var item in list)
                {
                    model.SelectListItems.Add(new SelectListItem
                    {
                        Text = item.PackageName,
                        Value = item.PackageID.ToString()
                    });
                }

                return View(model);
            }

            _productservice.AddPartType(model);
            return RedirectToAction("Thankyou");
            
        }

        public ActionResult AddPart()
        {
            var model = _productservice.GetAllPackageSeries();
            return View(model);
        }

        [HttpGet]
        public PartialViewResult AddPartMiddle(int id)
        {
            var result = _productservice.GetAllPackages(id);
            return PartialView("_middle", result);
        }

        [HttpGet]
        public PartialViewResult AddPartMiddleRight(int id)
        {
            //var productservice = new ProductService();
            var result = _productservice.GetPartTypes(id);
            return PartialView("_middleright", result);
        }

        [HttpGet]
        public PartialViewResult ShowRight(int id)
        {
             var model = new Part();
            model.PartTypeId = id;
            return PartialView("_right", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPart(Part model)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            _productservice.AddPart(model);
            return RedirectToAction("Thankyou");
        }

        public ActionResult SeeAllOrders()
        {
            var orders = _productservice.GetAllOrders();
            return View(orders);
        }


        public ActionResult EditOrderStatus(int id)
        {
           var model = _productservice.GetOrder(id);
            return View(model);

        }

        [HttpPost]
        public ActionResult EditOrderStatus(Order model)
        {
            _productservice.UpdateOrderStatus(model);
            return RedirectToAction("Thankyou");
        }

        public ActionResult Thankyou()
        {
            return View();
        }

        public ActionResult UpdatePackage()
        {
            var model = _productservice.GetAllPackages_();
            return View(model);
        }

        public ActionResult UpdatePackageIn(int id)
        {
            var model = _productservice.GetAPackage(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdatePackageIn(Package model)
        {
            _productservice.UpdatePackage(model);
            return RedirectToAction("Thankyou");
        }

        public ActionResult UpdatePackageSeries()
        {
            var model = _productservice.GetAllPackageSeries();
            return View(model);
        }

        public ActionResult UpdatePackageSeriesIn(int id)
        {
            var model = _productservice.GetAPackageSeries(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdatePackageSeriesIn(PackageSeries model)
        {
            _productservice.UpdateSeries(model);
            return RedirectToAction("Thankyou");
        }

        public ActionResult UpdatePartType()
        {
            var model = _productservice.GetAllPartTypes();
            return View(model);
        }

        public ActionResult UpdatePartTypeIn(int id)
        {
            var model = _productservice.GetAPartType(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdatePartTypeIn(PartType model)
        {
            _productservice.UpdatePArtType(model);
            return RedirectToAction("Thankyou");
        }

        public ActionResult UpdatePart()
        {
            var model = _productservice.GetAllParts();
            return View(model);
        }

        public ActionResult UpdatePartIn(int id)
        {
            var model = _productservice.GetPart(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdatePartIn(Part model)
        {
            _productservice.UpdatePart(model);
            return RedirectToAction("Thankyou");
        }


        public ActionResult DeletePart()
        {
            var model = _productservice.GetAllParts();
            return View(model);
        }

        [HttpGet]
        public ActionResult DeletePartIn(int id)
        {
            _productservice.PsDeletePart(id);
            return RedirectToAction("Thankyou");
        }

        public ActionResult DeletePartType()
        {
            var model = _productservice.GetAllPartTypes();
            return View(model);
        }

        [HttpGet]
        public ActionResult DeletePartTypeIn(int id)
        {

            _productservice.PSsDeletePartType(id);
            return RedirectToAction("Thankyou");
        }

        public ActionResult DeletePackage()
        {
            var model = _productservice.GetAllPackages_();
            return View(model);
        }

        [HttpGet]
        public ActionResult DeletePackageIn(int id)
        {
           _productservice.PSsDeletePackage(id);
            return RedirectToAction("Thankyou");
        }

        public ActionResult DeletePackageSeries()
        {
            var model = _productservice.GetAllPackageSeries();
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteSeriesIn(int id)
        {
            _productservice.PSsDeletePackageSeries(id);
            return RedirectToAction("Thankyou");
        }

    }

}