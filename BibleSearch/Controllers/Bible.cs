using BibleApplication.Models;
using BibleApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibleSearch.Controllers
{
    public class Bible : Controller
    {
        VerseDAO repository = new VerseDAO();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Results(string searchTerm, int testament)
        {
            List<VerseModel> verseList = repository.SearchedVerses(searchTerm, testament);

            return View("Results", verseList);
        }
    }
}
