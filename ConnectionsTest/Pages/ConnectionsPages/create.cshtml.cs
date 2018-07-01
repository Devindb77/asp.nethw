using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ConnectionsTest.Pages.ConnectionsPages
{
    public class createModel : PageModel
    {
        private AppplicationDbContext _db;

        public createModel(AppplicationDbContext db)
        {
            _db = db;
        }
        [TempData]

        public string afterAddMessage { get; set; }
        [BindProperty]

        public connections connect { get; set; }


        public void OnGet()
        {

        }
        public async Task<IActionResult>Onpost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                _db.ConnectionsItems.Add(connect);

                await _db.SaveChangesAsync();

                afterAddMessage = "!new connwction made!";

                return RedirectToPage("index");
            }
        }
    }
}