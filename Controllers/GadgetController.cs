using GadgetInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace GadgetInventory.Controllers
{
    public class GadgetController : Controller
    {
        private static readonly List<Gadget> Gadgets = new()
        {
            new Gadget { Id = 1, Brand = "Apple", ModelName = "iPhone 15", Price = 799.00m },
            new Gadget { Id = 2, Brand = "Samsung", ModelName = "Galaxy S24", Price = 849.00m }
        };

        public IActionResult Index()
        {
            return View(Gadgets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gadget newGadget)
        {
            if (!ModelState.IsValid)
            {
                return View(newGadget);
            }

            newGadget.Id = Gadgets.Count == 0 ? 1 : Gadgets.Max(gadget => gadget.Id) + 1;
            Gadgets.Add(newGadget);

            return RedirectToAction("Index");
        }
    }
}
