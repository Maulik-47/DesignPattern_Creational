using DesignPattern_Creational.Services.Builder;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern_Creational.Controllers;

public class BuilderController : Controller
{
    [HttpGet]
    public IActionResult Index() => View(new Order());

    [HttpPost]
    public IActionResult Build(string product, int quantity, string? giftMessage)
    {
        try
        {
            var builder = new OrderBuilder()
                .AddItem(product, quantity)
                .WithGift(giftMessage);
            var order = builder.Build();
            return View("Index", order);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View("Index", new Order());
        }
    }
}