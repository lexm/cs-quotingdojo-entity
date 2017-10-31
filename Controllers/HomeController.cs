using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quoteme.Models;
using Microsoft.EntityFrameworkCore;

namespace quoteme.Controllers
{
    public class HomeController : Controller
    {
        private QuoteContext _context;
        public HomeController(QuoteContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Quote> AllQuotes = _context.Quotes.Include(quote => quote.author).ToList();
            ViewBag.quotes = AllQuotes;
            return View();
        }

        [HttpGet]
        [Route("addquote")]
        public IActionResult AddQuote(CreateViewModel model)
        {
            List<Author> AllAuthors = _context.Authors.ToList();
            ViewBag.authors = AllAuthors;
            return View(model);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                
                Quote NewQuote = new Quote
                {
                    authorid = model.authorid,
                    author = _context.Authors.SingleOrDefault(author => author.authorid == model.authorid),
                    quote = model.Quote,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                };
                _context.Add(NewQuote);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddQuote");

            // return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Quote DeleteMe = _context.Quotes.SingleOrDefault(quote => quote.quoteid == id);
            _context.Quotes.Remove(DeleteMe);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // public IActionResult About()
        // {
        //     ViewData["Message"] = "Your application description page.";

        //     return View();
        // }

        // public IActionResult Contact()
        // {
        //     ViewData["Message"] = "Your contact page.";

        //     return View();
        // }

        // public IActionResult Error()
        // {
        //     return View();
        // }
    }
}
