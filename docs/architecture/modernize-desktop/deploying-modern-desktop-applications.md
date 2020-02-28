---
title: Deploying Modern Desktop Applications
description: Everything you need to know about deploying for modern desktop applications.
ms.date: 09/16/2019
---

# Deploying Modern Desktop Applications

## Introduction

When you are a web developer, you must care about a lot of things related to
your code. You must develop the necessary features to cover all planned business
scenarios, you have to create a clean and easy to use user interface, you must
pay attention to how your application performs, optimize it to lower resource
consumption, and large etcetera of items. Besides checking for browser
compatibility, once you complete these tasks, you can consider you are done.

When you develop for the desktop you also have to think about how your
application is going to be packaged and deployed to the final users' machines.
The problem with packaging, deployment and installation is that is usually falls
under the umbrella of the IT professionals who care about very different things
than developers.

These days we are all familiar with the DevOps concept where developers and IT
pros work closely to move applications to their production environments. But if
you have been in the desktop battle for more than 10 years you should have heard
the following story. A team of developers work together very hard to meet the
project deadlines. Business people are nervous since they need the system working
on a lot of user's machines to run the company. At 4:00 AM on the D-Day, the
project manager checks with every developer their code is working well,
everything is fine, we can ship. Then the package team comes in generating the
setup for the app, distribute it to every user machine and at 5:00 AM a set of
test users run the application. Well, they try, because before showing any UI
the application throws an Exception that says "Method ~ of object ~ failed".
Panic starts flowing through the air and a brief investigation points to a young
and tired developer that has introduced a third-party control anybody knew it
had to be deployed. And all he manages to say are these famous words: "Well, it
works on my machine".

Installing desktop applications have traditionally be kind of a nightmare for
two main reasons: a lack of culture of close collaboration between dev and IT
teams and a lack of a solid packaging a deploying technology we can build upon.
In fact, we have been leaving with the fact that sometimes you regret to install
an app because it ends up having some undesired side effects and some already
installed applications stop working. Moreover, you cannot just restore the
system to its original state by uninstalling. We are so used to live this
situation that we have coined terms like "DLL Hell" or "Winrot".

In this chapter, we talk about MSIX the brand-new technology from Microsoft that
tries to capture the best of previous technologies to provide a solid foundation
for the packaging technology of the future.

What does a packaging technology have to do with modernization? Well, it turns
out that packaging is fundamental for the enterprise IT with lots of money
invested there. Modernization is not only related with using the latest
technologies but also with reducing time to market between a business
requirement is defined and the moment your company delivers the feature to your
client.

## The modern application lifecycle

Today, developers write and build the code for an app and then pass the
generated assets to the IT pros who reconfigure the app and repackage it
typically in an MSI or more recent App-V packaging format, which is deploy
through different channels and tools. One of the main problems with this
approach is commonly known as "packaging paralysis". The problem is that this
cycle repeats every time there is an App update or an OS Update.

We can see the process reflected on this picture:

![Modern IT](media\deploying-modern-desktop-applications\modern-it.png)

Companies need a way to break this packaging cycle in three independent cycles:

* OS Updates
* Application Updates
* Customization

![IT cycles](media\deploying-modern-desktop-applications\it-cycles.png)

This means we should be able to update the underlying OS without having to
repackage our apps or enable customizations from IT without the need to
repackage the original developer package.

This radical change leads us to the new and modern IT lifecycle depicted in the
following picture:

![Microsoft IT tools](media\deploying-modern-desktop-applications\microsoft-it-tools.png)

Developers create the app and generate an MSIX package that IT pros can consume
and configure without the need of repackaging. Along with the MSIX technology,
Microsoft has created tools to allow IT to customize and configure packages
without repackaging.

## MSIX: The next generation of deployment

Before MSIX, we had several packaging technologies available like setup wizards,
MSI, ClickOnce, App-V and scripting. Each of those have their strengths and
Microsoft has decided to pick the best of all to build MSIX. Therefore, MSIX is
built on the foundations of these existing technologies picking the best of
each:

* App-V =\> Containerization
* ClickOnce =\> Auto updating
* MSI =\> Easy to distribute

With MSIX, we get one installer technology with all these features.

![MSIX](media\deploying-modern-desktop-applications\msix.png)

### Benefits of MSIX

#### Never regret installing an App

MSIX provides a predictable, reliable and safe deployment. The declarative
method contained in the package manifest lets the OS keep track of every assets
your application needs. It also provides a true clean uninstall with no side
effects.

#### Disk space optimization

MSIX is optimized to reduce the footprint and application has on the user's
machine disk space. It creates a single instance storage of your files, meaning
that if you have two different packages with the same DLL, it is not installed
twice. The platform takes care of that because it knows all the files that are
installed by a particular app thanks to its declarative nature. It also allows
you to have different versions of a DLL working side by side.

With the use of Resource packages, you can easily create Multilingual apps and
the OS takes care of installing the ones that are used.

#### Network optimization

MSIX detects the differences on the files at the byte block level enabling a
feature called Differential Updates. What this means it that only the updated
byte blocks are downloaded on application updates.

![MSIX managing updates](media\deploying-modern-desktop-applications\msix-managing-updates.png)

With Streaming installation, the user can start working on your application
really quickly while other parts of the app are downloaded on the background.
This feature contributes to a very engaging experience for your users.

Through optional packages feature you achieve componentization on your app
deployment so you can download them when needed.

#### Simple packaging and deployment

The AppManifest declares the versioning, device targeting and identify in a
standard way for every application. It also provides a way to sign your assets
providing a solid security foundation.

#### OS Managed

The OS handles all the processes for installation, updating and removing an
application. Applications are installed per user but downloaded only once,
minimizing the disk footprint. Microsoft is working on providing the MSIX
experience also on Windows 7.

#### Windows provides integrity for the app

With the use of digital signatures, you can guarantee that you don't install
application from untrusted sources. MSIX also prevents tampering because it
keeps a record of file hashes and detects on file has been modified after
installation.

#### Works for the entire App catalog

One of the coolest things about MSIX is that it works for the entire application
catalog, Windows Forms, WPF, MFC/ATL, Delphi, even if you want to do xCopy
deployment, ClickOnce or going to the Store, you can use the same MSIX package.

### Tools

#### Windows Application Packaging Project

You can use the **Windows Application Packaging Project** project in Visual
Studio to generate a package for your desktop app. Then, you can publish that
package to the Microsoft Store or sideload it onto one or more PCs.

#### MSIX Packaging Tool

The MSIX Packaging Tool enables you to repackage your existing Win32
applications to the MSIX format. It offers both an interactive UI and a command
line for conversions and gives you the ability to convert an application without
having the source code.

![MSIX Packaging Tool](media\deploying-modern-desktop-applications\msix-packaging-tool.png)

#### Package Support Framework

The Package Support Framework is an open source kit that helps you apply fixes
to your existing win32 application when you don't have access to the source
code, so that it can run in an MSIX container. The Package Support Framework
helps your application follow the best practices of the modern runtime
environment.

#### App Installer

App Installer allows for Windows 10 apps to be installed by double clicking the
app package. This means that users don't need to use PowerShell or other
developer tools to deploy Windows 10 apps. The App Installer can also install an
app from the web, optional packages, and related sets.

## How to create a MSIX package from an existing Win32 desktop application

Let's see the steps you have to take to create a MSIX package from an existing
Win32 application, a Windows Forms app in this case.

To start, add a new project to your solution, select the Windows Application
Packaging Project and give it a name.

![Adding new Windows Application Packaging Project](media\deploying-modern-desktop-applications\adding-packaging-project.png)

You will see the structure of the packaging project and note a special folder
called Applications. Inside this folder you can specify which applications you want to include in the package, it can be more than one.

![The structure of the packaging project](media\deploying-modern-desktop-applications\packaging-project.png)

Right-click on the *Applications* folder and select the Windows Forms project we
want to package from the Visual Studio solution.

![Adding our Windows Forms project to Packaging Project](media\deploying-modern-desktop-applications\adding-our-project.png)

At this point, you can compile and generate the package but let us take a look
at a couple of things. To have a better user experience, Visual Studio can auto
generate all the visual assets a modern application needs to handle icons and
tile assets for the tile bar and start menu. Opening the `Package.appxmanifest`
file you can access the Manifest Designer and generate all the visual assets
from a given image present on your project just by clicking *Create*.

![Manifest Designer](media\deploying-modern-desktop-applications\manifest-designer.png)

If you open the code for the `Package.appxmanifest` you can see a couple of
interesting things.

Right under `<Package>` there is an `<Identity>` node. This is where your packaged application is going to get its identity to let the OS manage it.

![Identity node](media\deploying-modern-desktop-applications\identity-node.png)

In the `<Capabilities>` node you can find all the requirements the application
express to need, paying special attention to the `<rescap:Capability
Name="runFullTrust" \>` that tells the OS to run the app in full trust mode as
this is a Win32 application.

![Capabilities node](media\deploying-modern-desktop-applications\capabilities-node.png)

Set the packaging project as the startup project for the solution and hit *Run*.
This is going to compile the Windows Forms application, create an MSIX package
out of the build results, deploy the packages, install it locally on the
development machine and launch the app.

![Our installed application](media\deploying-modern-desktop-applications\our-installed-application.png)

With this, you have the clean install and uninstall experience that MSIX
provides fully integrated into Windows 10.

The final stage is about how you deploy the MSIX package to another machine.

Right-click on the packaging project, select the Store menu and then click on
Create App Packages option.

Then you can choose between creating a package to upload to the store, but in
most modernization scenarios you will choose the "I want to create packages for
sideloading".

![Configuring Packages](media\deploying-modern-desktop-applications\configuring-packages.png)

There you can select the different architectures you want to target as you can
include as many as you want into de the same MSIX package.

The final step is to declare where you want to deploy the final installation
assets.

![Configure Update Settings](media\deploying-modern-desktop-applications\configure-update-settings.png)

You can choose to use a web server of a shared UNC path on your enterprise file
servers. Pay attention to the settings you can specify to set up how you want to
update your application. We will be discussing about application updates in the
next section.

For a detail step by step guide please refer to: [Package a desktop app from source code using Visual Studio](https://docs.microsoft.com/windows/msix/desktop/desktop-to-uwp-packaging-dot-net)

## Auto Updates in MSIX

The Windows Store has a great updating mechanism using Windows Update. In most
enterprise scenarios, you don't use the Store to distribute your desktop apps so
you need a similar way to configure updates for your application and pull them
to your users.

Using a combination of Windows 10 features and MSIX packages, you can provide a
great updating experience for your users. In fact, the user does not need to be
technical at all but still benefit from a seamless application update
experience.

You can configure your updates to interact with the user in two different ways:

* User prompted updates: The OS shows some auto generated nice UI to notify the
  user about the application is about to install. It builds this UI based on the
  properties you specify on your installation files.

* Silent updates in the background. With this option, your users don't need to
  be aware of the updates.

You can also configure when you want to perform updates, when the application
launches or on a regularly basis. Thanks to the side-loading features, you can
even get these updates while the application is running.

When you use this type of deployment, a special file is created called
`.appinstaller`. This simple file contains the following sections:

* The location of the `.appinstaller` file
* The application's main MSIX package properties
* The update behavior

![.appinstaller file](media\deploying-modern-desktop-applications\appinstaller-file.png)

In combination with this file, Microsoft has designed a special URL protocol to
launch the installation process from a link:

```xml
<a href="ms-appinstaller:?source=http://mywebservice.azureedge.net/MyApp.msix">Install app package </a>
```

This protocol work on all browsers and launches the installation process with a
great user experience on Windows 10. Since the OS manages the installation
process, it is aware of the location this application was installed from and
tracks all the files affected by the process.

MSIX builds a user interface for installation automatically showing some
properties of the package. Developers don't need to create this. This allows for
a common installation experience for every app.

![User interface for installation](media\deploying-modern-desktop-applications\ui-installation.png)

When you have a new version of your app, you want to deploy it to your users.
Once you have generated the new MSIX package and moved it to the deployment
server, you just have to edit the `.appinstaller` file to reflect this changes,
mainly the version and the path to the new MSIX file. The next time the user
launches the application the system is going to detect the change and download
the files for the new version in the background. When this is done, installation
will execute on new application launch transparently for your user.
