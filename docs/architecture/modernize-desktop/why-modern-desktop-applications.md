---
title: Why Modern Desktop Applications?
description: Learn about desktop technologies such as Windows Forms, WPF and UWP in the modern world.
ms.date: 09/16/2019
---
# Why Modern Desktop Applications?

## Introduction

### A story of one company

Back in early 2000s, one multinational company started developing a distributed desktop solution to exchange information between different branches of the company and execute optimized operations on centralized units. They have chosen a brand-new framework called Windows Forms for their application development. Over the years, the project evolved into a mature well tested and time-proven application with hundreds of thousands of lines of code. Time passed and .NET Framework 2.0 is no longer the hot new technology. The developers who are working on this application are facing a dilemma. They would like to use the latest stack of technologies in their development and have their application look and "feel" modern. At the same time, they don't want to throw away the great product they have built over 15 years and rewrite the entire application from scratch.

### Your story

You might find yourself in the same boat, where you have mature Windows Forms (also known as WinForms) or WPF (Windows Presentation Foundation) applications that have proved their reliability over the years. You probably want to keep using these applications for many more years. At the same time, since those applications were written some time ago, they might be missing capabilities like modern look, performance, integration with new devices and platform features and so on, which gives them a feel of "old tech". There is another problem that might concern you as a developer. While working on the older .NET Framework versions and maintaining applications that were written a while ago, you might feel like you aren't learning new technologies and missing on building modern technical skills. If that is your story – this book is for you!

### About this guide

This guide is about strategies you can adopt to move your existing desktop applications through the path of modernization and incorporate the latest runtime, language and platform features. You will discover that there is no unique recipe as each application is different, and so are your requirements and preferences. The good news is that there are common approaches you can apply to add new features and capabilities to your applications. Some of them will not even require major modifications of your code.  In this book, we will reveal how all those features work behind the scenes and explain the mechanics of their implementations. Moreover, you will find some common scenarios for modernizing existing desktop applications depicted in detail so you can find inspiration for evolving your projects.

Microsoft approach to modernizing existing applications is to give you the flexibility to create your own customized path. All the modernization strategies described in this book are mostly independent. You can choose ones that are relevant for your application and skip others that aren't important for you. In other words, you will be able to mix and match the strategies to best address your application needs.

## Desktop applications nowadays

Before the raise of the Internet, desktop applications were the main approach to build software systems. You could choose any programming language like Cobol, Fortran, Visual Basic, C++, etc., but you ended up creating some sort of desktop application, from small tools to complex distributed architectures.

Then, Internet technologies started shocking the development world and winning over more and more engineers with advantages like easy deployment and simplified distribution processes. The fact that once Web application was deployed to production all users got automatic updates made a huge impact on the software agility.

However, the Internet infrastructure, underlying protocols and standards like HTTP and HTML were not design for building complex applications. In fact, the major development effort back then was aiming just one goal: to give Web applications same capabilities that desktop applications have, such as fast data input, state management and so on.

Even though Web and Mobile applications have grown at an incredible pace, for certain tasks desktop applications still hold the number one place in terms of efficiency and performance. That explains why there are millions of developers who are building their projects with WPF and WinForms and the amount of those applications is constantly growing.

Here are some reasons for choosing desktop applications in your development:

- Desktop apps have better interaction with user's PC.
- The performance of desktop applications for complex calculations is much higher than performance of web applications.
- Running custom logic on the client side is possible but much harder with a web application.
- Using multithreading is easier and more efficient in a desktop application.
- The learning curve for designing User Interfaces is smother and in case of WinForms is completely intuitive with drag-and-drop experience of the Windows Forms designer.
- It is easy to start coding and testing your algorithms without the need to set up a server infrastructure or to care about connectivity problems, firewalls and browser compatibility.
- Debugging is powerful as compared to web debugging.
- Access to hardware devices like camera, Bluetooth or card readers is easy.
- And since the technology have been around for a long time there is a huge human expertise and knowledge database available on developing desktop applications.

So, as you can see, developing for desktop is great for many reasons. The technology is mature and time tested, the development cycle is fast, the debugging is powerful and arguably, desktop apps have less complexity and easier to get started with.

Microsoft offered a variety of UI desktop technologies through the years from Win32 introduced in 1995 and to UWP released in 2016.

![Microsoft desktop technologies](./media/why-modern-desktop-applications/microsoft-desktop-technologies.png)

The most popular technologies for building Windows Desktop according to a survey published by Telerik on April 2016 are Windows Forms, WPF and UWP.

![Telerik survey showing Windows Forms, WPF and UWP as the most popular desktop technologies](./media/why-modern-desktop-applications/telerik-survey.png)

You can develop in any of them using C# and VB.NET, but let's take a closer look.

### Windows Forms

First released in 2002, Windows Forms is a managed framework and is the oldest, most used, desktop technology built on the Windows GDI engine. It offers a very smooth drag-and-drop experience for developing user interfaces in Visual Studio.  At the same time, Windows Forms relies on the Visual Studio Designer as the main way you develop your UI, so creating visual components from code is not trivial.

- Mature technology with lots of code samples and documentation.
- Very powerful and productive designer. Not so convenient to design UI "from code".
- Easy and intuitive to learn, thanks to the designer's drag and drop experience.
- Supported on any Windows version.
- Supported on .NET Core 3.0.

### WPF

Based on the XAML language specification, WPF favors a clear separation between UI and code.  XAML offers such capabilities like templating, styling, and binding, which is suited for building big applications. Like Windows Forms, it is a managed framework, but the design is modular and reusable.

- Mature technology.
- Designer is available, but developers usually prefer to create the design from code using declarative XAML.
- The learning curve is steeper than Windows Forms.
- Supported on any Windows version.
- Supported on .NET Core 3.0.

### UWP

The Universal Windows Platforms is not only a presentation framework like WPF and Windows Forms, but it is also a platform itself. This platform has its own API set (the Windows Runtime API), a new deployment system (MSIX), a modern application lifecycle model (for low battery consumption), a new Resource Management System (based on PRI files), among other things. The platform was created to support all kind of input systems (like ink, touch, gamepad, mouse, keyboard, gaze, etc.) in all form-factors with performance and low battery consumption in mind. For these reasons the Shell of the Windows 10 OS uses parts of the UWP platform.

![UWP structure](./media/why-modern-desktop-applications/uwp-structure.png)

UWP contains a presentation framework that is XAML based, like WPF, but is has some important differences such as:

- Applications are executed in app containers. App containers are a sandbox mechanism which control what resources an UWP app can access or not.
- Supported only on Windows 10.
- Apps can be deployed through Microsoft Store for easier deployment besides sideload.
- Designed as part to the Windows Runtime API.
- Contains an extensive set of built-in rich controls and additional controls in the Microsoft UI Library NuGet packages (WinUI library) updated every few months.

## A tale of two platforms

In the last 20 years, while UI desktop technologies were growing and following the path from Windows Forms to UWP, the hardware was also evolving from heavy weight PC units with small CRT monitors to HDPI monitors and lightweight tablets and phones with different data input techniques like Touch and Ink.  This resulted in creating two different concepts: a Desktop Application and a Modern Application. A Modern Application is one that considers different device form factors, various input and output methods, and leverages modern desktop features while running on a sandboxed execution model. The (traditional) Desktop Application, on the other hand, is an application that needs a solid UI with high density of controls that is best operated with a mouse and a keyboard.

We can describe the differences between the two concepts in the following table:

|   | Modern Application | Desktop Application |
| --- | --- | --- |
| Security | Contained execution &amp; Great Fundamentals.Design from the ground up to respect user privacy, manage battery life and focus to keep the device safe.  | User &amp; Admin level of security.You have native access to the Registry and Hard Drive folders. |
| Deployment | Installation and updates are managed by the platform.   | MSI, Custom installers &amp; Updates. Traditionally a source of headaches for developers and IT managers.  |
| Distribution | Trusted Distribution &amp; Signed Packages. Distribution is performed from a trusted source and never from the Web.  | Web, SCCM &amp; Custom distribution. No control over what is installed, affects the whole machine.   |
| UI | Modern UI. Different input mechanisms, ink, touch, gamepad, keyboard, mouse, etc.  | Windows Forms, WPF, MFC. Designed for the mouse and keyboard for a very dense UI and to get the most productivity from the desktop.  |
| Data | Cloud First Data with Insights. Source of truth in the cloud. Insights to know what happens with your app and how it is performing.  | Local Data.Traditional desktop applications usually need some local data.  |
| Design | Designed for reuse. Reuse in mind between different platforms, front end and back end, running assets in many places as possible.  | Designed for Windows Desktop only  |

As a part of the commitment to provide developers with the best tools to build applications, Microsoft has performed a great effort to bring these concepts, or we can even say platforms, closer together to empower developers with the best of both worlds.To do that, Microsoft has performed a bidirectional effort between the two platforms.

![Bidirectional effort between Modern Application and Desktop Applications](./media/why-modern-desktop-applications/bidirectional-effort.png)

1. Move Desktop Application scenarios into Modern Application platform. The traditional desktop development is still very popular because it addresses certain scenarios really well. It makes sense to take these common desktop scenarios and bring them into the modern desktop platform to make the platform fully capable.

    ![Move Desktop Application scenarios into Modern Application platform](./media/why-modern-desktop-applications/desktop-to-modern.png)

1. Move Modern Application features into Desktop Applications. For existing desktop apps that need a way to leverage modern capabilities without rewriting from scratch, features from the Modern Application platform are pushed into the Desktop Application.

    ![Move Modern Application features into Desktop Applications](./media/why-modern-desktop-applications/modern-to-desktop.png)

In this book we will focus on the second part and show how you can modernize your existing desktop applications.

## Paths to modernization

The structure of this guide reflects three different axes to accomplish modernization: Modern Features, Deployment and Installation.

### Modern Features

Say you have a working Windows Forms application that a sales representative of your company uses to fill in a customer order. A new requirement comes in to enable the customer to sign-in the order using a tablet pen. Inking is native in today´s operating systems and technologies but was not available when the app was developed.

This path will show you how you can leverage modern desktop features into your existing desktop development.

### Deployment

Modern development cycles have stressed out to provide agility on how new versions of applications are deployed to every single user. Since Windows Forms and WPF applications are based on a particular version of the .NET Framework that must be present on the machine, they cannot take advantage of new .NET Framework version features without the intervention of the IT people with the risk of having side effects for other apps running on the same machine. This has limited the innovation pace for developers forcing them to stay on outdated versions of the .NET Framework.

Now, with the launch of .NET Core 3.0, you can leverage a radically new approach of deploying multiple versions of .NET Core side by side and specifying which version of .NET Core each application should target. This way, you can use newest features in one application while being confident you aren't going to break any other applications.

### Installation

Desktop applications always rely on some sort of installation process before the user can start using them. This brought into the game a set of technologies, from MSI and ClickOnce to custom installers or even XCOPY deployment. Any of these methods deals with delicate problems because applications need a way to access shared resources on the machine. Sometimes installation needs to access the Registry to insert or update new Key Values, sometimes to update shared DLLs referenced by the main application. This causes a continuous headache for users, creating this perception that once you install some application, your computer will never be the same, even if you uninstall it afterwards.

In this book, we will introduce a new way of installing applications with MSIX that solves the problem described above. You will learn how you can easy set up a packaging, installation and updates for your application.

## What this guide does not cover

This guide covers a specific subset of scenarios focused on lift and shift scenarios, outlining the way to gain the benefits of modernizing without the effort of rewriting code.

This guide is not about developing modern applications with .NET Core or implementing desktop scenarios into the Modern Application Platform. If focus on how you can leverage your investments on desktop applications while you keep them updated with some of the latest technologies for desktop development.

## Who should use this guide

We wrote this guide for developers and solution architects who want to modernize existing Windows Forms and WPF Desktop Applications to leverage the benefits of .NET Core 3.0 and MSIX installation.

You also might find this guide useful if you are a technical decision maker, such as an enterprise architect or a development lead/director who just wants an overview of the benefits that you can get by updating existing Desktop Apps.

## How to use this guide

This guide addresses the "why"—why you might want to modernize your existing applications, and the specific benefits you get from using NET Core 3.0 and MSIX to modernize your desktop apps. The content of the guide is designed for architects and technical decision makers who want an overview, but who don't need to focus on implementation and technical, step-by-step details.

Along the different chapters, sample implementation code snippets and screenshot are provided, with chapter 5 devoted to a showcase a complete migration process for sample applications.

## Sample apps

To highlight the necessary steps to perform a modernization, we will be using a sample application called eShopModernizing. This application has two flavors, Windows Forms and WPF and we will show a step by step process on how to perform the modernization on both of them to .NET Core.

Also, on the GitHub repository for this book, you'll find the results of the process, which you can consult with if you decide to follow the step-by-step tutorial.

## Send us your feedback

We wrote this guide to help you understand your options for improving and modernizing existing .NET desktop applications. The guide and related sample applications are evolving. We welcome your feedback! If you have comments about how this guide might be more helpful, send them to [dotnet-architecture-ebooks-feedback@service.microsoft.com](mailto:dotnet-architecture-ebooks-feedback@service.microsoft.com).
