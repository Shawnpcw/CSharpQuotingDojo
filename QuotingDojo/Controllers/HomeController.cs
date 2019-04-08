using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]

        public IActionResult Index()
        {
            return View("index");
        }
        [HttpGet("quotes")]

        public IActionResult allQuotes()
        {
            List<Dictionary<string, object>> Quotes = DbConnector.Query($"SELECT * FROM Quote order by name");
            ViewBag.Quotes = Quotes;
            return View("allQuotes");
        }
        [HttpPost("addQuote")]

        public IActionResult addQuote(Quote myQuote)
        {
             if(ModelState.IsValid)
            {
                System.Console.WriteLine("went to add quote");
                string query = $"INSERT INTO Quote (name, quote) VALUES ('{myQuote.name}', '{myQuote.quote}')";
                DbConnector.Execute(query); 
                return RedirectToAction("allQuotes");
            }
            else{
                return RedirectToAction("Index");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
