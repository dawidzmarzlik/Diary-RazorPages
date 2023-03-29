using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class addModel : PageModel
    {
        public PamModel Pam  { get; set; }
        List<PamModel> Pams = new List<PamModel>();
        public void OnGet()
        {
        }
        
        public void OnPost(PamModel Pam)
        {
            using (var db = new Context())
            {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                Pam.Datetime = sqlFormattedDate;
                if (Pam.Topic.Length > 0 && Pam.Text.Length > 0)
                {
                    db.Add(Pam);
                    db.SaveChanges();
                    Response.Redirect("/Index");
                }
            }
        }
    }
}
