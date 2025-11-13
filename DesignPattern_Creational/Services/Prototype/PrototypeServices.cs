namespace DesignPattern_Creational.Services.Prototype;

public interface IPrototype<T>
{
    T Clone(); // default: deep clone per prototype contract
}

public class Preferences
{
    public string Theme { get; set; } = "Light";
    public string Language { get; set; } = "en-US";
}

public class UserProfile : IPrototype<UserProfile>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Role { get; init; } = "Viewer";
    public string DisplayName { get; set; } = "";
    public Preferences Prefs { get; init; } = new();

    public UserProfile Clone()
    {
        // Deep clone: copy object graph manually for demo clarity
        return new UserProfile
        {
            // New Id for the clone to show it is a new instance
            DisplayName = DisplayName,
            Role = Role,
            Prefs = new Preferences
            {
                Theme = Prefs.Theme,
                Language = Prefs.Language
            }
        };
    }
}

public static class ProfileRegistry
{
    // Preconfigured prototypes
    private static readonly Dictionary<string, UserProfile> _prototypes = new(StringComparer.OrdinalIgnoreCase)
    {
        ["basic"] = new UserProfile { DisplayName = "Basic User", Role = "Viewer", Prefs = new Preferences { Theme = "Light", Language = "en-US" } },
        ["power"] = new UserProfile { DisplayName = "Power User", Role = "Editor", Prefs = new Preferences { Theme = "Dark", Language = "en-US" } },
        ["admin"] = new UserProfile { DisplayName = "Admin", Role = "Admin", Prefs = new Preferences { Theme = "Dark", Language = "en-GB" } }
    };

    public static IEnumerable<string> Names => _prototypes.Keys.OrderBy(k => k);

    public static (UserProfile prototype, UserProfile clone) CreateFrom(string name)
    {
        if (!_prototypes.TryGetValue(name, out var proto))
            throw new NotSupportedException($"Prototype '{name}' not found.");
        var clone = proto.Clone();
        return (proto, clone);
    }
}
