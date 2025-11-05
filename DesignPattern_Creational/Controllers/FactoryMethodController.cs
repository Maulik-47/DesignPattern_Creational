using DesignPattern_Creational.Services.FactoryMethod;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern_Creational.Controllers;

public class FactoryMethodController : Controller
{
    [HttpGet]
    public IActionResult Index(string? type, decimal amount = 99.99m)
    {
        var payment = PaymentFactory.Create(type);
        ViewBag.Selected = payment.Name;
        ViewBag.Result = payment.Pay(amount);
        ViewBag.Amount = amount;
        return View();
    }
}