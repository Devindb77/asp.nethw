using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ConnectionsTest.Pages.ConnectionsPages
{
    public class Edit :PageModel
        {
        private AppplicationDbContext _db;

        public Edit(AppplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Connection Connections { get; set; }

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
                var connectionInDb = _db.ConnectionsItems.Find(Connections.ID);
                connectionInDb.Connections = Connections.gamerGamer;
                connectionInDb.ConnectionDescription = Connections.GameGame;


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
