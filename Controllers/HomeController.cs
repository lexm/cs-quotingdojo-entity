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
            List<Quote> AllQuotes = _context.quotes.Include(quote => quote.author).Include(quote => quote.meta).Include(quote => quote.quote_cat).ToList();
            ViewBag.quotes = AllQuotes;
            return View();
        }

        [HttpGet]
        [Route("addquote")]
        public IActionResult AddQuote(CreateViewModel model)
        {
            List<Author> AllAuthors = _context.authors.ToList();
            ViewBag.authors = AllAuthors;
            List<Category> AllCategories = _context.categories.ToList();
            ViewBag.categories = AllCategories;
            return View(model);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                Quote NewQuote = new Quote();
                Author auth = _context.authors.SingleOrDefault(author => author.authorid == model.authorid);
                NewQuote.quote = model.Quote;
                NewQuote.author = auth;

                Meta NewMeta = new Meta();
                NewMeta.notes = model.notes;
                _context.metas.Add(NewMeta);
                _context.SaveChanges();
                NewMeta = _context.metas.Last();

                NewQuote.meta = NewMeta;
                _context.quotes.Add(NewQuote);
                _context.SaveChanges();
                NewQuote = _context.quotes.Last();
                 
                
                Quote_Category qcat = new Quote_Category();
                Category katz = _context.categories.SingleOrDefault(cate => cate.categoryid == model.categoryid);
                qcat.quote = NewQuote;
                qcat.quoteid = NewQuote.quoteid;
                qcat.category = katz;
                _context.quotes_categories.Add(qcat);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddQuote");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Quote DeleteMe = _context.quotes.SingleOrDefault(quote => quote.quoteid == id);
            _context.quotes.Remove(DeleteMe);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("addauthor")]
        public IActionResult AddAuthor(CreateViewModel model)
        {
            List<Author> AllAuthors = _context.authors.ToList();
            ViewBag.authors = AllAuthors;
            return View(model);
        }

        [HttpPost]
        [Route("create_author")]
        public IActionResult Create_Author(CreateAuthorViewModel model)
        {
            List<Author> AllAuthors;
            // TryValidateModel(model);
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("Good writes!");
                Author NewAuthor = new Author
                {
                    name = model.name,
                    // quotes = new List<Quote>(),
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                };
                System.Console.WriteLine("name is {0}", NewAuthor.name);
                _context.authors.Add(NewAuthor);
                _context.SaveChanges();
                AllAuthors = _context.authors.ToList();
                ViewBag.authors = AllAuthors;
                return RedirectToAction("AddAuthor");
            } 
            AllAuthors = _context.authors.ToList();
            ViewBag.authors = AllAuthors;
            return View("AddAuthor");
        }

        // [HttpPost]
        // [Route("create/category")]
        // public IActionResult Create_Author(CreateAuthorViewModel model)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         System.Console.WriteLine("Yah!!!");
        //     }
        //     else
        //     {
        //         System.Console.WriteLine("Nih!!!");
        //     }
        // }

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
