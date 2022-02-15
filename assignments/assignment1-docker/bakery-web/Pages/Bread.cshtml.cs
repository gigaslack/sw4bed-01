using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bakery_api.Models;

namespace MyApp.Namespace
{
    public class BreadModel : PageModel
    {
        public IList<Bread>? Breads { get; set; } = new List<Bread>();
        public async Task<IActionResult> OnGetAsync()
        {
            using(HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:5066");
                Breads = await client.GetFromJsonAsync<IList<Bread>>("breads");
            }
            return Page();
        }
    }
}
