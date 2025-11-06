using Microsoft.AspNetCore.Mvc;

namespace DesignPattern_Creational.Controllers;

public class ScenariosController : Controller
{
    [HttpGet]
    public IActionResult Index() => View();
}
