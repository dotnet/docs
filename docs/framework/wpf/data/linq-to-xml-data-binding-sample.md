---
title: LINQ to XML data binding example
ms.date: 10/22/2019
ms.topic: sample
helpviewer_keywords:
 - linq to xml data binding sample
---
# LINQ to XML data binding sample

This article describes the LinqToXmlDataBinding sample, a Windows Presentation Foundation (WPF) app that binds user interface components to an embedded XML data source.

## Overview

The LinqToXmlDataBinding sample is a Windows Presentation Foundation (WPF) app that contains C# and XAML source files. An embedded XML document defines a list of books. The app enables the user to view, add, delete, and edit the book entries.

There are two primary source files:

- [L2DBForm.xaml](l2dbform-xaml-source-code.md) contains the XAML declaration code for the user interface (UI) of the main window. It also contains a window resource section that defines a data provider and an embedded XML document for the book listings.

- [L2DBForm.xaml.cs](l2dbform-xaml-cs-source-code.md) contains the initialization and event-handling methods associated with the UI.

The main window is divided into the following four vertical UI sections:

- **XML** displays the raw XML source of the embedded book listing.

- **Book List** displays the book entries as standard text and enables the user to select and delete individual entries.

- **Edit Selected Book** enables the user to edit the values associated with the currently selected book entry.

- **Add New Book** enables the creation of a new book entry based on values entered by the user.

## Run the sample

This section shows how to create and build the LinqToXmlDataBinding project in Visual Studio, and how to run the resulting LinqToXmlDataBinding Windows Presentation Foundation (WPF) app.

### Create the project

1. Open Visual Studio and create a C# **WPF App** named **LinqToXmlDataBinding**.

   The project should target the .NET Framework 3.5 (or later).

1. If not already present, add project references for the following .NET assemblies:

    - System.Data
    - System.Data.DataSetExtensions
    - System.Xml
    - System.Xml

1. Build the solution by pressing **Ctrl**+**Shift**+**B**, then run it by pressing **F5**.

   The project should compile without errors and run as a generic WPF application.

### Add code

1. In **Solution Explorer**, rename the source file **Window1.xaml** to **L2XDBForm.xaml**.

   The dependent source file Window1.xaml.cs is automatically renamed to L2XDBForm.xaml.cs.

1. Replace the source code found in the file **L2XDBForm.xaml** with the [L2DBForm.xaml source code](l2dbform-xaml-source-code.md). Use the XAML source view to work with this file.

1. Similarly, replace the source in **L2XDBForm.xaml.cs** with the [L2DBForm.xaml.cs source code](l2dbform-xaml-cs-source-code.md).

1. In the file **App.xaml**, replace all occurrences of the string **Window1.xaml** with **L2XDBForm.xaml**.

1. Build the solution by pressing **Ctrl**+**Shift**+**B**.

### Run the app

The LinqToXmlDataBinding app enables the user to view and manipulate a list of books that's stored as an embedded XML element. Run the app by pressing **F5** (Start Debugging) or **Ctrl**+**F5** (Start Without Debugging).

A program window with the title **WPF Data Binding using LINQ to XML** appears.

The top section of the UI displays the raw **XML** that represents the book list. It is displayed using a WPF <xref:System.Windows.Controls.TextBlock> control, which does not enable interaction through the mouse or keyboard.

The second vertical section, labeled **Book List**, displays the books as a plain text ordered list. It uses a <xref:System.Windows.Controls.ListBox> control that enables selection though the mouse or keyboard.

### Add and delete books

To add a new book to the list, enter values into the **ID** and **Value** <xref:System.Windows.Controls.TextBox> controls in the last section, **Add New Book**, and then select **Add Book**. The book is appended to the list in both the book and XML listings. This program does not validate input values.

To delete an existing book from the list, select it in the **Book List** section, and then select **Remove Selected Book**. The book entry is removed from both the book and the raw XML source listings.

### Edit a book entry

1. Select the book entry in the second **Book List** section.

   Its current values are displayed in the **Edit Selected Book** section.

1. Edit the values using the keyboard. As soon as either <xref:System.Windows.Controls.TextBox> control loses focus, changes are automatically propagated to the XML source and book listings.

