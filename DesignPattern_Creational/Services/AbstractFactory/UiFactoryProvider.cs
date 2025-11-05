namespace DesignPattern_Creational.Services.AbstractFactory;

public static class UiFactoryProvider
{
    public static IUiFactory GetFactory(string? theme)
    {
        switch (theme?.ToLowerInvariant())
        {
            case "dark":
                return new DarkUiFactory();
            case "light":
            case null:
            case "":
                return new LightUiFactory();
            default:
                // Default to Light to keep the demo simple
                return new LightUiFactory();
        }
    }
}
