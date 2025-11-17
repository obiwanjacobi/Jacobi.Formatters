# Enum Formatter

Typically the object's `ToString()` value is used as a basis for further formatting.
For `Enum`s and `[Flags]` there are some exceptions.

## Formats

`Object.To<FormatterType>()`

`Enum.Option.To<FormatterType>()`

### String Formatters

`O` => `Object`
`E` => `Enum`

| Formatter Type | Types | Description | Example | Result |
|----------------|-------|-------------|---------|--------|
| `Upper` | O/E | Converts all to upper case. | 'Upper' | 'UPPER' |
| `Lower` | O/E | Converts all to lower case. | 'Lower' | 'lower' |
| `CamelCase` | O/E | Converts to first char to lower. | 'CamelCase' | 'camelCase' |
| `KebabCase` | O/E | Inserts a '-' before every capital char. | 'KebabCase' | 'Kebab-Case' |
| `SnakeCase` | O/E | Inserts a '_' before every capital char. | 'SnakeCase' | 'Snake_Case' |
| `SpaceCase` | O/E | Inserts a ' ' before every capital char. | 'SpaceCase' | 'Space Case' |
| `Humanized` | O/E | Separates words and lowers every capital. | 'HumanizedCase' | 'Humanized case' |
| `NumericValue` | E | Decimal value as string | `Option1 = 1` | '1' |
| `HexValue` | E | Hexadecimal value as string | `Option1 = 1` | '0x1' |
| `HexValue2` | E | Hexadecimal value as string | `Option1 = 1` | '0x01' |
| `HexValue4` | E | Hexadecimal value as string | `Option1 = 1` | '0x0001' |
| `HexValue8` | E | Hexadecimal value as string | `Option1 = 1` | '0x00000001' |

### Code Attribute Enum-Formatters

When the specific Attribute is not found on the Enum-option, it's default `ToString()` value is returned.

| Formatter Type | Attribute | Description | Example | Result |
|----------------|-----------|-------------|---------|--------|
| `Description` | `System.ComponentModel.DescriptionAttribute` | Returns the `Description` of the attribute. | `[Description("This description")]` | 'This Description' |
| `Display` | `System.ComponentModel.DataAnnotations.DisplayAttribute` | Returns either the Description, Name, ShortName or GroupName of the attribute* | `[Display(Name="MyName")]` | 'MyName' |
| `DefaultValue` | `System.ComponentModel.DefaultValueAttribute` | Retrieves the value from the attribute and uses its string representation. | `[DefaultValue(42)]` | '42' |
| `NameOf<T>` | `T` | Uses Reflection on the Attribute `T` and retrieves the Name property. | `[SomeAttribute(Name="MyName")]` | 'MyName' |
| `DescriptionOf<T>` | `T` | Uses Reflection on the Attribute `T` and retrieves the Description property. | `[SomeAttribute(Description="This description")]` | 'This description' |

*) To-Be-Determined how to format the string if multiple fields are filled.

Note that `NameOf<T>` and `DescriptionOf<T>` use reflection and will perform less good.
