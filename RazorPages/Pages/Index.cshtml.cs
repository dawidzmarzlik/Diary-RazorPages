using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int selected_id { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public List<PamModel> Pams { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (var db = new Context())
            {
                Pams = db.PamModels.OrderByDescending(c => c.Id).ToList();
            }
        }
           
        public void OnPost()
        {
            using (var db = new Context())
            {
                PamModel pam = new PamModel() { Id = selected_id };
                pam.Id = selected_id;
                db.Attach(pam);
                db.Remove(pam);
                db.SaveChanges();
                Pams = db.PamModels.OrderByDescending(c => c.Id).ToList();
            }
        }
    }
}
