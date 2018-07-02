using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace ConnectionsTest.Pages.ConnectionsPages
{
    public class IndexModel : PageModel
    {
        private AppplicationDbContext _db;

        [TempData]

        public string afterAddMessage { get; set; }


        public IndexModel(AppplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Connection> Connect { get; set; }
        public Connection Connections { get; set; }
        public new async Task OnGet() 
        {
            Connect = await _db.ConnectionsItems.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int ID)
        {
            var Connection = _db.ConnectionsItems.Find(ID);
            _db.ConnectionsItems.Remove(Connection);

            await _db.SaveChangesAsync();

            return RedirectToPage();
        }
    }

}