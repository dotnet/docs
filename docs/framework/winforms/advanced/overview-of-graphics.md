---
title: "Overview of Graphics"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "graphics [Windows Forms], using managed interface"
  - "graphics [Windows Forms], about graphics"
ms.assetid: a602aef8-a8c8-4c36-9816-74e7bad96a68
---
# Overview of Graphics
GDI+ is an application programming interface (API) that forms the subsystem of the Microsoft Windows operating system. GDI+ is responsible for displaying information on screens and printers. As its name suggests, GDI+ is the successor to GDI, the Graphics Device Interface included with earlier versions of Windows.  
  
## Managed Class Interface  
 The GDI+ API is exposed through a set of classes deployed as managed code. This set of classes is called the *managed class interface* to GDI+. The following namespaces make up the managed class interface:  
  
- <xref:System.Drawing>  
  
- <xref:System.Drawing.Drawing2D>  
  
- <xref:System.Drawing.Imaging>  
  
- <xref:System.Drawing.Text>  
  
- <xref:System.Drawing.Printing>  
  
 With a Graphics Device Interface, such as GDI+, you can display information on a screen or printer without having to be concerned about the details of a particular display device. The programmer makes calls to methods provided by GDI+ classes. Those methods, in turn, make the appropriate calls to specific device drivers. GDI+ insulates the application from the graphics hardware. It is this insulation that enables a programmer to create device-independent applications.  
  
## See also

- [Graphics Overview](graphics-overview-windows-forms.md)
