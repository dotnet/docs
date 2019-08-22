### "C" locale maps to the invariant locale

.NET Core 2.2 and earlier versions depend on the default ICU behavior, which maps the "C" locale to the en_US_POSIX locale. The en_US_POSIX locale has an undesirable collation behavior, because it doesn't support case-insensitive string comparisons. Because some Linux distributions set the "C" locale as the default locale, users were experiencing unexpected behavior. 

#### Details

Starting with .NET Core 3.0, the "C" locale mapping has changed to use the Invariant locale instead of en_US_POSIX. The "C" locale to Invariant mapping is also applied to Windows for consistency.

Mapping "C" to en_US_POSIX culture caused customer confusion, because en_US_POSIX doesn't support case insensitive sorting/searching string operations. Because the "C" locale is used as a default locale in some of the Linux distros, customers experienced this undesired behavior on these operating systems. 

#### Version introduced

.NET Core 3.0

### Recommended action

Nothing specific more than the awareness of this change. This change only applications that use the "C" locale mapping.


### Category

- Globalization 

### Affected APIs

All collation and culture APIs is affected by this change.

<!--

-->