### Include specific API surfaces

You can configure which parts of your codebase to run this rule on, based on their accessibility, by setting the [api_surface](../../code-quality-rule-options.md#api_surface) option. For example, to specify that the rule should run only against the non-public API surface, add the following key-value pair to an *.editorconfig* file in your project:

```ini
dotnet_code_quality.CAXXXX.api_surface = private, internal
```

> [!NOTE]
> Replace the `XXXX` part of `CAXXXX` with the ID of the applicable rule.
