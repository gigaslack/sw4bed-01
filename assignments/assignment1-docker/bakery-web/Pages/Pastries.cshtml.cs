using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using bakery_api.Models;

namespace MyApp.Namespace
{
    public class PastriesModel : PageModel
    {
        public IList<Pastry>? Pastries { get; set; } = new List<Pastry>();
        public async Task<IActionResult> OnGetAsync()
        {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:5066");
                Pastries = await client.GetFromJsonAsync<IList<Pastry>>("pastries");
            }
            return Page();
        }   
    }
}