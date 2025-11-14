using Microsoft.AspNetCore.Mvc;

namespace DesignPattern_Creational.Controllers;

public class BehavioralController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
