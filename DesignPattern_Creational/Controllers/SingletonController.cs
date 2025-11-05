using DesignPattern_Creational.Services.Singleton;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern_Creational.Controllers;

public class SingletonController : Controller
{
    private readonly ICounterService _counter = CounterService.Instance;

    public IActionResult Index()
    {
        ViewBag.InstanceId = _counter.InstanceId;
        ViewBag.Value = _counter.Value;
        return View();
    }

    [HttpPost]
    public IActionResult Increment()
    {
        _counter.Increment();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Reset()
    {
        _counter.Reset();
        return RedirectToAction(nameof(Index));
    }
}