Installing .NET Core on Windows
===============================
By `Zlatko Knezevic`_

This document will lead you through acquiring the .NET Core DNX SDK via the `.NET Version Manager (DNVM) <https://github.com/aspnet/dnvm>`_ and running a "Hello World" demo on Windows.

.NET Core NuGet packages and the .NET Core DNX SDKs are available on the `ASP.NET 'vnext' myget feed <https://www.myget.org/F/aspnetvnext>`__, which you can more easily view on `gallery <https://www.myget.org/gallery/aspnetvnext>`__ for the feed.

Installing DNVM
---------------

You need DNVM as a starting point. DNVM enables you to acquire one or
multiple .NET Execution Environments (DNX). DNVM is simply a script,
which doesn't depend on .NET. You can install it via a PowerShell
command from a command prompt window. You can find alternate DNVM install instructions at the
`ASP.NET Home repo <https://github.com/aspnet/home>`__.

.. code-block:: console

    @powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"

The script will set several global environment variables to make using DNVM easier in the future. In order for these to kick in, you need to restart your command shell session.

Installing a .NET Core DNX
--------------------------

It's easy to install the latest .NET Core-based DNX, using the ``dnvm install`` command.

.. code-block:: console

    dnvm install -r coreclr latest -u

This will install the 32-bit version of .NET Core. If you want the 64-bit version, you can specify processor architecture.

.. code-block:: console

    dnvm install -r coreclr -arch x64 latest -u

You can see the currently installed DNX versions with ``dnvm list``.

.. code-block:: console

    dnvm list

     Active Version           Runtime Architecture Location                            Alias
     ------ -------           ------- ------------ --------                            -----
       *    1.0.0-beta5-11649 coreclr x64          C:\Users\[user]\.dnx\runtimes
            1.0.0-beta5-11649 coreclr x86          C:\Users\[user]\.dnx\runtimes       default


.. note::
    The version numbers above can and will change when you run the commands, which is normal. Don't forget to use the proper numbers when further interacting with DNVM in the below samples.

Using a specific runtime
------------------------

You can choose which of the installed DNXs you want to use with ``dnvm use``, specifying arguments that are similar to the ones used when installing a runtime.

.. code-block:: console

    dnvm use -r coreclr -arch x86 1.0.0-beta5-11649
    Adding C:\Users\[user]\.dnx\runtimes\dnx-coreclr-win-x86.1.0.0-beta5-11649\bin
    to process PATH

    dnvm list

    Active Version           Runtime Architecture Location                            Alias
    ------ -------           ------- ------------ --------                            -----
           1.0.0-beta5-11649 coreclr x64          C:\Users\[user]\.dnx\runtimes
      *    1.0.0-beta5-11649 coreclr x86          C:\Users\[user]\.dnx\runtimes       default

See the asterisk in the listing above? It's purpose is to tell you which runtime is now active. "Active" here means that all of the interaction with your projects and .NET Core will use this runtime.

That's it! You now have the .NET Core runtime installed on your machine and it is time to take it for a spin.

Write your App
--------------

This being an introduction-level document, it seems fitting to start with a "Hello World" app.  Here's a very simple one you can copy and paste into a CS file in a directory.

.. code-block:: c#

    using System;

    public class Program
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("Hello, Windows");
            Console.WriteLine("Love from CoreCLR.");
        }
    }

A more ambitious example is available on the `corefxlab repo <https://www.github.com/dotnet/corefxlab/>`_ that will print out a pretty picture based on the argument you provide at runtime. If you wish to use this example, simply save the `C# file <https://raw.githubusercontent.com/dotnet/corefxlab/master/demos/CoreClrConsoleApplications/HelloWorld/HelloWorld.cs>`_ to a directory somewhere on your machine.

The next thing you will need is a ``project.json`` file that will outline the dependencies of an app, so you can **actually** run it. Use the contents below, it will work for both examples above. Save this file in a directory next to the CS file that contains your code.

.. code-block:: c#

    {
        "version": "1.0.0-*",
        "dependencies": {
        },
        "frameworks" : {
            "dnx451" : { },
            "dnxcore50" : {
                "dependencies": {
                    "System.Console": "4.0.0-beta-*"
                }
            }
        }
    }

Run your App
------------

You need to restore packages for your app, based on your project.json,
with ``dnu restore``.

.. code-block:: console

    dnu restore

You can run your app with the DNX command.

.. code-block:: console

    dnx run

This will instruct the currently active DNX to run your app. Note that you didn't need to actually build the code; DNX will take care of this for you.

Building .NET Core from source
------------------------------
.NET Core is an open source project that is hosted on GitHub. This means that you can, at any given time, clone the repository and build .NET Core from source. This is a more advanced scenario that is usually used when you want to add features to the .NET runtime or the BCL or if you are a contributor to these projects. The detailed instruction on how to build .NET Core windows can be found in the `.NET Core Windows build instructions <https://github.com/dotnet/coreclr/blob/master/Documentation/building/windows-instructions.md>`_ on GitHub.
