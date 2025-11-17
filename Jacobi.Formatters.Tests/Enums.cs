using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jacobi.Formatters.Tests;

[Flags]
public enum TestFlags
{
    None = 0,
    [Description("This is Option Flag 1.")]
    OptionFlag1 = 1,
    [Display(Name = "OPTION Flag 2", Description = "This is option flag 2", GroupName = "TestFlags", ShortName = "OptF2")]
    OptionFlag2 = 2,
    [DefaultValue("This is option flag 4.")]
    OptionFlag4 = 4,
    OptionFlag8 = 8,
}

public enum TestEnum
{
    None,
    [Description("This is Option 1.")]
    ThisIsOption1,
    [Display(Name = "OPTION 2", Description = "This is option 2", GroupName = "TestEnum", ShortName = "Opt2")]
    ThisIsOption2,
    [DefaultValue("This is option 3.")]
    ThisIsOption3
}
