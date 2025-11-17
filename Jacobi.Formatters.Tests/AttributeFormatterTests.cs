namespace Jacobi.Formatters.Tests;

public class AttributeFormatterTests
{
    [Fact]
    public void DescriptionAttr()
    {
        Assert.Equal("This is Option 1.", TestEnum.ThisIsOption1.To<Description>());
    }
    [Fact]
    public void DescriptionAttrFlags()
    {
        Assert.Equal("This is Option Flag 1., OptionFlag4", (TestFlags.OptionFlag1 | TestFlags.OptionFlag4).To<Description>());
    }

    [Fact]
    public void DisplayAttr()
    {
        Assert.Equal("This is option 2", TestEnum.ThisIsOption2.To<Display>());
    }
    [Fact]
    public void DisplayAttrFlags()
    {
        Assert.Equal("OptionFlag1, This is option flag 2", (TestFlags.OptionFlag1 | TestFlags.OptionFlag2).To<Display>());
    }

    [Fact]
    public void DefaultValueAttr()
    {
        Assert.Equal("This is option 3.", TestEnum.ThisIsOption3.To<DefaultValue>());
    }
    [Fact]
    public void DefaultValueAttrFlags()
    {
        Assert.Equal("OptionFlag2, This is option flag 4.", (TestFlags.OptionFlag2 | TestFlags.OptionFlag4).To<DefaultValue>());
    }

    [Fact]
    public void ReflectionAttr()
    {
        Assert.Equal("This is Option 1.", TestEnum.ThisIsOption1.To<DescriptionOf<System.ComponentModel.DescriptionAttribute>>());
        Assert.Equal("OPTION 2", TestEnum.ThisIsOption2.To<NameOf<System.ComponentModel.DataAnnotations.DisplayAttribute>>());
    }
}
