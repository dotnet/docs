<!-- <Snippet5> -->
<!--
To see this code snippet used in a complete example, see the 
XML Class page.
-->
<!-- </Snippet5> -->

<!-- <Snippet1> -->
<!-- <Snippet2> -->
<!-- 
The following example demonstrates how to create XmlDocument and 
XslTransform objects from the sample XML and XSL Transform files. 
The objects are then used by the Xml control to display the XML 
document. Make sure the sample XML file is called People.xml and 
the sample XSL Transform file is called Peopletable.xsl.
-->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.Xml.Xsl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
      void Page_Load(Object sender, EventArgs e) 
      {
//<Snippet3>
         XmlDocument doc = new XmlDocument();
         doc.Load(Server.MapPath("people.xml"));
//</Snippet3>

//<Snippet4>
         XslTransform trans = new XslTransform();
         trans.Load(Server.MapPath("peopletable.xsl"));
//</Snippet4>

         xml1.Document = doc;
         xml1.Transform = trans;
      }
   </script>
<head runat="server">
    <title>Xml Class Example</title>
</head>
<body>
   <h3>Xml Example</h3>
      <form id="form1" runat="server">
         <asp:Xml id="xml1" runat="server" />
      </form>
</body>
</html>

<!-- </Snippet2> -->

<!-- 
For this example to work, paste the following code into a file
named peopletable.xsl. Store the file in the same directory as
your .aspx file.

<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/People">
    <xsl:apply-templates select="Person" />
  </xsl:template>

  <xsl:template match="Person">
    <table width="100%" border="1">
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
    <Address>
      <Street>1800 Success Way</Street>
      <City>Redmond</City>
      <State>WA</State>
      <ZipCode>98052</ZipCode>
    </Address>
    <Job>
      <Title>CEO</Title>
      <Description>Wears the nice suit</Description>
    </Job>
  </Person>

  <Person>
    <Name>
      <FirstName>Linda</FirstName>
      <LastName>Sue</LastName>
    </Name>
    <Address>
      <Street>1302 American St.</Street>
      <City>Paso Robles</City>
      <State>CA</State>
      <ZipCode>93447</ZipCode>
    </Address>
    <Job>
      <Title>Attorney</Title>
      <Description>Stands up for justice</Description>
    </Job>
  </Person>

  <Person>
    <Name>
      <FirstName>Jeremy</FirstName>
      <LastName>Boards</LastName>
    </Name>
    <Address>
      <Street>34 Palm Avenue</Street>
      <City>Waikiki</City>
      <State>HI</State>
      <ZipCode>98052</ZipCode>
    </Address>
    <Job>
      <Title>Pro Surfer</Title>
      <Description>Rides the big waves</Description>
    </Job>
  </Person>

  <Person>
    <Name>
      <FirstName>Joan</FirstName>
      <LastName>Page</LastName>
    </Name>
    <Address>
      <Street>700 Webmaster Road</Street>
      <City>Redmond</City>
      <State>WA</State>
      <ZipCode>98073</ZipCode>
    </Address>
    <Job>
      <Title>Web Site Developer</Title>
      <Description>Writes the pretty pages</Description>
    </Job>
  </Person>
</People>

-->
<!-- </Snippet1> -->
