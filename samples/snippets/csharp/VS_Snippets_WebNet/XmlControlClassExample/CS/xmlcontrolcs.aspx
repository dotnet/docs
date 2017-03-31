<!-- <Snippet1> -->
<!-- 
This sample shows an Xml control using the
DocumentSource and TransformSource properties to display Xml data
in the control.
Create a sample XML file called People.xml and 
and a sample XSL Transform file called Peopletable.xsl
using the code at the end of this sample.
-->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.Xml.Xsl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Xml Class Example</title>
</head>
<body>
   <h3>Xml Example</h3>
      <form id="form1" runat="server">
          <asp:Xml id="xml1" runat="server" DocumentSource="~/people.xml"
          TransformSource="~/peopletable.xsl" />     
      </form>
</body>
</html>

<!-- 
For this example to work, paste the following code into a file
named peopletable.xsl. Store the file in the same directory as
your .aspx file.

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
   <xsl:template match="/People">
      <xsl:apply-templates select="Person" />
   </xsl:template>
  
   <xsl:template match="Person">
      <table width="80%" border="1">
         <tr>
            <td>
               <b>
                  <xsl:value-of select="Name/FirstName" />
                  &#160;
                  <xsl:value-of select="Name/LastName" />
               </b>
            </td>
         </tr>
         <tr>
            <td>
               <xsl:value-of select="Address/Street" /><br />
               <xsl:value-of select="Address/City" />
               , 
               <xsl:value-of select="Address/State" /> 
               <xsl:value-of select="Address/Zip" />
            </td>
         </tr>
         <tr>
            <td>
               Job Title: <xsl:value-of select="Job/Title" /><br />
               Description: <xsl:value-of select="Job/Description" />
            </td>
         </tr>
      </table>
   </xsl:template>

   <xsl:template match="bookstore">
      <bookstore>
         <xsl:apply-templates select="book"/>
      </bookstore>
   </xsl:template>

   <xsl:template match="book">
      <book>
         <xsl:attribute name="ISBN">
            <xsl:value-of select="@ISBN"/>
         </xsl:attribute>
         <price>
            <xsl:value-of select="price"/>
         </price>
         <xsl:text>
         </xsl:text>
      </book>
   </xsl:template>

</xsl:stylesheet>


-->

<!--
For this example to work, paste the following code into a file 
named people.xml. Store the file in the same directory as 
your .aspx file.

<?xml version="1.0" encoding="utf-8" ?>
<People>
   <Person>
      <Name>
         <FirstName>Joe</FirstName>
         <LastName>Suits</LastName>
      </Name>
      <address>
         <Street>1800 Success Way</Street>
         <City>Redmond</City>
         <State>WA</State>
         <ZipCode>98052</ZipCode>
      </address>
      <Job>
         <title>CEO</title>
         <Description>Runs the company</Description>
      </Job>
   </Person>

   <Person>
      <Name>
         <FirstName>Linda</FirstName>
         <LastName>Sue</LastName>
      </Name>
      <address>
         <Street>1302 American St.</Street>
         <City>Paso Robles</City>
         <State>CA</State>
         <ZipCode>93447</ZipCode>
      </address>
      <Job>
         <title>Attorney</title>
         <Description>Litigates trials</Description>
      </Job>
   </Person>

   <Person>
      <Name>
         <FirstName>Jeremy</FirstName>
         <LastName>Boards</LastName>
      </Name>
      <address>
         <Street>34 Palm Avenue</Street>
         <City>Waikiki</City>
         <State>HI</State>
         <ZipCode>98052</ZipCode>
      </address>
      <Job>
         <title>Pro Surfer</title>
         <Description>Rides waves</Description>
      </Job>
   </Person>

   <Person>
      <Name>
         <FirstName>Joan</FirstName>
         <LastName>Page</LastName>
      </Name>
      <address>
         <Street>700 Webmaster Road</Street>
         <City>Redmond</City>
         <State>WA</State>
         <ZipCode>98073</ZipCode>
      </address>
      <Job>
         <title>Web Site Developer</title>
         <Description>Writes ASP.NET pages</Description>
      </Job>
   </Person>
</People>

-->
<!-- </Snippet1> -->
