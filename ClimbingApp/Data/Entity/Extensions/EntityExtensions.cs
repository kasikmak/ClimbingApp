using System.Text.Json;

namespace ClimbingApp.Data.Entity.Extensions;

public static class EntityExtensions
{
    public static T? Copy<T>(this Task itemToCopy) where T : IEntity
    {
        var json = JsonSerializer.Serialize(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);
    }
}
