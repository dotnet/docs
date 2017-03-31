<!--<snippet3>-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="bookstore"/>
  <xsl:include href="http://serverA/includefile.xsl"/>  
  <xsl:template match="book">
     <TR>
      <TD><xsl:value-of select="@ISBN"/></TD>
      <TD><xsl:value-of select="title"/></TD>
      <TD><xsl:value-of select="price"/></TD>
    </TR>
  </xsl:template>
</xsl:stylesheet>
<!--</snippet3>-->
