using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }

        //Add a form to create new Pizza

        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;

        // Page handler for HTTP POST

        public IActionResult OnPost ()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }
            _service.AddPizza(NewPizza);
            return RedirectToAction("Get");
        }
    }
}
