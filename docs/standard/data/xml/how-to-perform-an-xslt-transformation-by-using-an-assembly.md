---
title: "How to: Perform an XSLT Transformation by Using an Assembly"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 76ee440b-d134-4f8f-8262-b917ad6dcbf6
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Perform an XSLT Transformation by Using an Assembly
The XSLT compiler (xsltc.exe) compiles XSLT style sheets and generates an assembly. The assembly can be passed directly into the <xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.Type%29?displayProperty=nameWithType> method.  
  
### To copy the XML and XSLT files to your local computer  
  
-   Copy the XSLT file to your local computer and name it Transform.xsl.  
  
    ```xml  
    <xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"  
      xmlns:msxsl="urn:schemas-microsoft-com:xslt"  
      xmlns:user="urn:my-scripts">  
      <msxsl:script language="C#" implements-prefix="user">  
        <![CDATA[  
      public string discount(string price){  
        char[] trimChars = { '$' };  
        //trim leading $, convert price to type double  
        double discount_value = Convert.ToDouble(price.TrimStart(trimChars));  
        //apply 10% discount and round appropriately  
        discount_value = .9*discount_value;  
        //convert value to decimal and format as currency  
        string discount_price = discount_value.ToString("C");  
        return discount_price;  
      }  
      ]]>  
      </msxsl:script>  
      <xsl:template match="catalog">  
        <html>  
          <head></head>  
          <body>  
            <table border="1">  
              <tr>  
                <th align="left">Title</th>  
                <th align="left">Author</th>  
                <th align="left">Genre</th>  
                <th align="left">Publish Date</th>  
                <th align="left">Price</th>  
              </tr>  
              <xsl:for-each select="book">  
                <tr>  
                  <td>  
                    <xsl:value-of select="title"/>  
                  </td>  
                  <td>  
                    <xsl:value-of select="author"/>  
                  </td>  
                  <td>  
                    <xsl:value-of select="genre"/>  
                  </td>  
                  <td>  
                    <xsl:value-of select="publish_date"/>  
                  </td>  
                  <xsl:choose>  
                    <xsl:when test="genre = 'Fantasy'">  
                      <td>  
                        <xsl:value-of select="user:discount(price)"/>  
                      </td>  
                    </xsl:when>  
                    <xsl:otherwise>  
                      <td>  
                        <xsl:value-of select="price"/>  
                      </td>  
                    </xsl:otherwise>  
                  </xsl:choose>  
                </tr>  
              </xsl:for-each>  
            </table>  
          </body>  
        </html>  
      </xsl:template>  
    </xsl:stylesheet>  
    ```  
  
-   Copy the XML file to your local computer and name it `books.xml`.  
  
    ```xml  
    <?xml version="1.0"?>  
    <catalog>  
       <book id="bk101">  
          <author>Gambardella, Matthew</author>  
          <title>XML Developer's Guide</title>  
          <genre>Computer</genre>  
          <price>$44.95</price>  
          <publish_date>2000-10-01</publish_date>  
       </book>  
       <book id="bk102">  
          <author>Ralls, Kim</author>  
          <title>Midnight Rain</title>  
          <genre>Fantasy</genre>  
          <price>$5.95</price>  
          <publish_date>2000-12-16</publish_date>  
       </book>  
       <book id="bk103">  
          <author>Corets, Eva</author>  
          <title>Maeve Ascendant</title>  
          <genre>Fantasy</genre>  
          <price>$5.95</price>  
          <publish_date>2000-11-17</publish_date>  
       </book>  
       <book id="bk106">  
          <author>Randall, Cynthia</author>  
          <title>Lover Birds</title>  
          <genre>Romance</genre>  
          <price>$4.95</price>  
          <publish_date>2000-09-02</publish_date>  
       </book>  
       <book id="bk107">  
          <author>Thurman, Paula</author>  
          <title>Splish Splash</title>  
          <genre>Romance</genre>  
          <price>$4.95</price>  
          <publish_date>2000-11-02</publish_date>  
       </book>  
    </catalog>  
    ```  
  
### To compile the style sheet with the script enabled.  
  
1.  Executing the following command from the command line creates two assemblies named `Transform.dll` and `Transform_Script1.dll` (This is the default behavior. Unless otherwise specified, the name of the class and the assembly defaults to the name of the main style sheet):  
  
    ```  
    xsltc /settings:script+ Transform.xsl  
    ```  
  
 The following command explicitly sets the class name to Transform:  
  
```  
xsltc /settings:script+ /class:Transform Transform.xsl  
```  
  
### To include the compiled assembly as a reference when you compile your code.  
  
1.  You can include an assembly in Visual Studio by adding a reference in the Solution Explorer, or from the command line.  
  
2.  For the command line with C#, use the following:  
  
    ```  
    csc myCode.cs /r:system.dll;system.xml.dll;Transform.dll  
    ```  
  
3.  For the command line with Visual Basic, use the following  
  
    ```  
    vbc myCode.vb /r:system.dll;system.xml.dll;Transform.dll  
    ```  
  
### To use the compiled assembly in your code.  
  
1.  The following example shows how to execute the XSLT transformation by using the compiled style sheet.  
  
 [!code-csharp[XslTransform_XSLTC#1](../../../../samples/snippets/csharp/VS_Snippets_Data/XslTransform_XSLTC/CS/XslTransform_XSLTC.cs#1)]
 [!code-vb[XslTransform_XSLTC#1](../../../../samples/snippets/visualbasic/VS_Snippets_Data/XslTransform_XSLTC/VB/XslTransform_XSLTC.vb#1)]  
  
 To dynamically link to the compiled assembly, replace  
  
```  
xslt.Load(typeof(Transform))  
```  
  
 with  
  
```  
xslt.Load(System.Reflection.Assembly.Load("Transform").GetType("Transform"))  
```  
  
 in the example above. For more information on the Assembly.Load method, see <xref:System.Reflection.Assembly.Load%2A>  
  
## See Also  
 <xref:System.Xml.Xsl.XslCompiledTransform>  
 [XSLT Compiler (xsltc.exe)](../../../../docs/standard/data/xml/xslt-compiler-xsltc-exe.md)  
 [XSLT Transformations](../../../../docs/standard/data/xml/xslt-transformations.md)  
 [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md)
