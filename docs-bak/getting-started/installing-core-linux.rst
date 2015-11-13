Installing .NET Core on Linux
=========================================
By `Zlatko Knezevic`_


These instructions will lead you through acquiring the .NET Core DNX SDK
via the `.NET Version Manager (DNVM) <https://github.com/aspnet/dnvm>`__
and running a "Hello World" demo on Linux.

.NET Core NuGet packages and the .NET Core DNX SDKs are available on the
`ASP.NET 'vnext' myget feed <https://www.myget.org/F/aspnetvnext>`__,
which you can more easily view on
`gallery <https://www.myget.org/gallery/aspnetvnext>`__ for the feed.

Setting up the environment
--------------------------

These instructions have been written and tested on Ubuntu 14.04 LTS, since that is the main Linux distribution the .NET Core team uses. These instructions may succeed on other distributions as well. We are always accepting new pull requests on `our GitHub repo <https://www.github.com/dotnet/coreclr/>`_ that address running on other Linux distributions. The only requirement is that they do not break the ability to use Ubuntu 14.04 LTS.

Installing the required packages
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Install the ``libunwind8``, ``libssl-dev`` and ``unzip`` packages:

.. code-block:: console

    sudo apt-get install libunwind8 libssl-dev unzip


Certificates
^^^^^^^^^^^^

You need to import trusted root certificates in order to restore NuGet packages. You can do that with the ``mozroots`` tool.

.. code-block:: console

    mozroots --import --sync

Installing DNVM
---------------

You need DNVM as a starting point. DNVM enables you to acquire one or multiple .NET Execution Environments (DNX). DNVM is a shell script and does not require .NET. You can use the below command to install it.

.. code-block:: console

    curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh

Installing the .NET Core DNX
----------------------------

You first need to acquire the CoreCLR DNX.

.. code-block:: console

    dnvm install latest -r coreclr -u

You can see the currently installed DNX versions with ``dnvm list``.

.. code-block:: console

    dnvm list

.. code-block:: console

    Active Version              Runtime Arch Location             Alias
    ------ -------              ------- ---- --------             -----
      *    1.0.0-beta5-11649    coreclr x64  ~/.dnx/runtimes

Using a specific runtime
------------------------

You can choose which of the installed DNXs you want to use with ``dnvm use``, specifying arguments that are similar to the ones used when installing a runtime.

.. code-block:: console

    dnvm use -r coreclr -arch x86 1.0.0-beta5-11649
    Adding ~/.dnx/runtimes/dnx-coreclr-win-x86.1.0.0-beta5-11649/bin
    to process PATH

    dnvm list

    Active Version              Runtime Arch Location             Alias
    ------ -------              ------- ---- --------             -----
      *    1.0.0-beta5-11649    coreclr x64  ~/.dnx/runtimes

See the asterisk in the listing above? It's purpose is to tell you which runtime is now active. "Active" here means that all of the interaction with your projects and .NET Core will use this runtime.

That's it! You now have the .NET Core runtime installed on your machine and it is time to take it for a spin.

Write your App
--------------

his being an introduction-level document, it seems fitting to start with a "Hello World" app.  Here's a very simple one you can copy and paste into a CS file in a directory.

.. code-block:: c#

    using System;

    public class Program
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("Hello, Linux");
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
with ``dnu restore``.

.. code-block:: console

    dnu restore
    dnx run

    Hello, Linux
    Love from CoreCLR.

Building .NET Core from source
------------------------------
.NET Core is an open source project that is hosted on GitHub. This means that you can, at any given time, clone the repository and build .NET Core from source. This is a more advanced scenario that is usually used when you want to add features to the .NET runtime or the BCL or if you are a contributor to these projects. The detailed instruction on how to build .NET Core windows can be found in the `Build CoreCLR on Linux <https://github.com/dotnet/coreclr/blob/master/Documentation/building/linux-instructions.md>`_ on GitHub.
