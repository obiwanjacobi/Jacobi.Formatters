namespace Jacobi.EnumFormatter.Tests;

public class EnumFormatterTests
{
    [Fact]
    public void Upper()
    {
        Assert.Equal("NONE", TestEnum.None.To<Upper>());
    }
    [Fact]
    public void Lower()
    {
        Assert.Equal("none", TestEnum.None.To<Lower>());
    }

    [Fact]
    public void CamelCase()
    {
        Assert.Equal("thisIsOption2", TestEnum.ThisIsOption2.To<CamelCase>());
    }

    [Fact]
    public void KebabCase()
    {
        Assert.Equal("This-Is-Option2", TestEnum.ThisIsOption2.To<KebabCase>());
    }

    [Fact]
    public void SnakeCase()
    {
        Assert.Equal("This_Is_Option2", TestEnum.ThisIsOption2.To<SnakeCase>());
    }

    [Fact]
    public void SpaceCase()
    {
        Assert.Equal("This Is Option2", TestEnum.ThisIsOption2.To<SpaceCase>());
    }

    [Fact]
    public void Humanized()
    {
        Assert.Equal("This is option3", TestEnum.ThisIsOption3.To<Humanized>());
    }

    [Fact]
    public void NumericValue()
    {
        Assert.Equal("2", TestEnum.ThisIsOption2.To<NumericValue>());
    }

    [Fact]
    public void HexValue()
    {
        Assert.Equal("0x3", TestEnum.ThisIsOption3.To<HexValue>());
    }
    [Fact]
    public void Hex2Value()
    {
        Assert.Equal("0x03", TestEnum.ThisIsOption3.To<HexValue2>());
    }
    [Fact]
    public void Hex4Value()
    {
        Assert.Equal("0x0003", TestEnum.ThisIsOption3.To<HexValue4>());
    }
    [Fact]
    public void Hex8Value()
    {
        Assert.Equal("0x00000003", TestEnum.ThisIsOption3.To<HexValue8>());
    }
}
