using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DbConnection;
using Microsoft.AspNetCore.Mvc;
using quotes.Models;
using Newtonsoft.Json;

namespace quotes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }
        [HttpGet("quotes")]
        public IActionResult QuotesSplash()
        {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users ORDER BY created_at DESC");
            ViewBag.Allusers = AllUsers;
            return View("quotes");
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(string name, string content)
        { 
            Models.Quote quote = new Models.Quote(name,content);

            TryValidateModel(quote);

            if (ModelState.IsValid)
            {
                string query = $"INSERT INTO users (name, quote,created_at) VALUES ('{quote.name}', '{quote.content}',NOW());";
                DbConnector.Execute(query);
                return RedirectToAction("QuotesSplash");
            }
            else
            {
                return RedirectToAction("Index");
            }  
        }
    }
}