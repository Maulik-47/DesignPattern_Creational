using Microsoft.AspNetCore.Mvc;

namespace DesignPattern_Creational.Controllers;

public class StructuralController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
