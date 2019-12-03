---
title: Platform Invoke (P/Invoke)
description: Learn how to call native functions via P/Invoke in .NET.
author: jkoritzinsky
ms.author: jekoritz
ms.date: 01/18/2019
---

# Platform Invoke (P/Invoke)

P/Invoke is a technology that allows you to access structs, callbacks, and functions in unmanaged libraries from your managed code. Most of the P/Invoke API is contained in two namespaces: `System` and `System.Runtime.InteropServices`. Using these two namespaces give you the tools to describe how you want to communicate with the native component.

Let’s start from the most common example, and that is calling unmanaged functions in your managed code. Let’s show a message box from a command-line application:

[!code-csharp[MessageBox](~/samples/snippets/standard/interop/pinvoke/messagebox.cs)]

The previous example is simple, but it does show off what's needed to invoke unmanaged functions from managed code. Let’s step through the example:

- Line #1 shows the using statement for the `System.Runtime.InteropServices` namespace that holds all the items needed.
- Line #7 introduces the `DllImport` attribute. This attribute is crucial, as it tells the runtime that it should load the unmanaged DLL. The string passed in is the DLL our target function is in. Additionally, it specifies which [character set](./charset.md) to use for marshalling the strings. Finally, it specifies that this function calls [SetLastError](/windows/desktop/api/errhandlingapi/nf-errhandlingapi-setlasterror) and that the runtime should capture that error code so the user can retrieve it via <xref:System.Runtime.InteropServices.Marshal.GetLastWin32Error?displayProperty=nameWithType>.
- Line #8 is the crux of the P/Invoke work. It defines a managed method that has the **exact same signature** as the unmanaged one. The declaration has a new keyword that you can notice, `extern`, which tells the runtime this is an external method, and that when you invoke it, the runtime should find it in the DLL specified in `DllImport` attribute.

The rest of the example is just invoking the method as you would any other managed method.

The sample is similar for macOS. The name of the library in the `DllImport` attribute needs to change since macOS has a different scheme of naming dynamic libraries. The following sample uses the `getpid(2)` function to get the process ID of the application and print it out to the console:

[!code-csharp[getpid macOS](~/samples/snippets/standard/interop/pinvoke/getpid-macos.cs)]

It is also similar on Linux. The function name is the same, since `getpid(2)` is a standard [POSIX](https://en.wikipedia.org/wiki/POSIX) system call.

[!code-csharp[getpid Linux](~/samples/snippets/standard/interop/pinvoke/getpid-linux.cs)]

## Invoking managed code from unmanaged code

The runtime allows communication to flow in both directions, enabling you to call back into managed code from native functions by using function pointers. The closest thing to a function pointer in managed code is a **delegate**, so this is what is used to allow callbacks from native code into managed code.

The way to use this feature is similar to the managed to native process previously described. For a given callback, you define a delegate that matches the signature and pass that into the external method. The runtime will take care of everything else.

[!code-csharp[EnumWindows](~/samples/snippets/standard/interop/pinvoke/enumwindows.cs)]

Before walking through the example, it's good to review the signatures of the unmanaged functions you need to work with. The function to be called to enumerate all of the windows has the following signature: `BOOL EnumWindows (WNDENUMPROC lpEnumFunc, LPARAM lParam);`

The first parameter is a callback. The said callback has the following signature: `BOOL CALLBACK EnumWindowsProc (HWND hwnd, LPARAM lParam);`

Now, let’s walk through the example:

- Line #9 in the example defines a delegate that matches the signature of the callback from unmanaged code. Notice how the LPARAM and HWND types are represented using `IntPtr` in the managed code.
- Lines #13 and #14 introduce the `EnumWindows` function from the user32.dll library.
- Lines #17 - 20 implement the delegate. For this simple example, we just want to output the handle to the console.
- Finally, in line #24, the external method is called and passed in the delegate.

The Linux and macOS examples are shown below. For them, we use the `ftw` function that can be found in `libc`, the C library. This function is used to traverse directory hierarchies and it takes a pointer to a function as one of its parameters. The said function has the following signature: `int (*fn) (const char *fpath, const struct stat *sb, int typeflag)`.

[!code-csharp[ftw Linux](~/samples/snippets/standard/interop/pinvoke/ftw-linux.cs)]

macOS example uses the same function, and the only difference is the argument to the `DllImport` attribute, as macOS keeps `libc` in a different place.

[!code-csharp[ftw macOS](~/samples/snippets/standard/interop/pinvoke/ftw-macos.cs)]

Both of the previous examples depend on parameters, and in both cases, the parameters are given as managed types. Runtime does the "right thing" and processes these into its equivalents on the other side. Learn about how types are marshaled to native code in our page on [Type marshaling](type-marshaling.md).

## More resources

- [PInvoke.net wiki](https://www.pinvoke.net/) an excellent Wiki with information on common Windows APIs and how to call them.
- [P/Invoke in C++/CLI](/cpp/dotnet/native-and-dotnet-interoperability)
- [Mono documentation on P/Invoke](https://www.mono-project.com/docs/advanced/pinvoke/)
