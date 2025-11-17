namespace Jacobi.Formatters.Tests;

public class StringFormatterTests
{
    [Fact]
    public void Upper()
    {
        Assert.Equal("UPPER", "upper".To<Upper>());
    }
    [Fact]
    public void Lower()
    {
        Assert.Equal("lower", "LOWER".To<Lower>());
    }

    [Fact]
    public void CamelCase()
    {
        Assert.Equal("camelCase", "CamelCase".To<CamelCase>());
    }

    [Fact]
    public void KebabCase()
    {
        Assert.Equal("Kebab-Case", "KebabCase".To<KebabCase>());
    }

    [Fact]
    public void SnakeCase()
    {
        Assert.Equal("Snake_Case", "SnakeCase".To<SnakeCase>());
    }

    [Fact]
    public void SpaceCase()
    {
        Assert.Equal("Space Case", "SpaceCase".To<SpaceCase>());
    }

    [Fact]
    public void Humanized()
    {
        Assert.Equal("Is this humanized?", "IsThisHumanized?".To<Humanized>());
    }
}
