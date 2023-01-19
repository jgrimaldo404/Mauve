![Mauve Banner](https://raw.githubusercontent.com/tacosontitan/Mauve/main/.resources/mauve-banner.png "Mauve Banner")

From basic extension methods to complete implementations of design patterns, Mauve offers a colorful suite of functionality for utilization in even the grandest applications.

## What's Changed
* Minor repairs to middleware. by @tacosontitan in https://github.com/tacosontitan/Mauve/pull/114
* Added deprecation notice for Mauve.Framework. by @tacosontitan in https://github.com/tacosontitan/Mauve/pull/116
* Bug fixes, and deprecation efforts. by @tacosontitan in https://github.com/tacosontitan/Mauve/pull/120
* Adds support for IsConcrete. by @tacosontitan in https://github.com/tacosontitan/Mauve/pull/124
* Adds null handling to flatten messages. by @tacosontitan in https://github.com/tacosontitan/Mauve/pull/128

**Full Changelog**: https://github.com/tacosontitan/Mauve/compare/2023.0.0.3...2023.0.0.5

## Mauve.Framework (*Deprecation Notice*)
The `Mauve.Framework` project has officially been deprecated and efforts are being made to mark the project objects as such. The project is targeted to be marked as deprecated by the end of January 2023 and support will end with the 2023 calendar year. We recommend opting for the new `Mauve` project running on `.NET 6.0`, features from `Mauve.Framework` are being evaluated for transfer and will be transfered only if a more production ready replacement is not available (e.g. MediatR and Fluent Validation).

## Features
The following features are available for use through Mauve:

|Feature|Description|
|-|-|
|Serialization|Mauve contains two extension methods for out of the box serialization support using `T.Serialize(SerializationMethod)` and `string.Deserialize(SerializationMethod)`. There is currently support for raw, binary, XML, JSON, and YAML serialization methods.|
|Cryptography|Mauve aims to simplify cryptography implementations for consumers.|
|Validation|Validation should be simple, concise, and encapsulated.|

There are many more features available in the framework of course, but the above are easily the most popular. For more information, see the [wiki](https://github.com/tacosontitan/Mauve/wiki).

## Extension Methods
Mauve offers a variety of useful extension methods for the most common data types in the `C#` language:

 - `int`
 - `string`
 - `DateTime`
 - `Queue`
 - `Type`
 - `Exception`
 - `IComparable`
 - `IEnumerable<T>`

 Additionally, there are a few extension methods using generics for type safety that apply to all types.

*See our [wiki](https://github.com/tacosontitan/Mauve/wiki/Mauve.Extensibility) for more details.*