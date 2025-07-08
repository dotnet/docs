---
title: System.Xml.XmlSecureResolver class
description: Learn about the System.Xml.XmlSecureResolver class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
---
# System.Xml.XmlSecureResolver class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Xml.XmlUrlResolver> class is the default resolver for all classes in the <xref:System.Xml> namespace. It's used to load XML documents and to resolve external resources such as entities, DTDs or schemas, and import or include directives.

You can override this default by specifying the <xref:System.Xml.XmlResolver> object to use. For example, if you want to restrict the resources that the underlying <xref:System.Xml.XmlResolver> can access, you can use an <xref:System.Xml.XmlSecureResolver> object.

<xref:System.Xml.XmlSecureResolver> wraps around a concrete implementation of <xref:System.Xml.XmlResolver> and restricts the resources that the underlying <xref:System.Xml.XmlResolver> has access to. For example, <xref:System.Xml.XmlSecureResolver> has the ability to prohibit cross-domain redirection, which occurs from an embedded Uniform Resource Identifier (URI) reference.

When you construct an <xref:System.Xml.XmlSecureResolver> object, you provide a valid <xref:System.Xml.XmlResolver> implementation along with a URL, an instance of an evidence object, or a permission set, which is used by the <xref:System.Xml.XmlSecureResolver> to determine security. Either a <xref:System.Security.PermissionSet?displayProperty=nameWithType> is generated or the existing one is used and <xref:System.Security.PermissionSet.PermitOnly%2A?displayProperty=nameWithType> is called on it to help secure the underlying <xref:System.Xml.XmlResolver>.

> [!IMPORTANT]
> <xref:System.Xml.XmlSecureResolver> objects can contain sensitive information such as user credentials. Be careful when caching <xref:System.Xml.XmlSecureResolver> objects and should not pass the <xref:System.Xml.XmlSecureResolver> object to an untrusted component.

> [!IMPORTANT]
> There are differences in the security infrastructure for code running on the .NET common language runtime (CLR) and for code running on the CLR that is integrated within Microsoft SQL Server 2005. This can lead to cases where code developed for the .NET CLR operates differently when used on the SQL Server integrated CLR. One of these differences affects the <xref:System.Xml.XmlSecureResolver> class when you have evidence that is based on a URL (that is, when you use the <xref:System.Xml.XmlSecureResolver.CreateEvidenceForUrl%28System.String%29> method or the <xref:System.Xml.XmlSecureResolver.%23ctor%2A> constructor). The policy resolution mechanism of the SQL Server integrated CLR does not use the <xref:System.Security.Policy.Url> or <xref:System.Security.Policy.Zone> information. Instead, it grants permissions based on the GUID that the server adds when assemblies are loaded. When you use the <xref:System.Xml.XmlSecureResolver> in the SQL Server integrated CLR, provide any required evidence directly by using a specified <xref:System.Security.PermissionSet>.

## To use a secure resolver

1. Create an <xref:System.Xml.XmlSecureResolver> with the correct permission set.

2. Create an <xref:System.Xml.XmlReaderSettings> object that uses the <xref:System.Xml.XmlSecureResolver> object.

   :::code language="csharp" source="./snippets/System.Xml/XmlSecureResolver/Overview/csharp/XmlSecureResolver_ex.cs" id="Snippet5a":::
   :::code language="vb" source="./snippets/System.Xml/XmlSecureResolver/Overview/vb/XmlSecureResolver_ex.vb" id="Snippet5a":::

3. Pass the <xref:System.Xml.XmlReaderSettings> object to the <xref:System.Xml.XmlReader.Create%2A> method when you're creating the <xref:System.Xml.XmlReader> object.

   :::code language="csharp" source="./snippets/System.Xml/XmlSecureResolver/Overview/csharp/XmlSecureResolver_ex.cs" id="Snippet5b":::
   :::code language="vb" source="./snippets/System.Xml/XmlSecureResolver/Overview/vb/XmlSecureResolver_ex.vb" id="Snippet5b":::

## To restrict access by using a URL

Use the <xref:System.Xml.XmlSecureResolver.%23ctor%28System.Xml.XmlResolver%2CSystem.String%29> constructor to create an <xref:System.Xml.XmlSecureResolver> object that is allowed to access your local intranet site only.

:::code language="csharp" source="./snippets/System.Xml/XmlSecureResolver/Overview/csharp/XmlSecureResolver_ex.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Xml/XmlSecureResolver/Overview/vb/XmlSecureResolver_ex.vb" id="Snippet3":::

## To restrict access by using a permission set

1. Create a <xref:System.Net.WebPermission> object.

   :::code language="csharp" source="./snippets/System.Xml/XmlSecureResolver/Overview/csharp/XmlSecureResolver_ex.cs" id="Snippet4a":::
   :::code language="vb" source="./snippets/System.Xml/XmlSecureResolver/Overview/vb/XmlSecureResolver_ex.vb" id="Snippet4a":::

2. Specify the URLs that you want to allow access to.

   :::code language="csharp" source="./snippets/System.Xml/XmlSecureResolver/Overview/csharp/XmlSecureResolver_ex.cs" id="Snippet4b":::
   :::code language="vb" source="./snippets/System.Xml/XmlSecureResolver/Overview/vb/XmlSecureResolver_ex.vb" id="Snippet4b":::

3. Add the web permissions to the <xref:System.Security.PermissionSet> object.

   :::code language="csharp" source="./snippets/System.Xml/XmlSecureResolver/Overview/csharp/XmlSecureResolver_ex.cs" id="Snippet4c":::
   :::code language="vb" source="./snippets/System.Xml/XmlSecureResolver/Overview/vb/XmlSecureResolver_ex.vb" id="Snippet4c":::

4. Use the <xref:System.Xml.XmlSecureResolver.%23ctor%28System.Xml.XmlResolver%2CSystem.Security.PermissionSet%29> constructor to create an <xref:System.Xml.XmlSecureResolver> object by using the permission set.

   :::code language="csharp" source="./snippets/System.Xml/XmlSecureResolver/Overview/csharp/XmlSecureResolver_ex.cs" id="Snippet4d":::
   :::code language="vb" source="./snippets/System.Xml/XmlSecureResolver/Overview/vb/XmlSecureResolver_ex.vb" id="Snippet4d":::

   See the <xref:System.Xml.XmlSecureResolver.%23ctor%2A> reference page for another example.

## To restrict access by using evidence

You can restrict access by using the <xref:System.Xml.XmlSecureResolver.%23ctor%28System.Xml.XmlResolver%2CSystem.Security.Policy.Evidence%29> constructor and specifying <xref:System.Security.Policy.Evidence>. The <xref:System.Security.Policy.Evidence> is used to create the <xref:System.Security.PermissionSet> that is applied to the underlying <xref:System.Xml.XmlResolver>. The <xref:System.Xml.XmlSecureResolver> calls <xref:System.Security.PermissionSet.PermitOnly%2A> on the created <xref:System.Security.PermissionSet> before opening any resources.

Here are some common scenarios and the type of evidence to provide for each:

- If you are working in a fully trusted environment, use your assembly to create the evidence:

  :::code language="csharp" source="./snippets/System.Xml/XmlSecureResolver/Overview/csharp/XmlSecureResolver_ex.cs" id="Snippet1":::
  :::code language="vb" source="./snippets/System.Xml/XmlSecureResolver/Overview/vb/XmlSecureResolver_ex.vb" id="Snippet1":::

- If you are working in a semi-trusted environment, you have code or data coming from an outside source, and you know the origin of the outside source and have a verifiable URI, use the URI to create the evidence:

  :::code language="csharp" source="./snippets/System.Xml/XmlSecureResolver/Overview/csharp/XmlSecureResolver_ex.cs" id="Snippet2":::
  :::code language="vb" source="./snippets/System.Xml/XmlSecureResolver/Overview/vb/XmlSecureResolver_ex.vb" id="Snippet2":::

- If you are working in a semi-trusted environment and you have code or data coming from an outside source, but you don't know the origin of the outside source, either:

  Set the `evidence` parameter to `null`. This allows no access to resources.

     -or-

  If your application requires some access to resources, request evidence from the caller.

## To use the secure resolver to load an XSLT style sheet

1. Create an <xref:System.Xml.XmlSecureResolver> with the correct permission set.

2. Pass the <xref:System.Xml.XmlSecureResolver> to the <xref:System.Xml.Xsl.XslCompiledTransform.Load%2A> method.

   :::code language="csharp" source="./snippets/System.Xml/XmlSecureResolver/Overview/csharp/XmlSecureResolver_ex.cs" id="Snippet6":::
   :::code language="vb" source="./snippets/System.Xml/XmlSecureResolver/Overview/vb/XmlSecureResolver_ex.vb" id="Snippet6":::
