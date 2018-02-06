---
title: "How to: Transform XML by Using LINQ (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "XML [Visual Basic], transforming"
  - "LINQ to XML [Visual Basic], transforming XML"
ms.assetid: 815687f4-0bc2-4c0b-adc6-d78744aa356f
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Transform XML by Using LINQ (Visual Basic)
[XML Literals](../../../../visual-basic/language-reference/xml-literals/index.md) make it easy to read XML from one source and transform it to a new XML format. You can take advantage of LINQ queries to retrieve the content to transform, or change content in an existing document to a new XML format.  
  
 The example in this topic transforms content from an XML source document to HTML to be viewed in a browser.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To transform an XML document  
  
1.  In Visual Studio, create a new Visual Basic project in the **Console Application** project template.  
  
2.  Double-click the Module1.vb file created in the project to modify the Visual Basic code. Add the following code to the `Sub Main` of the `Module1` module. This code creates the source XML document as an <xref:System.Xml.Linq.XDocument> object.  
  
    ```vb  
    Dim catalog =   
      <?xml version="1.0"?>  
        <Catalog>  
          <Book id="bk101">  
            <Author>Garghentini, Davide</Author>  
            <Title>XML Developer's Guide</Title>  
            <Price>44.95</Price>  
            <Description>  
              An in-depth look at creating applications  
              with <technology>XML</technology>. For   
              <audience>beginners</audience> or   
              <audience>advanced</audience> developers.  
            </Description>  
          </Book>  
          <Book id="bk331">  
            <Author>Spencer, Phil</Author>  
            <Title>Developing Applications with Visual Basic .NET</Title>  
            <Price>45.95</Price>  
            <Description>  
              Get the expert insights, practical code samples,   
              and best practices you need   
              to advance your expertise with <technology>Visual   
              Basic .NET</technology>.   
              Learn how to create faster, more reliable applications  
              based on professional,   
              pragmatic guidance by today's top <audience>developers</audience>.  
            </Description>  
          </Book>  
        </Catalog>  
    ```  
  
     [How to: Load XML from a File, String, or Stream](../../../../visual-basic/programming-guide/language-features/xml/how-to-load-xml-from-a-file-string-or-stream.md).  
  
3.  After the code to create the source XML document, add the following code to retrieve all the \<Book> elements from the object and transform them into an HTML document. The list of \<Book> elements is created by using a LINQ query that returns a collection of <xref:System.Xml.Linq.XElement> objects that contain the transformed HTML. You can use embedded expressions to put the values from the source document in the new XML format.  
  
     The resulting HTML document is written to a file by using the <xref:System.Xml.Linq.XElement.Save%2A> method.  
  
    ```vb  
    Dim htmlOutput =   
      <html>  
        <body>  
          <%= From book In catalog.<Catalog>.<Book>   
              Select <div>  
                       <h1><%= book.<Title>.Value %></h1>  
                       <h3><%= "By " & book.<Author>.Value %></h3>  
                        <h3><%= "Price = " & book.<Price>.Value %></h3>  
                        <h2>Description</h2>  
                        <%= TransformDescription(book.<Description>(0)) %>  
                        <hr/>  
                      </div> %>  
        </body>  
      </html>  
  
    htmlOutput.Save("BookDescription.html")  
    ```  
  
4.  After `Sub Main` of `Module1`, add a new method (`Sub`) to transform a \<Description> node into the specified HTML format. This method is called by the code in the previous step and is used to preserve the format of the \<Description> elements.  
  
     This method replaces sub-elements of the \<Description> element with HTML. The `ReplaceWith` method is used to preserve the location of the sub-elements. The transformed content of the \<Description> element is included in an HTML paragraph (\<p>) element. The <xref:System.Xml.Linq.XContainer.Nodes%2A> property is used to retrieve the transformed content of the \<Description> element. This ensures that sub-elements are included in the transformed content.  
  
     Add the following code after `Sub Main` of `Module1`.  
  
    ```vb  
    Public Function TransformDescription(ByVal desc As XElement) As XElement  
  
      ' Replace <technology> elements with <b>.  
      Dim content = (From element In desc...<technology>).ToList()  
  
      If content.Count > 0 Then  
        For i = 0 To content.Count - 1  
          content(i).ReplaceWith(<b><%= content(i).Value %></b>)  
        Next  
      End If  
  
      ' Replace <audience> elements with <i>.  
      content = (From element In desc...<audience>).ToList()  
  
      If content.Count > 0 Then  
        For i = 0 To content.Count - 1  
          content(i).ReplaceWith(<i><%= content(i).Value %></i>)  
        Next  
      End If  
  
      ' Return the updated contents of the <Description> element.  
      Return <p><%= desc.Nodes %></p>  
    End Function  
    ```  
  
5.  Save your changes.  
  
6.  Press F5 to run the code. The resulting saved document will resemble the following:  
  
    ```  
    <?xml version="1.0"?>  
    <html>  
      <body>  
        <div>  
          <h1>XML Developer's Guide</h1>  
          <h3>By Garghentini, Davide</h3>  
          <h3>Price = 44.95</h3>  
          <h2>Description</h2>  
          <p>  
            An in-depth look at creating applications  
            with <b>XML</b>. For   
            <i>beginners</i> or   
            <i>advanced</i> developers.  
          </p>  
          <hr />  
        </div>  
        <div>  
          <h1>Developing Applications with Visual Basic .NET</h1>  
          <h3>By Spencer, Phil</h3>  
          <h3>Price = 45.95</h3>  
          <h2>Description</h2>  
          <p>  
            Get the expert insights, practical code   
            samples, and best practices you need   
            to advance your expertise with <b>Visual   
            Basic .NET</b>. Learn how to create faster,  
            more reliable applications based on  
            professional, pragmatic guidance by today's   
            top <i>developers</i>.  
          </p>  
          <hr />  
        </div>  
      </body>  
    </html>  
    ```  
  
## See Also  
 [XML Literals](../../../../visual-basic/language-reference/xml-literals/index.md)  
 [Manipulating XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/manipulating-xml.md)  
 [XML](../../../../visual-basic/programming-guide/language-features/xml/index.md)  
 [How to: Load XML from a File, String, or Stream](../../../../visual-basic/programming-guide/language-features/xml/how-to-load-xml-from-a-file-string-or-stream.md)  
 [LINQ](../../../../visual-basic/programming-guide/language-features/linq/index.md)  
 [Introduction to LINQ in Visual Basic](../../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)
