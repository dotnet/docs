# Thread Safety in Regular Expressions

The [Regex](https://dotnet.github.io/api/System.Text.RegularExpressions.Regex.html) class itself is thread safe and immutable (read-only). That is, [Regex](https://dotnet.github.io/api/System.Text.RegularExpressions.Regex.html) objects can be created on any thread and shared between threads; matching methods can be called from any thread and never alter any global state.

However, result objects ([Match](https://dotnet.github.io/api/System.Text.RegularExpressions.Match.html) and [MatchCollection)](https://dotnet.github.io/api/System.Text.RegularExpressions.MatchCollection.html) returned by [Regex](https://dotnet.github.io/api/System.Text.RegularExpressions.Regex.html) should be used on a single thread. Although many of these objects are logically immutable, their implementations could delay computation of some results to improve performance, and as a result, callers must serialize access to them.

If there is a need to share [Regex](https://dotnet.github.io/api/System.Text.RegularExpressions.Regex.html) result objects on multiple threads, these objects can be converted to thread-safe instances by calling their synchronized methods. With the exception of enumerators, all regular expression classes are thread safe or can be converted into thread-safe objects by a synchronized method.

Enumerators are the only exception. An application must serialize calls to collection enumerators. The rule is that if a collection can be enumerated on more than one thread simultaneously, you should synchronize enumerator methods on the root object of the collection traversed by the enumerator.

## See Also

[.NET Core Regular Expressions](../regularexpressions)

