using AngularJSForm.Business;
using AngularJSForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJSForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateCustomer(Customer model)
        {
            if (ModelState.IsValid)
            {
                //Data save to database
                var RedirectUrl = Url.Action("About", "Home", new { area = "" });
                return Json(new { success = true, redirectUrl = RedirectUrl });
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
        }
        [HttpPost]
        public JsonResult Calculate(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                //Data save to database
                Evaluator evaluator = new Evaluator();
                model.Result = evaluator.Evaluate(model);
                var RedirectUrl = Url.Action("About", "Home", new { area = "" });
                return Json(new { result = model, success = true});
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
        }
        // GET: Home/About
        public ActionResult About()
        {
            return View();
        }
        
    }
}