---
author: tdykstra
ms.author: tdykstra
ms.date: 11/27/2023
ms.topic: include
---
- **`--tl:[auto|on|off]`**

  Specifies whether the *terminal logger* should be used for the build output. The default is `auto`, which first verifies the environment before enabling terminal logging. The environment check verifies that the terminal is capable of using modern output features and isn't using a redirected standard output before enabling the new logger. `on` skips the environment check and enables terminal logging. `off` skips the environment check and uses the default console logger.

  The terminal logger shows you the restore phase followed by the build phase. During each phase, the currently building projects appear at the bottom of the terminal. Each project that's building outputs both the MSBuild target currently being built and the amount of time spent on that target. You can search this information to learn more about the build. When a project is finished building, a single "build completed" section is written that captures:

  - The name of the built project.
  - The target framework (if multi-targeted).
  - The status of that build.
  - The primary output of that build (which is hyperlinked).
  - Any diagnostics generated for that project.

  This option is available starting in .NET 8.
