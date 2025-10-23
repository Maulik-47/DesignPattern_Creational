using DesignPattern_Creational.Services.AbstractFactory;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern_Creational.Controllers;

public class AbstractFactoryController : Controller
{
    [HttpGet]
    public IActionResult Index(string? theme)
    {
        IUiFactory factory = theme?.ToLowerInvariant() switch
        {
            "dark" => new DarkUiFactory(),
            _ => new LightUiFactory()
        };

        var button = factory.CreateButton("Submit");
        var textbox = factory.CreateTextBox("Type here...");

        ViewBag.Factory = factory.Name;
        ViewBag.ButtonCss = button.CssClass;
        ViewBag.ButtonText = button.Text;
        ViewBag.TextBoxCss = textbox.CssClass;
        ViewBag.TextBoxPlaceholder = textbox.Placeholder;
        return View();
    }
}