namespace Jacobi.EnumFormatter.Tests;

public class FlagsFormatterTests
{
    [Fact]
    public void Upper()
    {
        Assert.Equal("OPTIONFLAG1, OPTIONFLAG2", (TestFlags.OptionFlag1 | TestFlags.OptionFlag2).To<Upper>());
    }
    [Fact]
    public void Lower()
    {
        Assert.Equal("optionflag1, optionflag2", (TestFlags.OptionFlag1 | TestFlags.OptionFlag2).To<Lower>());
    }

    [Fact]
    public void CamelCase()
    {
        Assert.Equal("optionFlag2, optionFlag4", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<CamelCase>());
    }

    [Fact]
    public void KebabCase()
    {
        Assert.Equal("Option-Flag2, Option-Flag4", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<KebabCase>());
    }

    [Fact]
    public void SnakeCase()
    {
        Assert.Equal("Option_Flag2, Option_Flag4", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<SnakeCase>());
    }

    [Fact]
    public void SpaceCase()
    {
        Assert.Equal("Option Flag2, Option Flag4", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<SpaceCase>());
    }

    [Fact]
    public void Humanized()
    {
        Assert.Equal("Option flag2, Option flag4", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<Humanized>());
    }

    [Fact]
    public void NumericValue()
    {
        Assert.Equal("2, 4", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<NumericValue>());
    }

    [Fact]
    public void HexValue()
    {
        Assert.Equal("0x2, 0x4", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<HexValue>());
    }
    [Fact]
    public void Hex2Value()
    {
        Assert.Equal("0x02, 0x04", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<HexValue2>());
    }
    [Fact]
    public void Hex4Value()
    {
        Assert.Equal("0x0002, 0x0004", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<HexValue4>());
    }
    [Fact]
    public void Hex8Value()
    {
        Assert.Equal("0x00000002, 0x00000004", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<HexValue8>());
    }
}
