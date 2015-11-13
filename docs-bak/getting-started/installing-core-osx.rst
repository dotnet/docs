Installing .NET Core on OS X
==============================
By `Zlatko Knezevic`_

These instructions will lead you through acquiring the .NET Core DNX SDK
via the `.NET Version Manager (DNVM) <https://github.com/aspnet/dnvm>`__
and running a "Hello World" demo on OS X.

.NET Core NuGet packages and the .NET Core DNX SDKs are available on the
`ASP.NET 'vnext' myget feed <https://www.myget.org/F/aspnetvnext>`__,
which you can more easily view on
`gallery <https://www.myget.org/gallery/aspnetvnext>`__ for the feed.


Installing DNVM
---------------

You need DNVM as a starting point. DNVM enables you to acquire one or
multiple .NET Execution Environments (DNX). DNVM is simply a script,
which doesn't depend on .NET. On OS X the best way to get DNVM is to use `Homebrew <http://www.brew.sh>`__. If
you don't have Homebrew installed then follow the `Homebrew installation
instructions <http://www.brew.sh>`__. Once you have Homebrew up and running you can use the the following commands:

.. code-block:: console

    brew tap aspnet/dnx
    brew update
    brew install dnvm

You will likely need to register the dnvm command:

.. code-block:: console

    source dnvm.sh

Installing the .NET Core DNX
----------------------------

Since .NET Core is still a work in progress, you will need to make use of `Mono <http://www.mono-project.com>`_ to run certain parts of the DNX tooling. On non-Windows operating systems, Mono is the default DNX, so you can use a simple ``dnvm upgrade`` command to install it.

.. code-block:: console

    dnvm upgrade -u

Next, acquire the .NET Core DNX SDK.

.. code-block:: console

    dnvm install latest -r coreclr -u

You can see the currently installed DNX versions with ``dnvm list``.

.. code-block:: console

    dnvm list

.. code-block:: console

    Active Version              Runtime Arch Location             Alias
    ------ -------              ------- ---- --------             -----
      *    1.0.0-beta5-11649    coreclr x64  ~/.dnx/runtimes
           1.0.0-beta5-11649    mono         ~/.dnx/runtimes      default

.. note::
    The version numbers above can and will change when you run the commands, which is normal. Don't forget to use the proper numbers when further interacting with DNVM in the below samples.

Using a specific runtime
------------------------

You can choose which of the installed DNXs you want to use with ``dnvm use``, specifying arguments that are similar to the ones used when installing a runtime.

.. code-block:: console

    dnvm use -r coreclr -arch x64 1.0.0-beta5-11649
    Adding ~/.dnx/runtimes/dnx-coreclr-win-x86.1.0.0-beta5-11649/bin
    to process PATH

    dnvm list

    Active Version              Runtime Arch Location             Alias
    ------ -------              ------- ---- --------             -----
      *    1.0.0-beta5-11649    coreclr x64  ~/.dnx/runtimes
           1.0.0-beta5-11649    mono         ~/.dnx/runtimes      default

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
            Console.WriteLine("Hello, OS X");
            Console.WriteLine("Love from CoreCLR.");
        }
    }

A more ambitious example is available on the `corefxlab repo <https://www.github.com/dotnet/corefxlab/>`_ that will print out a pretty picture based on the argument you provide at runtime. If you wish to use this example, simply save the `C# file <https://raw.githubusercontent.com/dotnet/corefxlab/master/demos/CoreClrConsoleApplications/HelloWorld/HelloWorld.cs>`_ to a directory somewhere on your machine.

The next thing you will need is a ``project.json`` file that will outline the dependencies of an app, so you can **actually** run it. Use the contents below, it will work for both examples above. Save this file in a directory next to the CS file that contains your code.

.. code-block:: json

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
with ``dnu restore``. You will need to run this command under the Mono
DNX. The first command switches the active runtime to the Mono one.

.. code-block:: console

    dnvm use 1.0.0-beta5-11649 -r mono
    dnu restore

You are now ready to run your app under .NET Core. As you can guess, however, before you do that you first need to switch to the .NET Core runtime. The first command below does exactly that.

.. code-block:: console

    dnvm use 1.0.0-beta5-11649 -r coreclr
    dnx run

    Hello, OSX
    Love from CoreCLR.

Building .NET Core from source
------------------------------
.NET Core is an open source project that is hosted on GitHub. This means that you can, at any given time, clone the repository and build .NET Core from source. This is a more advanced scenario that is usually used when you want to add features to the .NET runtime or the BCL or if you are a contributor to these projects. The detailed instruction on how to build .NET Core windows can be found in the `.NET Core OS X build instructions <https://github.com/dotnet/coreclr/blob/master/Documentation/building/osx-instructions.md>`_ on GitHub.
