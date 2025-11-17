using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Jacobi.Formatters;

internal static class EnumAttributeExtensions
{
    public static A? GetAttribute<A>(this Type type, string value) where A : Attribute
    {
        var fieldInfo = type.GetField(value);
        var attr = (A?)fieldInfo?
            .GetCustomAttributes(typeof(A), inherit: false)
            .FirstOrDefault();
        return attr;
    }

    public static bool TryProperty(this PropertyInfo[] propInfos, string propertyName, object instance, [NotNullWhen(true)] out string? value)
    {
        var propInfo = propInfos.FirstOrDefault(p => (p.Name == propertyName || propertyName == String.Empty) && p.PropertyType == typeof(string));
        value = (string?)propInfo?.GetValue(instance);
        return propInfo is not null;
    }
}

public sealed class Description : IEnumFormatter
{
    private Description() { }

    public static string Format<T>(T value) where T : Enum
    {
        var name = value?.ToString() ?? String.Empty;
        var attr = value?.GetType().GetAttribute<DescriptionAttribute>(name);
        return attr?.Description ?? name;
    }
}

public sealed class Display : IEnumFormatter
{
    private Display() { }

    public static string Format<T>(T value) where T : Enum
    {
        var name = value?.ToString() ?? String.Empty;
        var attr = value?.GetType().GetAttribute<DisplayAttribute>(name);
        if (attr is null) return name;

        return FormatDisplayParts(attr.GroupName, attr.Description, attr.Name, attr.ShortName) ?? name;
    }

    // TODO: how to format all these parts?
    private static string? FormatDisplayParts(string? groupName, string? description, string? name, string? shortName)
    {
        if (!String.IsNullOrEmpty(description))
            return description;
        if (!String.IsNullOrEmpty(name))
            return name;
        if (!String.IsNullOrEmpty(shortName))
            return shortName;
        if (!String.IsNullOrEmpty(groupName))
            return groupName;

        return null;
    }
}

public sealed class DefaultValue : IEnumFormatter
{
    private DefaultValue() { }

    public static string Format<T>(T value) where T : Enum
    {
        var name = value?.ToString() ?? String.Empty;
        var attr = value?.GetType().GetAttribute<DefaultValueAttribute>(name);
        return attr?.Value?.ToString() ?? name;
    }
}

public sealed class NameOf<AttributeT> : IFormatter where AttributeT : System.Attribute
{
    private NameOf() { }

    public static string Format<T>(T value)
    {
        var name = value?.ToString() ?? String.Empty;
        var attr = value?.GetType().GetAttribute<AttributeT>(name);
        var properties = attr?.GetType().GetProperties();
        if (properties is null) return name;

        if (properties.TryProperty("Name", attr!, out var propValue))
            return propValue;
        return name;
    }
}

public sealed class DescriptionOf<AttributeT> : IFormatter where AttributeT : System.Attribute
{
    private DescriptionOf() { }

    public static string Format<T>(T value)
    {
        var name = value?.ToString() ?? String.Empty;
        var attr = value?.GetType().GetAttribute<AttributeT>(name);
        var properties = attr?.GetType().GetProperties();
        if (properties is null) return name;

        if (properties.TryProperty("Description", attr!, out var propValue))
            return propValue;
        return name;
    }
}
