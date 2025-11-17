namespace Jacobi.Formatters;

public static class FormatExtensions
{
    public static string To<F>(this Enum value)
        where F : IEnumFormatter
    {
        var flags = GetEnumOptions(value);
        return String.Join(", ", flags.Select(v => F.Format(v)));
    }

    public static string To<F>(this object value)
        where F : IFormatter
    {
        if (value is null) return String.Empty;
        return F.Format(value);
    }

    private static IEnumerable<Enum> GetEnumOptions(Enum value)
    {
        var type = value.GetType();
        if (type.IsDefined(typeof(FlagsAttribute), false))
        {
            foreach (Enum flag in Enum.GetValues(type))
                if (Convert.ToInt64(flag) != 0 && value.HasFlag(flag))
                    yield return flag;
        }
        else
        {
            yield return value;
        }
    }
}

public interface IFormatter
{
    static abstract string Format<T>(T value);
}

public interface IEnumFormatter
{
    static abstract string Format<T>(T value) where T : Enum;
}
