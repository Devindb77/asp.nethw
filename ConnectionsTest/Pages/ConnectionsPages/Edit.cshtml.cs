using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConnectionsTest.Pages.ConnectionsPages
{
    public class EditModel : PageModel
         {
        private AppplicationDbContext _db;

        public EditModel(AppplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Model.Connection Connections { get; set; }

        [TempData]
        public string afterAddMessage { get; set; }

        public void OnGet(int id)
        {
            Connections = _db.ConnectionsItems.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {



                await _db.SaveChangesAsync();

                afterAddMessage = "List item updated successfully!";

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
