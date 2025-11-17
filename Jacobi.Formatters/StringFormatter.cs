namespace Jacobi.EnumFormatter;

public sealed class Upper : IFormatter, IEnumFormatter
{
    private Upper() { }

    public static string Format<T>(T value)
        => value?.ToString()?.ToUpperInvariant() ?? String.Empty;

    static string IEnumFormatter.Format<T>(T value)
        => Format(value);
}

public sealed class Lower : IFormatter, IEnumFormatter
{
    private Lower() { }

    public static string Format<T>(T value)
        => value?.ToString()?.ToLowerInvariant() ?? String.Empty;

    static string IEnumFormatter.Format<T>(T value)
        => Format(value);
}

public sealed class CamelCase : IFormatter, IEnumFormatter
{
    private CamelCase() { }

    public static string Format<T>(T value)
    {
        var str = value?.ToString() ?? String.Empty;
        return new([Char.ToLowerInvariant(str[0]), .. str[1..]]);
    }

    static string IEnumFormatter.Format<T>(T value)
        => Format<T>(value);
}

public sealed class KebabCase : IFormatter, IEnumFormatter
{
    private KebabCase() { }

    public static string Format<T>(T value)
    {
        var str = value?.ToString() ?? String.Empty;
        return new(str.SelectMany<char, char>(
            static (c, i) => i > 0 && Char.IsUpper(c) ? ['-', c] : [c]
        ).ToArray());
    }

    static string IEnumFormatter.Format<T>(T value)
        => Format<T>(value);
}

public sealed class SnakeCase : IFormatter, IEnumFormatter
{
    private SnakeCase() { }

    public static string Format<T>(T value)
    {
        var str = value?.ToString() ?? String.Empty;
        return new(str.SelectMany<char, char>(
            static (c, i) => i > 0 && Char.IsUpper(c) ? ['_', c] : [c]
        ).ToArray());
    }

    static string IEnumFormatter.Format<T>(T value)
        => Format<T>(value);
}

public sealed class SpaceCase : IFormatter, IEnumFormatter
{
    private SpaceCase() { }

    public static string Format<T>(T value)
    {
        var str = value?.ToString() ?? String.Empty;
        return new(str.SelectMany<char, char>(
            static (c, i) => i > 0 && Char.IsUpper(c) ? [' ', c] : [c]
        ).ToArray());
    }

    static string IEnumFormatter.Format<T>(T value)
        => Format<T>(value);
}

public sealed class Humanized : IFormatter, IEnumFormatter
{
    private Humanized() { }

    public static string Format<T>(T value)
    {
        var str = value?.ToString() ?? String.Empty;
        return new(str.SelectMany<char, char>(
            static (c, i) => i > 0 && Char.IsUpper(c) ? [' ', Char.ToLower(c)] : [c]
        ).ToArray());
    }

    static string IEnumFormatter.Format<T>(T value)
        => Format<T>(value);
}

public sealed class NumericValue : IEnumFormatter
{
    private NumericValue() { }

    public static string Format<T>(T value) where T : Enum
        => Convert.ToInt64(value).ToString();
}

public sealed class HexValue : IEnumFormatter
{
    private HexValue() { }

    public static string Format<T>(T value) where T : Enum
        => $"0x{Convert.ToInt64(value):X}";
}
public sealed class HexValue2 : IEnumFormatter
{
    private HexValue2() { }

    public static string Format<T>(T value) where T : Enum
        => $"0x{Convert.ToInt64(value):X2}";
}
public sealed class HexValue4 : IEnumFormatter
{
    private HexValue4() { }

    public static string Format<T>(T value) where T : Enum
        => $"0x{Convert.ToInt64(value):X4}";
}
public sealed class HexValue8 : IEnumFormatter
{
    private HexValue8() { }

    public static string Format<T>(T value) where T : Enum
        => $"0x{Convert.ToInt64(value):X8}";
}
