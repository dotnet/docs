---
title: System.Xml.Xsl.XslCompiledTransform class
description: Learn about the System.Xml.Xsl.XslCompiledTransform class.
ms.date: 12/31/2023
---
# System.Xml.Xsl.XslCompiledTransform class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Xml.Xsl.XslCompiledTransform> class is an XSLT processor that supports the XSLT 1.0 syntax. It is a new implementation and includes performance gains when compared to the obsolete <xref:System.Xml.Xsl.XslTransform> class. The structure of the <xref:System.Xml.Xsl.XslCompiledTransform> class is very similar to the <xref:System.Xml.Xsl.XslTransform> class. The <xref:System.Xml.Xsl.XslCompiledTransform.Load%2A> method loads and compiles the style sheet, while the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method executes the XSLT transform.

Support for the XSLT `document()` function and embedded script blocks are disabled by default. These features can be enabled by creating an <xref:System.Xml.Xsl.XsltSettings> object and passing it to the <xref:System.Xml.Xsl.XslCompiledTransform.Load%2A> method.

For more information, see [Using the XslCompiledTransform Class](../../standard/data/xml/using-the-xslcompiledtransform-class.md) and [Migrating From the XslTransform Class](../../standard/data/xml/migrating-from-the-xsltransform-class.md).

## Security considerations

When creating an application that uses the <xref:System.Xml.Xsl.XslCompiledTransform> class, you should be aware of the following items and their implications:

- XSLT scripting is disabled by default. XSLT scripting should be enabled only if you require script support and you are working in a fully trusted environment.

- The XSLT `document()` function is disabled by default. If you enable the `document()` function, restrict the resources that can be accessed by passing an <xref:System.Xml.XmlSecureResolver> object to the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method.

- Extension objects are enabled by default. If an <xref:System.Xml.Xsl.XsltArgumentList> object containing extension objects is passed to the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method, they are utilized.

- XSLT style sheets can include references to other files and embedded script blocks. A malicious user can exploit this by supplying you with data or style sheets that when executed can cause your system to process until the computer runs low on resources.

- XSLT applications that run in a mixed trust environment can result in style sheet spoofing. For example, a malicious user can load an object with a harmful style sheet and hand it off to another user who subsequently calls the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method and executes the transformation.

These security issues can be mitigated by not enabling scripting or the `document()` function unless the style sheet comes from a trusted source, and by not accepting <xref:System.Xml.Xsl.XslCompiledTransform> objects, XSLT style sheets, or XML source data from an untrusted source.
