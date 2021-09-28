### ResolveAssemblyReference task now warns of dependencies with the wrong architecture

#### Details

The task emits a warning, MSB3270, which indicates that a reference or any of its dependencies does not match the app's architecture. For example, this occurs if an app that was compiled with the `AnyCPU` option includes an x86 reference. Such a scenario could result in an app failure at run time (in this case, if the app is deployed as an x64 process).

#### Suggestion

There are two areas of impact:

- Recompilation generates warnings that did not appear when the app was compiled under a previous version of MSBuild. However, because the warning identifies a possible source of runtime failure, it should be investigated and addressed.
- If warnings are treated as errors, the app will fail to compile.

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.5.1       |
| Type    | Retargeting |
