using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AccountingWeb.Controllers
{
    public class BudgetController : Controller
    {
        public ActionResult Index()
        {
            //Console.WriteLine($"{date}, ${budget}");
            return View();
        }

        [HttpPost]
        public ActionResult Create(string date, string budget)
        {
            ViewBag.Type = BudgetManager.Instance.CreateOrUpdateBudget(date, budget);
            return View();
        } 
    }
}