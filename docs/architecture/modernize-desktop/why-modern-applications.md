---
title: Why modern desktop applications
description: Learn about desktop technologies such as Windows Forms, WPF, and UWP in the modern world.
ms.date: 12/29/2020
---
# Why modern desktop applications

## Introduction

### A story of one company

Back in the early 2000s, one multinational company started developing a distributed desktop solution to exchange information between different branches of the company and execute optimized operations on centralized units. They have chosen a brand-new framework called Windows Forms (also known as WinForms) for their application development. Over the years, the project evolved into a mature, well tested, and time-proven application with hundreds of thousands of lines of code. Time passed and .NET Framework 2.0 is no longer the hot new technology. The developers who are working on this application are facing a dilemma. They'd like to use the latest stack of technologies in their development and have their application look and "feel" modern. At the same time, they don't want to throw away the great product they have built over 15 years and rewrite the entire application from scratch.

### Your story

You might find yourself in the same boat, where you have mature Windows Forms or Windows Presentation Foundation (WPF) applications that have proved their reliability over the years. You probably want to keep using these applications for many more years. At the same time, since those applications were written some time ago, they might be missing capabilities like modern look, performance, integration with new devices and platform features, and so on, which gives them a feel of "old tech". There's another problem that might concern you as a developer. While working on the older .NET Framework versions and maintaining applications that were written a while ago, you might feel like you aren't learning new technologies and missing on building modern technical skills. If that is your story – this book is for you!

## Desktop applications nowadays

Before the rise of the Internet, desktop applications were the main approach to build software systems. Developers could choose any programming language, such as COBOL, Fortran, VB6, or C++. But whether they developed small tools or complex distributed architectures, they were all desktop applications.

Then, Internet technologies started shocking the development world and winning over more engineers with advantages like easy deployment and simplified distribution processes. The fact that once a web application was deployed to production all users got automatic updates made a huge impact on the software agility.

However, the Internet infrastructure, underlying protocols, and standards like HTTP and HTML weren't designed for building complex applications. In fact, the major development effort back then was aiming just one goal: to give web applications the same capabilities that desktop applications have, such as fast data input and state management.

Even though web and mobile applications have grown at an incredible pace, for certain tasks desktop applications still hold the number one place in terms of efficiency and performance. That explains why there are millions of developers who are building their projects with WPF and WinForms and the amount of those applications is constantly growing.

Here are some reasons for choosing desktop applications in your development:

- Desktop apps have better interaction with the user's PC.
- The performance of desktop applications for complex calculations is much higher than the performance of web applications.
- Running custom logic on the client-side is possible but much harder with a web application.
- Using multithreading is easier and more efficient in a desktop application.
- The learning curve for designing user interfaces (UIs) isn't steep. And for WinForms, it's intuitive with the drag-and-drop experience of the Windows Forms designer.
- It's easy to start coding and testing your algorithms without the need to set up a server infrastructure or to care about connectivity problems, firewalls, and browser compatibility.
- Debugging is powerful as compared to web debugging.
- Access to hardware devices, such as camera, Bluetooth, or card readers, is easy.
- Since the technology has been around for a while, there are many experts and a knowledge base available to develop desktop applications.

So, as you can see, developing for desktop is great for many reasons. The technology is mature and time tested, the development cycle is fast, the debugging is powerful and arguably, desktop apps have less complexity and easier to get started with.

Microsoft offered many UI desktop technologies throughout the years from Win32 introduced in 1995 to Universal Windows Platform (UWP) released in 2016.

![Microsoft desktop technologies](./media/why-modern-applications/microsoft-desktop-technologies.png)

According to a survey published by Telerik on April 2016, the most popular technologies for building Windows desktop apps are Windows Forms, WPF, and UWP.

![Telerik survey showing Windows Forms, WPF, and UWP as the most popular desktop technologies](./media/why-modern-applications/telerik-survey.png)

You can develop in any of them using C# and Visual Basic, but let's take a closer look.

### Windows Forms

First released in 2002, Windows Forms is a managed framework and is the oldest, most used, desktop technology built on the Windows graphics device interface (GDI) engine. It offers a smooth drag-and-drop experience for developing user interfaces in Visual Studio.  At the same time, Windows Forms relies on the Visual Studio Designer as the main way you develop your UI, so creating visual components from code isn't trivial.

The following list summarizes the main characteristics of Windows Forms:

- Mature technology with lots of code samples and documentation.
- Powerful and productive designer. Not so convenient to design UI "from code".
- Easy and intuitive to learn, thanks to the designer's drag-and-drop experience.
- Supported on any Windows version.
- Supported on .NET Core 3.0 and later versions.

### WPF

Based on the XAML language specification, WPF favors a clear separation between UI and code. XAML offers such capabilities like templating, styling, and binding, which is suited for building large applications. Like Windows Forms, it's a managed framework, but the design is modular and reusable.

Here are the main features of WPF:

- Mature technology.
- Designer is available, but developers usually prefer to create the design from code using declarative XAML.
- The learning curve is steeper than Windows Forms.
- Supported on any Windows version.
- Supported on .NET Core 3.0 and later versions.

### UWP

UWP isn't only a presentation framework like WPF and Windows Forms, but it's also a platform itself. This platform has:

- Its own API set (the Windows Runtime API).
- A new deployment system (MSIX)
- A modern application lifecycle model (for low battery consumption).
- A new Resource Management System (based on PRI files).

The platform was created to support all kind of input systems (like ink, touch, gamepad, mouse, keyboard, gaze, and so on) in all form-factors with performance and low battery consumption in mind. For these reasons, the shell of the Windows 10 OS uses parts of the UWP platform.

![UWP structure](./media/why-modern-applications/uwp-structure.png)

UWP contains a presentation framework that is XAML-based, like WPF, but it has some important differences such as:

- Applications are executed in app containers. App containers control what resources a UWP app can access.
- Supported only on Windows 10.
- Apps can be deployed through Microsoft Store for easier deployment.
- Designed as part of the Windows Runtime API.
- Contains an extensive set of rich built-in controls and additional controls available through the Microsoft UI Library NuGet packages (WinUI library) updated every few months.

## A tale of two platforms

In the last 20 years, while UI desktop technologies were growing and following the path from Windows Forms to UWP, the hardware was also evolving from heavy weight PC units with small CRT monitors to high-DPI monitors and lightweight tablets and phones with different data input techniques like Touch and Ink. These changes resulted in creating two different concepts: a Desktop Application and a Modern Application. A Modern Application is one that considers different device form factors, various input and output methods, and leverages modern desktop features while running on a sandboxed execution model. The (traditional) Desktop Application, on the other hand, is an application that needs a solid UI with a high density of controls that is best operated with a mouse and a keyboard.

The following table describes the differences between the two concepts:

| Aspect of comparison | Modern Application | Desktop Application |
| --- | --- | --- |
| Security | Contained execution &amp; Great Fundamentals. Designed from the ground up to respect user's privacy, manage battery life, and focus to keep the device safe.  | User &amp; Admin level of security. You have native access to the registry and hard drive folders. |
| Deployment | Installation and updates are managed by the platform.   | MSI, Custom installers &amp; Updates. Traditionally a source of headaches for developers and IT managers.  |
| Distribution | Trusted Distribution &amp; Signed Packages. Distribution is performed from a trusted source and never from the web.  | Web, SCCM &amp; Custom distribution. No control over what is installed, affects the whole machine.   |
| UI | Modern UI. Different input mechanisms, ink, touch, gamepad, keyboard, mouse, etc.  | Windows Forms, WPF, MFC. Designed for the mouse and keyboard for a dense UI and to get the most productivity from the desktop.  |
| Data | Cloud First Data with Insights. Source of truth in the cloud. Insights to know what happens with your app and how it's performing.  | Local Data. Traditional desktop applications usually need some local data.  |
| Design | Designed for reuse. Reuse in mind between different platforms, front end, and back end, running assets in many places as possible.  | Designed for Windows Desktop only  |

As a part of the commitment to provide developers with the best tools to build applications, Microsoft put a great effort to bring these concepts, or we can even say platforms, closer together to empower developers with the best of both worlds. To do that, Microsoft has performed a bidirectional effort between the two platforms.

![Bidirectional effort between Modern Application and Desktop Applications](./media/why-modern-applications/bidirectional-effort.png)

1. Move Desktop Application scenarios into Modern Application platform. The traditional desktop development is still popular because it addresses certain scenarios well. It makes sense to take these common desktop scenarios and bring them into the modern desktop platform to make the platform fully capable.

    ![Move Desktop Application scenarios into Modern Application platform](./media/why-modern-applications/desktop-to-modern.png)

1. Move Modern Application features into Desktop Applications. For existing desktop apps that need a way to leverage modern capabilities without rewriting from scratch, features from the Modern Application platform are pushed into the Desktop Application.

    ![Move Modern Application features into Desktop Applications](./media/why-modern-applications/modern-to-desktop.png)

In this book, we'll focus on the second part and show how you can modernize your existing desktop applications.

## Paths to modernization

The structure of this guide reflects three different axes to accomplish modernization: Modern Features, Deployment, and Installation.

### Modern features

Say you have a working Windows Forms application that a sales representative of your company uses to fill in a customer order. A new requirement comes in to enable the customer to sign the order using a tablet pen. Inking is native in today's operating systems and technologies, but it wasn't available when the app was developed.

This path will show you how you can leverage modern desktop features into your existing desktop development.

### Deployment

Modern development cycles have stressed out to provide agility on how new versions of applications are deployed to every single user. Since Windows Forms and WPF applications are based on a particular version of the .NET Framework that must be present on the machine, they can't take advantage of new .NET Framework version features without the intervention of the IT people with the risk of having side effects for other apps running on the same machine. It has limited the innovation pace for developers forcing them to stay on outdated versions of the .NET Framework.

Since the launch of .NET Core 3.0, you can leverage a new approach of deploying multiple versions of .NET side by side and specifying which version of .NET each application should target. This way, you can use the newest features in one application while being confident you aren't going to break any other applications.

### Installation

Desktop applications always rely on some sort of installation process before the user can start using them. This fact brought into the game a set of technologies, from MSI and ClickOnce to custom installers or even XCOPY deployment. Any of these methods deals with delicate problems because applications need a way to access shared resources on the machine. Sometimes installation needs to access the Registry to insert or update new Key Values, sometimes to update shared DLLs referenced by the main application. This behavior causes a continuous headache for users, creating this perception that once you install some application, your computer will never be the same, even if you uninstall it afterwards.

In this book, we'll introduce a new way of installing applications with MSIX that solves the problem described earlier. You'll learn how you can easily set up packaging, installation, and updates for your application.

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](whats-new-dotnet.md)
