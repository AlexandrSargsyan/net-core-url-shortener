using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheURLShortener.CoreLayer;
using TheURLShortener.DatabaseLayer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheURLShortener
{

    public class RedirectController : Controller
    {
        private readonly IDatabase _database;
        private readonly IIDGenerator _idGenerator;

        public RedirectController(IDatabase database, IIDGenerator idGenerator)
        {
            _database = database;
            _idGenerator = idGenerator;
        }

        public IActionResult Index(string alias)
        {
            var url = _database.GetUrl(alias);
            if (string.IsNullOrEmpty(url)) return NotFound();
            return Redirect(url);
        }

        public IActionResult Insert(string url, string alias)
        {
            if(string.IsNullOrEmpty(alias))
            {
                alias = _idGenerator.Generate(7);
            }

            var newId = _database.Insert(new Models.URLEntity { Alias = alias, Url = url });
            if (newId < 0) return BadRequest("error while insert");

            return Json(new { id = newId, alias = alias });
        }
    }
}
