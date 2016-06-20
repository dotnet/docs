# .NET Core Application Deployment #

You can deploy your .NET Core app in either of two ways:

- As a portable app. A portable app relies on a shared system-wide version of the .NET Core framework that is present on a system.
 
- As a self-contained application. All components, including .NET Core itself, are included with the application and are isolated from other .NET Core applications. 

# Portable Applications #

For a portable app, you deploy only your app and any third-party dependencies. You do not have to deploy .NET Core, since your app will use the version of .NET Core that's present on the target system. This is the default deployment model for .NET Core apps.

## Why Deploy a Portable App? ##

Deploying a portable app has a number of advantages:

- You do not have to define the target operating systems that your .NET Core app will run on in advance. Because .NET Core uses a common PE file format for executables and libraries regardless of operating system, .NET Core can execute your app regardless of the underlying operating system.

- The size of your deployment package is small. You only have to deploy your app and its dependencies, not .NET Core itself.

- Multiple apps use the same .NET Core installation, which reduces both disk space and memory usage on host systems.

There are also a few disadvantages:

- Your app can run only if the version of .NET Core that you target, or a later version, is already installed on the host system. 

- It is possible for the .NET Core runtime and libraries to change without your knowledge. In rare cases, this may change the behavior of your app.

## Deploying a Simple Portable App ##

Deploying a portable app with no third-party dependencies simply involves building, testing, and publishing the app. 
A simple example written in C# illustrates the process. The example uses the dotnet utility from the command line; however, 
you can also use a development environment, such as Visual Studio or Visual Studio Code, to compile, test, and publish the example.

1. Create a directory for your project, and from the command line, type `dotnet new` to create a new C# console project. 

2. Open the `Program.cs` file in an editor, and replace the auto-generated code with the following code. It prompts the user to enter text, and then displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

    ```cs
    using System;
    using System.Text.RegularExpressions;

    namespace Applications.ConsoleApps
    {
        public class ConsoleParser
        {
            public static void Main()
            {
                 Console.WriteLine("Enter any text, followed by <Enter>:\n");
                 String s = Console.ReadLine();
                 ShowWords(s);
                 Console.Write("\nPress any key to continue... ");
                 Console.ReadKey();
          }

          private static void ShowWords(String s)
          {
              String pattern = @"\w+";
              var matches = Regex.Matches(s, pattern);
              if (matches.Count == 0)
                  Console.WriteLine("\nNo words were identified in your input.");
              else {
                  Console.WriteLine("\nThere are {0} words in your string:", matches.Count);
                  for (int ctr = 0; ctr < matches.Count; ctr++)
                      Console.WriteLine("   #{0,2}: '{1}' at position {2}", ctr,
                                        matches[ctr].Value, matches[ctr].Index);
              }
          } 
      }
    }
    ```

3. Run the `dotnet restore` command to restore the dependencies specified in your project.

4. Create a debug build of your app by using the `dotnet build` command.

5. After you've debugged and tested the program, you can create the files to be deployed with your app by using the `dotnet publish -c release` command. This creates a release (rather than a debug) version of your app.

   The resulting files are placed in a directory named `publish` that is in a subdirectory of your project's
`.\bin\release\netcoreapp1.0` subdirectory.

6. Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. You should not package it with your application's files.

The remaining files can be deployed in any way you'd like. For example, you can package them in a zip file, use a simple `copy` command, or deploy them with any installation package of your choice.

## Deploying a Portable App with Third-Party Dependencies ##

Deploying a portable app with one or more third-party dependencies involves two additional steps before you can run the `dotnet restore` command:

1. Add references to any third-party libraries to the `dependencies` section of your `project.json` file. The following  `dependencies` section uses Json.NET as a third-party library.


    ```
    "dependencies": {
      "Microsoft.NETCore.App": {
        "type": "platform",
        "version": "1.0.0"
      },
      "Newtonsoft.Json": "8.0.3"
    },
    ```

2. Ensure that you have installed the NuGet package that contains the third-party dependency, since third-party dependencies are resolved from your local NuGet cache.

Note that a portable app with third-party dependencies will only be as portable as its third-party dependencies. For example, if a third-party library only supports OSX, the app will not be portable to Windows systems.

When you deploy your application, any third-party dependencies used in your app are resolved from the local NuGet cache of the system on which your app is running. In other words, the third-party library must be present on the target machine for your app to run successfully.

# Self-Contained Applications #

For a self-contained app, you deploy not only your app and any third-party dependencies, but the version of .NET Core that you build your app with.

## Why Deploy a Self-Contained App? ##

Deploying a self-contained app has two major advantages:

- You have sole control of the version of .NET Core that is deployed with your app. .NET Core can be serviced only by you.

- You can be assured that the target system can run your .NET Core app, since you're providing the version of .NET Core that it will run on.

It also has a number of disadvantages:

- Because .NET Core is included in your deployment package, you must select the target platforms for which you build deployment packages in advance.

- The size of your deployment package is relatively large, since you have to include .NET Core as well as your app and its third-party dependencies.

- Deploying numerous self-contained .NET Core apps to a system can consume significant amounts of disk space, since each app duplicates .NET Core files.

## Deploying a Simple Self-Contained App ## 

Deploying a self-contained app with no third-party dependencies involves creating the project, modifying the project.json file, building, testing, and publishing the app.  A simple example written in C# illustrates the process. The example uses the dotnet utility from the command line; however, you can also use a development environment, such as Visual Studio or Visual Studio Code, to compile, test, and publish the example.

1. Create a directory for your project, and from the command line, type `dotnet new` to create a new C# console project.

2. Open the `Program.cs` file in an editor, and replace the auto-generated code with the following code. It prompts the user to enter text, and then displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

    ```cs
    using System;
    using System.Text.RegularExpressions;

    namespace Applications.ConsoleApps
    {
        public class ConsoleParser
        {
            public static void Main()
            {
                 Console.WriteLine("Enter any text, followed by <Enter>:\n");
                 String s = Console.ReadLine();
                 ShowWords(s);
                 Console.Write("\nPress any key to continue... ");
                 Console.ReadKey();
          }

          private static void ShowWords(String s)
          {
              String pattern = @"\w+";
              var matches = Regex.Matches(s, pattern);
              if (matches.Count == 0)
                  Console.WriteLine("\nNo words were identified in your input.");
              else {
                  Console.WriteLine("\nThere are {0} words in your string:", matches.Count);
                  for (int ctr = 0; ctr < matches.Count; ctr++)
                      Console.WriteLine("   #{0,2}: '{1}' at position {2}", ctr,
                                        matches[ctr].Value, matches[ctr].Index);
              }
          } 
      }
    }
    ```

3. Open the `project.json` file. Remove the following line in in the `dependencies` section:

    ```project.json
    "type": "platform",
    ```

4. Create a `runtimes` section in your `project.json` file that defines the platforms your app targets and specify the runtime identifier of each platform that you target. See [Runtime IDentifier catalog](https://dotnet.github.io/docs/core-concepts/rid-catalog.html "Runtime IDentifier (RID) catalog") for a list of runtime identifiers. For example, the following `runtimes` section indicates that the app runs on 64-bit Windows 10 operating systems and the 64-bit OSX Version 10.10 operating system.

    ```project.json
        "runtimes": {
        "win10-x64": {},
        "osx.10.10-x64": {}
        }
    ```
Note that you also need to add a comma to separate the `runtimes` section from the previous section.
A complete sample `project.json` file appears later in this section.

5. Run the `dotnet restore` command to restore the dependencies specified in your project.

6. Create debug builds of your app on each of the target platforms by using the `dotnet build -r` command and specifying the runtime directive of the platform. In our example, we would run two separate builds as follows:

    ```project.json
    dotnet build -r win10-x64
    dotnet build -r osx.10.10-x64
    ```

7. After you've debugged and tested the program, you can create the files to be deployed with your app for each platform that it targets. To do this, use the `dotnet publish -c release -r` command. This creates a release (rather than a debug) version of your app for each target platform. In our example, we would publish our project for two separate platforms as follows:

    ```project.json
    dotnet publish -c release -r win10-x64
    dotnet publish -c release -r osx.10.10-x64
    ```
   The resulting files are placed in a subdirectory named `publish` that is in a subdirectory of your project's `.\bin\release\netcoreapp1.0\<runtime_identifier>` subdirectory. Note that each subdirectory contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

8. Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. You should not package it with your application's files.

The remaining files can be deployed in any way you'd like. For example, you can package them in a zip file, use a simple `copy` command, or deploy them with any installation package of your choice.

The following is the complete `project.json` file for this project.

```project.json
    {
      "version": "1.0.0-*",
      "buildOptions": {
        "emitEntryPoint": true
      },
      "dependencies": {
        "Microsoft.NETCore.App": {
          "version": "1.0.0"
        }
      },
      "frameworks": {
        "netcoreapp1.0": {
          "imports": "dnxcore50"
        }
      },
      "runtimes": {
        "win10-x64": {},
        "osx.10.10-x64": {}
      }
    }
```

## Deploying a Self-Contained App with Third-Party Dependencies ##

Deploying a self-contained app with one or more third-party dependencies involves two additional steps before you can run the `dotnet restore` command:

1. Add references to any third-party libraries to the `dependencies` section of your `project.json` file. The following  `dependencies` section uses Json.NET as a third-party library.

    ```project.json
    "dependencies": {
      "Microsoft.NETCore.App": {
        "type": "platform",
        "version": "1.0.0"
      },
      "Newtonsoft.Json": "8.0.3"
    },
    ```

2. Ensure that you have installed the NuGet package that contains the third-party dependency, since third-party dependencies are resolved from your local NuGet cache.

When you deploy your application, any third-party dependencies used in your app are also contained with your application files.
Third-party libraries do not already have to be present on the system on which the app is running.

Note that you can only deploy a self-contained app with a third-party library to platforms supported by that library.
