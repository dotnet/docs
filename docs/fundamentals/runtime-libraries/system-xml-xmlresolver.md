---
title: System.Xml.XmlResolver class
description: Learn more about the System.Xml.XmlResolver class through these supplemental API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# <xref:System.Xml.XmlResolver> class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Xml.XmlResolver> type is used to resolve external XML resources, such as entities, document type definitions (DTDs), or schemas. It is also used to process include and import elements found in Extensible Stylesheet Language (XSL) style sheets or XML Schema definition language (XSD) schemas.

<xref:System.Xml.XmlResolver> handles all aspects of negotiating the connection to the resources, including handling security credentials, opening the connection to the data source, and returning the resource in the form of a stream or other object type. The object that calls <xref:System.Xml.XmlResolver> has the task of interpreting the stream.

The <xref:System.Xml> namespace includes two concrete implementations of the <xref:System.Xml.XmlResolver> class:

- <xref:System.Xml.XmlUrlResolver> is the default resolver for all classes in the <xref:System.Xml> namespace. It supports the `file://` and `http://` protocols and requests from the <xref:System.Net.WebRequest?displayProperty=nameWithType> class. For examples of extending the class to improve performance, see the <xref:System.Xml.XmlUrlResolver> reference page.

- <xref:System.Xml.XmlSecureResolver> helps secure another <xref:System.Xml.XmlResolver> object by wrapping the object and restricting the resources that it can access. For example, the <xref:System.Xml.XmlSecureResolver> can prohibit access to specific Internet sites or zones.

You can create and specify your own resolver. If you don't specify a resolver, the reader uses a default <xref:System.Xml.XmlUrlResolver> with no user credentials.

You specify the <xref:System.Xml.XmlResolver> to use by setting the <xref:System.Xml.XmlReaderSettings.XmlResolver?displayProperty=nameWithType> property and passing the <xref:System.Xml.XmlReaderSettings> object to the <xref:System.Xml.XmlReader.Create%2A> method.

If the resource is stored on a system that requires authentication, you use the <xref:System.Xml.XmlResolver.Credentials?displayProperty=nameWithType> property to specify the necessary credentials.

## Supply authentication credentials

The file that contains the XML data to read may have a restricted access policy. If authentication is required to access a network resource, use the <xref:System.Xml.XmlResolver.Credentials> property to specify the necessary credentials. If the <xref:System.Xml.XmlResolver.Credentials> property is not set, credentials are set to `null`.

For example, assume that credentials are needed when requesting data from the web for authentication purposes. Unless the web virtual directory allows anonymous access, you must set the <xref:System.Xml.XmlResolver.Credentials> property to supply credentials. The following example creates an <xref:System.Xml.XmlReader> object that uses an <xref:System.Xml.XmlUrlResolver> with default credentials to access the `http://localhost/bookstore/inventory.xml` site.

:::code language="csharp" source="./snippets/System.Xml/XmlReader/Create/csharp/factory_rdr_cctor2.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Xml/XmlResolver/Overview/vb/factory_rdr_cctor2.vb" id="Snippet2":::

You can supply different credentials for different URIs and add them to a cache. These credentials are used to check authentication for the different URIs regardless of the original source of the XML. The following example shows how to add credentials to a cache.

:::code language="csharp" source="./snippets/System.Xml/XmlResolver/Overview/csharp/Xslt_Load_v2.cs" id="Snippet11":::
:::code language="vb" source="./snippets/System.Xml/XmlResolver/Overview/vb/Xslt_Load_v2.vb" id="Snippet11":::

## Security considerations

Consider the following items when working with the <xref:System.Xml.XmlResolver> class.

- <xref:System.Xml.XmlResolver> objects can contain sensitive information such as user credentials. You should be careful when caching <xref:System.Xml.XmlResolver> objects and should not pass the <xref:System.Xml.XmlResolver> object to an untrusted component.

- If you are designing a class property that uses the <xref:System.Xml.XmlResolver> class, the property should be defined as a write-only property. The property can be used to specify the <xref:System.Xml.XmlResolver> to use, but it cannot be used to return an <xref:System.Xml.XmlResolver> object.

- If your application accepts <xref:System.Xml.XmlResolver> objects from untrusted code, you cannot assume that the URI passed into the <xref:System.Xml.XmlResolver.GetEntity%2A> method will be the same as that returned by the <xref:System.Xml.XmlResolver.ResolveUri%2A> method. Classes derived from the <xref:System.Xml.XmlResolver> class can override the <xref:System.Xml.XmlResolver.GetEntity%2A> method and return data that is different than what was contained in the original URI.

- Your application can mitigate memory denial of service threats to the <xref:System.Xml.XmlResolver.GetEntity%2A> method by implementing an <xref:System.Runtime.InteropServices.ComTypes.IStream> that limits the number of bytes read. This helps guard against situations where malicious code attempts to pass an infinite stream of bytes to the <xref:System.Xml.XmlResolver.GetEntity%2A> method.
