<?xml version="1.0" encoding="UTF-8" ?>
<!-- <snippet4> -->
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
      <!-- Prices and books -->
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
<!-- </snippet4> -->
  