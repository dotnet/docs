<!--<snippet4>-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:template match="bookstore">
  <HTML>
    <BODY>
    <TABLE BORDER="2">
      <TR>
        <TD>ISBN</TD>
        <TD>Title</TD>
        <TD>Price</TD>
      </TR>
    <xsl:apply-templates select="book">
      <xsl:sort select="@ISBN"/>
    </xsl:apply-templates>
    </TABLE>
    </BODY>
  </HTML>
</xsl:template>
</xsl:stylesheet>
<!--</snippet4>-->