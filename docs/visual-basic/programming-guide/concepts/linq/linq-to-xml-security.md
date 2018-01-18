---
title: "LINQ to XML Security (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d99b4af2-d447-4a3b-991b-6da0231a8637
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# LINQ to XML Security (Visual Basic)
This topic describes security issues associated with LINQ to XML. In addition, it provides some guidance for mitigating security exposure.  
  
## LINQ to XML Security Overview  
 LINQ to XML is designed more for programming convenience than for server-side applications with stringent security requirements. Most XML scenarios consist of processing trusted XML documents, rather than processing untrusted XML documents that are uploaded to a server. LINQ to XML is optimized for these scenarios.  
  
 If you must process untrusted data from unknown sources, Microsoft recommends that you use an instance of the <xref:System.Xml.XmlReader> class that has been configured to filter out known XML denial of service (DoS) attacks.  
  
 If you have configured an <xref:System.Xml.XmlReader> to mitigate denial of service attacks, you can use that reader to populate a LINQ to XML tree and still benefit from the programmer productivity enhancements of LINQ to XML. Many mitigation techniques involve creating readers that are configured to mitigate the security issue, and then instantiating an XML tree through the configured reader.  
  
 XML is intrinsically vulnerable to denial of service attacks because documents are unbounded in size, depth, element name size, and more. Regardless of the component that you use to process XML, you should always be prepared to recycle the application domain if it uses excessive resources.  
  
## Mitigation of XML, XSD, XPath, and XSLT Attacks  
 LINQ to XML is built upon <xref:System.Xml.XmlReader> and <xref:System.Xml.XmlWriter>. LINQ to XML supports XSD and XPath through extension methods in the <xref:System.Xml.Schema?displayProperty=nameWithType> and <xref:System.Xml.XPath?displayProperty=nameWithType> namespaces. Using the <xref:System.Xml.XmlReader>, <xref:System.Xml.XPath.XPathNavigator>, and <xref:System.Xml.XmlWriter> classes in conjunction with LINQ to XML, you can invoke XSLT to transform XML trees.  
  
 If you are operating in a less secure environment, there are a number of security issues that are associated with XML and the use of the classes in <xref:System.Xml?displayProperty=nameWithType>, <xref:System.Xml.Schema?displayProperty=nameWithType>, <xref:System.Xml.XPath?displayProperty=nameWithType>, and <xref:System.Xml.Xsl?displayProperty=nameWithType>. These issues include, but are not limited to, the following:  
  
-   XSD, XPath, and XSLT are string-based languages in which you can specify operations that consume a lot of time or memory. It is the responsibility of application programmers who take XSD, XPath, or XSLT strings from untrusted sources to validate that the strings are not malicious, or to monitor and mitigate the possibility that evaluating these strings will lead to excessive system resource consumption.  
  
-   XSD schemas (including inline schemas) are inherently vulnerable to denial of service attacks; you should not accept schemas from untrusted sources.  
  
-   XSD and XSLT can include references to other files, and such references can result in cross-zone and cross-domain attacks.  
  
-   External entities in DTDs can result in cross-zone and cross-domain attacks.  
  
-   DTDs are vulnerable to denial of service attacks.  
  
-   Exceptionally deep XML documents can pose denial of service issues; you might want to limit the depth of XML documents.  
  
-   Do not accept supporting components, such as <xref:System.Xml.NameTable>, <xref:System.Xml.XmlNamespaceManager>, and <xref:System.Xml.XmlResolver> objects, from untrusted assemblies.  
  
-   Read data in chunks to mitigate large document attacks.  
  
-   Script blocks in XSLT style sheets can expose a number of attacks.  
  
-   Validate carefully before constructing dynamic XPath expressions.  
  
## LINQ to XML Security Issues  
 The security issues in this topic are not presented in any particular order. All issues are important and should be addressed as appropriate.  
  
 A successful elevation of privilege attack gives a malicious assembly more control over its environment. A successful elevation of privilege attack can result in disclosure of data, denial of service, and more.  
  
 Applications should not disclose data to users who are not authorized to see that data.  
  
 Denial of service attacks cause the XML parser or LINQ to XML to consume excessive amounts of memory or CPU time. Denial of service attacks are considered to be less severe than elevation of privilege attacks or disclosure of data attacks. However, they are important in a scenario where a server needs to process XML documents from untrusted sources.  
  
### Exceptions and Error Messages Might Reveal Data  
 The description of an error might reveal data, such as the data being transformed, file names, or implementation details. Error messages should not be exposed to callers that are not trusted. You should catch all errors and report errors with your own custom error messages.  
  
### Do Not Call CodeAccessPermissions.Assert in an Event Handler  
 An assembly can have lesser or greater permissions. An assembly that has greater permissions has greater control over the computer and its environments.  
  
 If code in an assembly with greater permissions calls <xref:System.Security.CodeAccessPermission.Assert%2A?displayProperty=nameWithType> in an event handler, and then the XML tree is passed to a malicious assembly that has restricted permissions, the malicious assembly can cause an event to be raised. Because the event runs code that is in the assembly with greater permissions, the malicious assembly would then be operating with elevated privileges.  
  
 Microsoft recommends that you never call <xref:System.Security.CodeAccessPermission.Assert%2A?displayProperty=nameWithType> in an event handler.  
  
### DTDs are Not Secure  
 Entities in DTDs are inherently not secure. It is possible for a malicious XML document that contains a DTD to cause the parser to use all memory and CPU time, causing a denial of service attack. Therefore, in LINQ to XML, DTD processing is turned off by default. You should not accept DTDs from untrusted sources.  
  
 One example of accepting DTDs from untrusted sources is a Web application that allows Web users to upload an XML file that references a DTD and a DTD file. Upon validation of the file, a malicious DTD could execute a denial of service attack on your server. Another example of accepting DTDs from untrusted sources is to reference a DTD on a network share that also allows anonymous FTP access.  
  
### Avoid Excessive Buffer Allocation  
 Application developers should be aware that extremely large data sources can lead to resource exhaustion and denial of service attacks.  
  
 If a malicious user submits or uploads a very large XML document, it could cause LINQ to XML to consume excessive system resources. This can constitute a denial of service attack. To prevent this, you can set the <xref:System.Xml.XmlReaderSettings.MaxCharactersInDocument%2A?displayProperty=nameWithType> property, and create a reader that is then limited in the size of document that it can load. You then use the reader to create the XML tree.  
  
 For example, if you know that the maximum expected size of your XML documents coming from an untrusted source will be less than 50K bytes, set <xref:System.Xml.XmlReaderSettings.MaxCharactersInDocument%2A?displayProperty=nameWithType> to 100,000. This will not encumber your processing of XML documents, and at the same time it will mitigate denial of service threats where documents might be uploaded that would consume large amounts of memory.  
  
### Avoid Excess Entity Expansion  
 One of the known denial of service attacks when using a DTD is a document that causes excessive entity expansion. To prevent this, you can set the <xref:System.Xml.XmlReaderSettings.MaxCharactersFromEntities%2A?displayProperty=nameWithType> property, and create a reader that is then limited in the number of characters that result from entity expansion. You then use the reader to create the XML tree.  
  
### Limit the Depth of the XML Hierarchy  
 One possible denial of service attack is when a document is submitted that has excessive depth of hierarchy. To prevent this, you can wrap a <xref:System.Xml.XmlReader> in your own class that counts the depth of elements. If the depth exceeds a predetermined reasonable level, you can terminate the processing of the malicious document.  
  
### Protect Against Untrusted XmlReader or XmlWriter Implementations  
 Administrators should verify that any externally supplied <xref:System.Xml.XmlReader> or <xref:System.Xml.XmlWriter> implementations have strong names and have been registered in the machine configuration. This prevents malicious code masquerading as a reader or writer from being loaded.  
  
### Periodically Free Objects that Reference XName  
 To protect against certain kinds of attacks, application programmers should free all objects that reference an <xref:System.Xml.Linq.XName> object in the application domain on a regular basis.  
  
### Protect Against Random XML Names  
 Applications that take data from untrusted sources should consider using an <xref:System.Xml.XmlReader> that is wrapped in custom code to inspect for the possibility of random XML names and namespaces. If such random XML names and namespaces are detected, the application can then terminate the processing of the malicious document.  
  
 You might want to limit the number of names in any given namespace (including names in no namespace) to a reasonable limit.  
  
### Annotations Are Accessible by Software Components that Share a LINQ to XML Tree  
 LINQ to XML could be used to build processing pipelines in which different application components load, validate, query, transform, update, and save XML data that is passed between components as XML trees. This can help optimize performance, because the overhead of loading and serializing objects to XML text is done only at the ends of the pipeline. Developers must be aware, however, that all annotations and event handlers created by one component are accessible to other components. This can create a number of vulnerabilities if the components have different levels of trust. To build secure pipelines across less trusted components, you must serialize LINQ to XML objects to XML text before passing the data to an untrusted component.  
  
 Some security is provided by the common language runtime (CLR). For example, a component that does not include a private class cannot access annotations keyed by that class. However, annotations can be deleted by components that cannot read them. This could be used as a tampering attack.  
  
## See Also  
 [Programming Guide (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/programming-guide-linq-to-xml.md)
