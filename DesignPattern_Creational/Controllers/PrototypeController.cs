using DesignPattern_Creational.Services.Prototype;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern_Creational.Controllers;

public class PrototypeController : Controller
{
    [HttpGet]
    public IActionResult Index(string? name, string? theme = null, string? language = null)
    {
        UserProfile? clone = null;
        UserProfile? proto = null;
        string? error = null;

        if (!string.IsNullOrWhiteSpace(name))
        {
            try
            {
                (proto, clone) = ProfileRegistry.CreateFrom(name);
                // Optionally mutate the clone to demonstrate independence from prototype
                if (!string.IsNullOrWhiteSpace(theme) && theme != "__same__") clone.Prefs.Theme = theme!;
                if (!string.IsNullOrWhiteSpace(language) && language != "__same__") clone.Prefs.Language = language!;
                // Give a distinct display for clarity
                clone.DisplayName = $"{clone.DisplayName} (Cloned)";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        ViewBag.Prototypes = ProfileRegistry.Names;
        ViewBag.Selected = name;
        ViewBag.Error = error;
        ViewBag.Prototype = proto;
        return View(clone);
    }
}
