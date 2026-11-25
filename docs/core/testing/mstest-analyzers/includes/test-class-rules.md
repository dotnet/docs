The declaring type supplies the test fixture that owns these callbacks:

- Use a `class` so MSTest can associate the callbacks with a test-class hierarchy.
- Use a `public` class, or an `internal` class with `[assembly: DiscoverInternals]`, to meet MSTest's type-discovery contract.
- Use a non-static class for these fixtures. Test methods need a test-class instance, even when a class-level lifecycle callback is static.
- Mark a sealed class with `[TestClass]` or a derived attribute. A sealed class can't supply inherited callbacks to another test class, so it must identify itself as the test container.
