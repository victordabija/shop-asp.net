using Shop.Models;
using Shop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers;

public class ShopController(ShopService service) : Controller
{
    public IActionResult Index()
    {
        return View(service.GetAllProducts());
    }

    public IActionResult View(uint id)
    {
        return View(service.FindById(id));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }

        service.Create(product);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(uint id)
    {
        return View(service.FindById(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Product editedProduct)
    {
        service.Update(editedProduct);

        return RedirectToAction("Index");
    }

    public IActionResult Delete(uint id)
    {
        service.DeleteById(id);

        return RedirectToAction("Index");
    }
}