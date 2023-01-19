![Mauve Banner](/.resources/mauve-banner.png "Mauve Banner")

From basic extension methods to complete implementations of design patterns, Mauve offers a colorful suite of functionality for utilization in even the grandest applications.

<sub>***Note**: Our chosen shade of mauve has a hexadecimal color code of `0xe0b0ff`.*</sub>

## Extension Methods
Mauve offers a variety of useful extension methods for the most common data types in the `C#` language:

 - `int`
 - `string`
 - `DateTime`
 - `Exception`
 - `IComparable`
 - `IEnumerable<T>`

 Additionally, there are a few extension methods using generics for type safety that apply to all types.

*See our [wiki](https://github.com/tacosontitan/Mauve/wiki/Mauve.Extensibility) for more details.*

## Mauve.Framework (*Deprecation Notice*)
The `Mauve.Framework` project has officially been deprecated and efforts are being made to mark the project objects as such. The project is targeted to be marked as deprecated by the end of January 2023 and support will end with the 2023 calendar year. We recommend opting for the new `Mauve` project running on `.NET 6.0`, features from `Mauve.Framework` are being evaluated for transfer and will be transfered only if a more production ready replacement is not available (e.g. MediatR and Fluent Validation).

## Release Notes
Here you can find the most recent release notes for each Mauve product.

### Latest Release (2023.0.0.5)
* Minor repairs to middleware. by @tacosontitan in https://github.com/tacosontitan/Mauve/pull/114
* Added deprecation notice for Mauve.Framework. by @tacosontitan in https://github.com/tacosontitan/Mauve/pull/116
* Bug fixes, and deprecation efforts. by @tacosontitan in https://github.com/tacosontitan/Mauve/pull/120
* Adds support for IsConcrete. by @tacosontitan in https://github.com/tacosontitan/Mauve/pull/124
* Adds null handling to flatten messages. by @tacosontitan in https://github.com/tacosontitan/Mauve/pull/128

**Full Changelog**: https://github.com/tacosontitan/Mauve/compare/2023.0.0.3...2023.0.0.5