---
title: Native interoperability
description: Learn how to interface with native components in .NET.
keywords: .NET, .NET Core
author: blackdwarf
ms.author: ronpet
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 3c357112-35fb-44ba-a07b-6a1c140370ac
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Native Interoperability

In this document, we will dive a little bit deeper into all three ways of doing "native interoperability" that are available using .NET.

There are a few of reasons why you would want to call into native code:

*   Operating Systems come with a large volume of APIs that are not present in the managed class libraries. A prime example for this would be access to hardware or operating system management functions.
*   Communicating with other components that have or can produce C-style ABIs (native ABIs). This covers, for example, Java code that is exposed via [Java Native Interface (JNI)](https://docs.oracle.com/javase/8/docs/technotes/guides/jni/) or any other managed language that could produce a native component.
*   On Windows, most of the software that gets installed, such as Microsoft Office suite, registers COM components that represent their programs and allow developers to automate them or use them. This also requires native interoperability.

Of course, the list above does not cover all of the potential situations and scenarios in which the developer would want/like/need to interface with native components. .NET class library, for instance, uses the native interoperability support to implement a fair number of its APIs, like console support and manipulation, file system access and others. However, it is important to note that there is an option, should one need it.

> [!NOTE]
> Most of the examples in this document will be presented for all three supported platforms for .NET Core (Windows, Linux and macOS). However, for some short and illustrative examples, just one sample is shown that uses Windows filenames and extensions (that is, "dll" for libraries). This does not mean that those features are not available on Linux or macOS, it was done merely for convenience sake.

## Platform Invoke (P/Invoke)

P/Invoke is a technology that allows you to access structs, callbacks and functions in unmanaged libraries from your managed code. Most of the P/Invoke API is contained in two namespaces: `System` and `System.Runtime.InteropServices`. Using these two namespaces will allow you access to the attributes that describe how you want to communicate with the native component.

Let’s start from the most common example, and that is calling unmanaged functions in your managed code. Let’s show a message box from a command-line application:

```csharp
using System.Runtime.InteropServices;

public class Program {

    // Import user32.dll (containing the function we need) and define
    // the method corresponding to the native function.
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);

    public static void Main(string[] args) {
        // Invoke the function as a regular managed method.
        MessageBox(IntPtr.Zero, "Command-line message box", "Attention!", 0);
    }
}
```

The example above is pretty simple, but it does show off what is needed to invoke unmanaged functions from managed code. Let’s step through the example:

*   Line #1 shows the using statement for the `System.Runtime.InteropServices` which is the namespace that holds all of the items we need.
*   Line #5 introduces the `DllImport` attribute. This attribute is crucial, as it tells the runtime that it should load the unmanaged DLL. This is the DLL into which we wish to invoke.
*   Line #6 is the crux of the P/Invoke work. It defines a managed method that has the **exact same signature** as the unmanaged one. The declaration has a new keyword that you can notice, `extern`, which tells the runtime this is an external method, and that when you invoke it, the runtime should find it in the DLL specified in `DllImport` attribute.

The rest of the example is just invoking the method as you would any other managed method.

The sample is similar for macOS. One thing that needs to change is, of course, the name of the library in the `DllImport` attribute, as macOS has a different scheme of naming dynamic libraries. The sample below uses the `getpid(2)` function to get the process ID of the application and print it out to the console.

```csharp
using System;
using System.Runtime.InteropServices;

namespace PInvokeSamples {
    public static class Program {

        // Import the libSystem shared library and define the method corresponding to the native function.
        [DllImport("libSystem.dylib")]
        private static extern int getpid();

        public static void Main(string[] args){
            // Invoke the function and get the process ID.
            int pid = getpid();
            Console.WriteLine(pid);
        }
    }
}
```

It is also similar on Linux. The function name is the same, since `getpid(2)` is a standard [POSIX](https://en.wikipedia.org/wiki/POSIX) system call.

```csharp
using System;
using System.Runtime.InteropServices;

namespace PInvokeSamples {
    public static class Program {

        // Import the libc shared library and define the method corresponding to the native function.
        [DllImport("libc.so.6")]
        private static extern int getpid();

        public static void Main(string[] args){
            // Invoke the function and get the process ID.
            int pid = getpid();
            Console.WriteLine(pid);
        }
    }
}
```

### Invoking managed code from unmanaged code

Of course, the runtime allows communication to flow both ways which enables you to call into managed artifacts from native functions, using function pointers. The closest thing to a function pointer in managed code is a **delegate**, so this is what is used to allow callbacks from native code into managed code.

The way to use this feature is similar to managed to native process described above. For a given callback, you define a delegate that matches the signature, and pass that into the external method. The runtime will take care of everything else.

```csharp
using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication1 {

    class Program {

        // Define a delegate that corresponds to the unmanaged function.
        delegate bool EnumWC(IntPtr hwnd, IntPtr lParam);

        // Import user32.dll (containing the function we need) and define
        // the method corresponding to the native function.
        [DllImport("user32.dll")]
        static extern int EnumWindows(EnumWC lpEnumFunc, IntPtr lParam);

        // Define the implementation of the delegate; here, we simply output the window handle.
        static bool OutputWindow(IntPtr hwnd, IntPtr lParam) {
            Console.WriteLine(hwnd.ToInt64());
            return true;
        }

        static void Main(string[] args) {
            // Invoke the method; note the delegate as a first parameter.
            EnumWindows(OutputWindow, IntPtr.Zero);
        }
    }
}
```

Before we walk through our example, it is good to go over the signatures of the unmanaged functions we need to work with. The function we want to call to enumerate all of the windows has the following signature: `BOOL EnumWindows (WNDENUMPROC lpEnumFunc, LPARAM lParam);`

The first parameter is a callback. The said callback has the following signature: `BOOL CALLBACK EnumWindowsProc (HWND hwnd, LPARAM lParam);`

With this in mind, let’s walk through the example:

*   Line #8 in the example defines a delegate that matches the signature of the callback from unmanaged code. Notice how the LPARAM and HWND types are represented using `IntPtr` in the managed code.
*   Lines #10 and #11 introduce the `EnumWindows` function from the user32.dll library.
*   Lines #13 - 16 implement the delegate. For this simple example, we just want to output the handle to the console.
*   Finally, in line #19 we invoke the external method and pass in the delegate.

The Linux and macOS examples are shown below. For them, we use the `ftw` function that can be found in `libc`, the C library. This function is used to traverse directory hierarchies and it takes a pointer to a function as one of its parameters. The said function has the following signature: `int (*fn) (const char *fpath, const struct stat *sb, int typeflag)`.

```csharp
using System;
using System.Runtime.InteropServices;

namespace PInvokeSamples {
    public static class Program {

            // Define a delegate that has the same signature as the native function.
            delegate int DirClbk(string fName, StatClass stat, int typeFlag);

            // Import the libc and define the method to represent the native function.
            [DllImport("libc.so.6")]
            static extern int ftw(string dirpath, DirClbk cl, int descriptors);

            // Implement the above DirClbk delegate;
            // this one just prints out the filename that is passed to it.
            static int DisplayEntry(string fName, StatClass stat, int typeFlag) {
                    Console.WriteLine(fName);
                    return 0;
            }

            public static void Main(string[] args){
                    // Call the native function.
                    // Note the second parameter which represents the delegate (callback).
                    ftw(".", DisplayEntry, 10);
            }
    }

    // The native callback takes a pointer to a struct. The below class
    // represents that struct in managed code. You can find more information
    // about this in the section on marshalling below.
    [StructLayout(LayoutKind.Sequential)]
    public class StatClass {
            public uint DeviceID;
            public uint InodeNumber;
            public uint Mode;
            public uint HardLinks;
            public uint UserID;
            public uint GroupID;
            public uint SpecialDeviceID;
            public ulong Size;
            public ulong BlockSize;
            public uint Blocks;
            public long TimeLastAccess;
            public long TimeLastModification;
            public long TimeLastStatusChange;
    }
}
```

macOS example uses the same function, and the only difference is the argument to the `DllImport` attribute, as macOS keeps `libc` in a different place.

```csharp
using System;
using System.Runtime.InteropServices;

namespace PInvokeSamples {
        public static class Program {

                // Define a delegate that has the same signature as the native function.
                delegate int DirClbk(string fName, StatClass stat, int typeFlag);

                // Import the libc and define the method to represent the native function.
                [DllImport("libSystem.dylib")]
                static extern int ftw(string dirpath, DirClbk cl, int descriptors);

                // Implement the above DirClbk delegate;
                // this one just prints out the filename that is passed to it.
                static int DisplayEntry(string fName, StatClass stat, int typeFlag) {
                        Console.WriteLine(fName);
                        return 0;
                }

                public static void Main(string[] args){
                        // Call the native function.
                        // Note the second parameter which represents the delegate (callback).
                        ftw(".", DisplayEntry, 10);
                }
        }

        // The native callback takes a pointer to a struct. The below class
        // represents that struct in managed code. You can find more information
        // about this in the section on marshalling below.
        [StructLayout(LayoutKind.Sequential)]
        public class StatClass {
                public uint DeviceID;
                public uint InodeNumber;
                public uint Mode;
                public uint HardLinks;
                public uint UserID;
                public uint GroupID;
                public uint SpecialDeviceID;
                public ulong Size;
                public ulong BlockSize;
                public uint Blocks;
                public long TimeLastAccess;
                public long TimeLastModification;
                public long TimeLastStatusChange;
        }
}
```

Both of the above examples depend on parameters, and in both cases, the parameters are given as managed types. Runtime does the "right thing" and processes these into its equivalents on the other side. Since this process is really important to writing quality native interop code, let’s take a look at what happens when the runtime _marshals_ the types.

## Type marshalling

**Marshalling** is the process of transforming types when they need to cross the managed boundary into native and vice versa.

The reason marshalling is needed is because the types in the managed and unmanaged code are different. In managed code, for instance, you have a `String`, while in the unmanaged world strings can be Unicode ("wide"), non-Unicode, null-terminated, ASCII, etc. By default, the P/Invoke subsystem will try to do the Right Thing based on the default behavior which you can see on [MSDN](../../docs/framework/interop/default-marshaling-behavior.md). However, for those situations where you need extra control, you can employ the `MarshalAs` attribute to specify what is the expected type on the unmanaged side. For instance, if we want the string to be sent as a null-terminated ANSI string, we could do it like this:

```csharp
[DllImport("somenativelibrary.dll")]
static extern int MethodA([MarshalAs(UnmanagedType.LPStr)] string parameter);
```

### Marshalling classes and structs

Another aspect of type marshalling is how to pass in a struct to an unmanaged method. For instance, some of the unmanaged methods require a struct as a parameter. In these cases, we need to create a corresponding struct or a class in managed part of the world to use it as a parameter. However, just defining the class is not enough, we also need to instruct the marshaler how to map fields in the class to the unmanaged struct. This is where the `StructLayout` attribute comes into play.

```csharp
[DllImport("kernel32.dll")]
static extern void GetSystemTime(SystemTime systemTime);

[StructLayout(LayoutKind.Sequential)]
class SystemTime {
    public ushort Year;
    public ushort Month;
    public ushort DayOfWeek;
    public ushort Day;
    public ushort Hour;
    public ushort Minute;
    public ushort Second;
    public ushort Milsecond;
}

public static void Main(string[] args) {
    SystemTime st = new SystemTime();
    GetSystemTime(st);
    Console.WriteLine(st.Year);
}
```

The example above shows off a simple example of calling into `GetSystemTime()` function. The interesting bit is on line 4. The attribute specifies that the fields of the class should be mapped sequentially to the struct on the other (unmanaged) side. This means that the naming of the fields is not important, only their order is important, as it needs to correspond to the unmanaged struct, shown below:

```c
typedef struct _SYSTEMTIME {
  WORD wYear;
  WORD wMonth;
  WORD wDayOfWeek;
  WORD wDay;
  WORD wHour;
  WORD wMinute;
  WORD wSecond;
  WORD wMilliseconds;
} SYSTEMTIME, *PSYSTEMTIME*;
```

We already saw the Linux and macOS example for this in the previous example. It is shown again below.

```csharp
[StructLayout(LayoutKind.Sequential)]
public class StatClass {
        public uint DeviceID;
        public uint InodeNumber;
        public uint Mode;
        public uint HardLinks;
        public uint UserID;
        public uint GroupID;
        public uint SpecialDeviceID;
        public ulong Size;
        public ulong BlockSize;
        public uint Blocks;
        public long TimeLastAccess;
        public long TimeLastModification;
        public long TimeLastStatusChange;
}
```

The `StatClass` class represents a structure that is returned by the `stat` system call on UNIX systems. It represents information about a given file. The class above is the stat struct representation in managed code. Again, the fields in the class have to be in the same order as the native struct (you can find these by perusing man pages on your favorite UNIX implementation) and they have to be of the same underlying type.

## More resources

*   [PInvoke.net wiki](https://www.pinvoke.net/) an excellent Wiki with information on common Win32 APIs and how to call them.
*   [P/Invoke on MSDN](https://msdn.microsoft.com/library/zbz07712.aspx)
*   [Mono documentation on P/Invoke](https://www.mono-project.com/docs/advanced/pinvoke/)
