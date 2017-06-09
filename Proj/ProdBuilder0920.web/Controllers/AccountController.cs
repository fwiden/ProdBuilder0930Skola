using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ProdBuilder0920.Domain;
using ProdBuilder0920.DataService;
using ProdBuilder0920.Domain.ViewModels;
using ProdBuilder0920.Service;

namespace ProdBuilder0920.web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IProductService _productservice;

        public AccountController(IProductService productservice)
        {
            _productservice = productservice;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var appContext = new AppContext();
            var userStore = new UserStore<AppUser>(appContext);
            var userManager = new UserManager<AppUser>(userStore);
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var signInManager = new SignInManager<AppUser, string>(userManager, authenticationManager);
            var result = signInManager.PasswordSignIn(username, password, isPersistent: false, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                default: ModelState.AddModelError("", "Invalid login attempt.");
                    return View();
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            
            return RedirectToAction("Manage", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var AppContext = new AppContext();
            var userStore = new UserStore<AppUser>(AppContext);
            var userManager = new UserManager<AppUser>(userStore);
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var signInManager = new SignInManager<AppUser, string>(userManager, authenticationManager);

            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, 
                    CompanyName = model.CompanyName, DeliveryAdress = model.DeliveryAdress
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult MyOrders()
        {
            string name = User.Identity.Name;
            List<Order> orders = new List<Order>();
            orders = _productservice.GetOrders(name);

            return View(orders);
        }
    }

}
