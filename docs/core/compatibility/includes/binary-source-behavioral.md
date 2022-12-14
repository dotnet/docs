This article categorizes each breaking change as *binary incompatible*, *source incompatible*, or a *behavioral change*:

- **Binary incompatible** - When run against the new runtime or component, existing binaries exhibit breaking behavior changes, such as failure to load or execute, and always require recompilation. For example, removing a method from an API is a binary-incompatible change because it causes a <xref:System.MissingMethodException> to be thrown at run time.

- **Source incompatible** - When recompiled using the new SDK or component or to target the new runtime, existing source code requires source changes. That is, there are new compiler errors or warnings that must be addressed.

- **Behavioral change** - Existing code and binaries may experience different run-time behavior. If the new behavior is undesirable, existing binaries would need to be recompiled.
