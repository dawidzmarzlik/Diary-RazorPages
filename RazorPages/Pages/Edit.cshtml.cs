using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class EditModel : PageModel
    {
        private static int post_id;

        [BindProperty(SupportsGet = true)]
        public int edit_id { get; set; }


        public PamModel Pam { get; set; }
        
        public void OnGet()
        {
            post_id = edit_id;
            using (var db = new Context())
            {
                Pam = db.PamModels.Where(c => c.Id == edit_id).ToList()[0];
            }
        }

        public void OnPost()
        {
            using (var db = new Context())
            {
                Pam = db.PamModels.Where(c => c.Id == post_id).ToList()[0];
                Pam.Topic = Request.Form["Pam.Topic"];
                Pam.Text = Request.Form["Pam.Text"];
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                Pam.Datetime = sqlFormattedDate;
                if (Pam.Topic.Length > 0 && Pam.Text.Length > 0)
                {
                    db.Update(Pam);
                    db.SaveChanges();
                    Response.Redirect("/Index");
                }
            }
        }
    }
}
