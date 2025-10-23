namespace DesignPattern_Creational.Services.AbstractFactory;

public interface IUIButton
{
    string CssClass { get; }
    string Text { get; }
}

public interface IUITextBox
{
    string CssClass { get; }
    string Placeholder { get; }
}

public interface IUiFactory
{
    IUIButton CreateButton(string text);
    IUITextBox CreateTextBox(string placeholder);
    string Name { get; }
}

// Light theme controls
public class LightButton : IUIButton { public string CssClass => "btn btn-outline-primary"; public string Text { get; init; } = ""; }
public class LightTextBox : IUITextBox { public string CssClass => "form-control"; public string Placeholder { get; init; } = ""; }

public class LightUiFactory : IUiFactory
{
    public string Name => "Light";
    public IUIButton CreateButton(string text) => new LightButton { Text = text };
    public IUITextBox CreateTextBox(string placeholder) => new LightTextBox { Placeholder = placeholder };
}

// Dark theme controls
public class DarkButton : IUIButton { public string CssClass => "btn btn-dark"; public string Text { get; init; } = ""; }
public class DarkTextBox : IUITextBox { public string CssClass => "form-control bg-dark text-white border-secondary"; public string Placeholder { get; init; } = ""; }

public class DarkUiFactory : IUiFactory
{
    public string Name => "Dark";
    public IUIButton CreateButton(string text) => new DarkButton { Text = text };
    public IUITextBox CreateTextBox(string placeholder) => new DarkTextBox { Placeholder = placeholder };
}