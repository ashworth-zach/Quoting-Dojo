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
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            ViewBag.Allusers = AllUsers;
            return View("quotes");
        }
        // Get One User
        // [HttpGet]
        // [Route("{userId}")]
        // public IActionResult Show(int userId)
        // {
        //     Dictionary<string, object> User = DbConnector.Query($"SELECT * FROM users WHERE id = {userId}");
        //     // Other code
        // }
        // // Create a User
        // [HttpPost]
        // [Route("create")]
        // public IActionResult Create(User user)
        // {
        //     // other code
        //     string query = $"INSERT INTO users (FirstName, LastName) VALUES ('{user.FirstName}', '{user.LastName}')";
        //     DbConnector.Execute(query);
        //     // other code
        // }
    }
}