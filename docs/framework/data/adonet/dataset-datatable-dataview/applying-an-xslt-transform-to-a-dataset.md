---
title: "Applying an XSLT Transform to a DataSet"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 09f2e4ee-1d08-4ba8-8936-83394fee319d
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Applying an XSLT Transform to a DataSet
The **WriteXml** method of the <xref:System.Data.DataSet> enables you to write the contents of a **DataSet** as XML data. A common task is to then transform that XML to another format using XSL transformations (XSLT). However, synchronizing a **DataSet** with an <xref:System.Xml.XmlDataDocument> enables you to apply an XSLT stylesheet to the contents of a **DataSet** without having to first write the contents of the **DataSet** as XML data using **WriteXml**.  
  
 The following example populates a **DataSet** with tables and relationships, synchronizes the **DataSet** with an **XmlDataDocument**, and writes a portion of the **DataSet** as an HTML file using an XSLT stylesheet. Following are the contents of the XSLT stylesheet.  
  
```xml  
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">  
  
<xsl:template match="CustomerOrders">  
  <HTML>  
  <STYLE>  
  BODY {font-family:verdana;font-size:9pt}  
  TD   {font-size:8pt}  
  </STYLE>  
    <BODY>  
    <TABLE BORDER="1">  
      <xsl:apply-templates select="Customers"/>  
    </TABLE>  
    </BODY>  
  </HTML>  
</xsl:template>  
  
<xsl:template match="Customers">  
    <TR><TD>  
      <xsl:value-of select="ContactName"/>, <xsl:value-of select="Phone"/><BR/>  
    </TD></TR>  
      <xsl:apply-templates select="Orders"/>  
</xsl:template>  
  
<xsl:template match="Orders">  
  <TABLE BORDER="1">  
    <TR><TD valign="top"><B>Order:</B></TD><TD valign="top"><xsl:value-of select="OrderID"/></TD></TR>  
    <TR><TD valign="top"><B>Date:</B></TD><TD valign="top"><xsl:value-of select="OrderDate"/></TD></TR>  
    <TR><TD valign="top"><B>Ship To:</B></TD>  
        <TD valign="top"><xsl:value-of select="ShipName"/><BR/>  
        <xsl:value-of select="ShipAddress"/><BR/>  
        <xsl:value-of select="ShipCity"/>, <xsl:value-of select="ShipRegion"/>  <xsl:value-of select="ShipPostalCode"/><BR/>  
        <xsl:value-of select="ShipCountry"/></TD></TR>  
  </TABLE>  
</xsl:template>  
  
</xsl:stylesheet>  
```  
  
 The following code fills the **DataSet** and applies the XSLT style sheet.  
  
> [!NOTE]
>  If you are applying an XSLT style sheet to a **DataSet** that contains relations, you achieve best performance if you set the **Nested** property of the <xref:System.Data.DataRelation> to **true** for each nested relation. This allows you to use XSLT style sheets that implement natural top-down processing to navigate the hierarchy and transform the data, as opposed to using performance-intensive XPath location axes (for example, preceding-sibling and following-sibling in style sheet node test expressions) to navigate it. For more information on nested relations, see [Nesting DataRelations](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/nesting-datarelations.md).  
  
```vb  
' Assumes connection is a valid SqlConnection.  
Dim dataSet As DataSet = New DataSet("CustomerOrders")  
  
Dim customerAdapter As SqlDataAdapter = New SqlDataAdapter( _  
  "SELECT * FROM Customers", connection)  
customerAdapter.Fill(dataSet, "Customers")  
  
Dim orderAdapter As SqlDataAdapter = New SqlDataAdapter( _  
  "SELECT * FROM Orders", connection)  
orderAdapter.Fill(dataSet, "Orders")  
  
connection.Close()  
  
dataSet.Relations.Add("CustOrders", _  
dataSet.Tables("Customers").Columns("CustomerID"), _  
dataSet.Tables("Orders").Columns("CustomerID")).Nested = true  
  
Dim xmlDoc As XmlDataDocument = New XmlDataDocument(dataSet)   
  
Dim xslTran As XslTransform = New XslTransform  
xslTran.Load("transform.xsl")  
  
Dim writer As XmlTextWriter = New XmlTextWriter( _  
  "xslt_output.html", System.Text.Encoding.UTF8)  
  
xslTran.Transform(xmlDoc, Nothing, writer)  
writer.Close()  
```  
  
```csharp  
// Assumes connection is a valid SqlConnection.  
connection.Open();  
  
DataSet custDS = new DataSet("CustomerDataSet");  
  
SqlDataAdapter customerAdapter = new SqlDataAdapter(  
  "SELECT * FROM Customers", connection);  
customerAdapter.Fill(custDS, "Customers");  
  
SqlDataAdapter orderAdapter = new SqlDataAdapter(  
  "SELECT * FROM Orders", connection);  
orderAdapter.Fill(custDS, "Orders");  
  
connection.Close();  
  
custDS.Relations.Add("CustOrders",  
  custDS.Tables["Customers"].Columns["CustomerID"],  
                     custDS.Tables["Orders"].Columns["CustomerID"]).Nested = true;  
  
XmlDataDocument xmlDoc = new XmlDataDocument(custDS);   
  
XslTransform xslTran = new XslTransform();  
xslTran.Load("transform.xsl");  
  
XmlTextWriter writer = new XmlTextWriter("xslt_output.html",   
  System.Text.Encoding.UTF8);  
  
xslTran.Transform(xmlDoc, null, writer);  
writer.Close();  
```  
  
## See Also  
 [DataSet and XmlDataDocument Synchronization](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/dataset-and-xmldatadocument-synchronization.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
