using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;

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

        public Connection ConnectionsTest{ get; set; }


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
                _db.ConnectionsItems.Add(ConnectionsTest);

                await _db.SaveChangesAsync();

                afterAddMessage = "!new connection made!";

                return RedirectToPage("index");
            }
        }
    }
}