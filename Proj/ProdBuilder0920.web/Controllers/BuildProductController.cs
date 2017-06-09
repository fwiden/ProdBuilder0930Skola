using System.Collections.Generic;
using System.Web.Mvc;
using ProdBuilder0920.Domain;
using ProdBuilder0920.Domain.ViewModels;
using ProdBuilder0920.Service;

namespace ProdBuilder0920.web.Controllers
{
    [Authorize]
    public class BuildProductController : Controller
    {
        private readonly IProductService _productservice;

        public BuildProductController(IProductService productservice)
        {
            _productservice = productservice;
        }

        public ActionResult Index()
        {
            Session["PartCart"] = null;
            var model = new GetPackageViewModel();
            model.Packages = _productservice.GetAllPackages_();
            model.PartTypes = _productservice.GetAllPartTypes();
            model.Parts = _productservice.GetAllParts();
            model.PackageSeries = _productservice.GetAllPackageSeries();
          
            return View(model);
        }

        [HttpGet]
        public ActionResult Customize(int id)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Index");
            }
           
            var result = _productservice.GetParttypesAndParts(id);
            ViewBag.packetName = _productservice.GetAPackage(id).PackageName;
            ViewBag.packetPrice = _productservice.GetAPackage(id).PackageStartPrice;
            Session["PackageName"] = _productservice.GetAPackage(id).PackageName;
            Session["PacketPrice"] = _productservice.GetAPackage(id).PackageStartPrice;
            Session["PackageID"] = id;

            return View(result);
        }

        [HttpGet]
        public PartialViewResult GetPackages(int id)
        {
            var result = _productservice.GetAllPackages(id);
            return PartialView("_AjaxPartialPackages", result);
        }

        [HttpGet]
        public PartialViewResult GetParttypesAndPackage(int id)
        {
            var result = _productservice.GetParttypesAndParts(id);
            return PartialView("_ParttypesParts", result);
        }

        [HttpGet]
        public PartialViewResult Choice(int id) //in med partid på vald del
        {
            List<Part> prodlist;
            var partAndParttype = _productservice.GetPartTypeAndPart(id);

            if (Session["PartCart"] == null)
            {
                prodlist = new List<Part>();
                prodlist.Add(partAndParttype);
            }
            else
            {
                prodlist = (List<Part>)Session["PartCart"];
               var res = _productservice.GetCartStatus(prodlist, partAndParttype);
                
                if (!res)
                {
                    prodlist.Add(partAndParttype);
                }
                else
                {
                    return PartialView("_error");
                }
               
            }
            Session["PartCart"] = prodlist;
            var result = _productservice.GetPart(id);
            return PartialView("_AjaxChioce", result);
        }

        public ActionResult ViewCart()
        {
            var package = Session["PackageName"];
            ViewBag.id = package;
            ViewBag.price = Session["PacketPrice"];

            //Hämtar lista med produkter från sessionsvariabeln
            List <Part> model = (List<Part>)Session["PartCart"];

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        public ActionResult PlaceOrder()
        {
            //Hämtar lista med produkter från sessionsvariabeln
            List<Part> cartList =(List<Part>)Session["PartCart"];
            string user = User.Identity.Name;
            int id =(int)Session["PackageID"];
            int price = (int) Session["PacketPrice"];
           
            _productservice.WriteOrder(cartList,id,user, price);

            return View();
        }

    }
}