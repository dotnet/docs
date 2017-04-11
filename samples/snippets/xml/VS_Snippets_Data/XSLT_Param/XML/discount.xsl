<!--<snippet3>-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:param name="discount"/>
  <xsl:template match="/">
    <order>
      <xsl:variable name="sub-total" select="sum(//price)"/>
      <total><xsl:value-of select="$sub-total"/></total>
           15% discount if paid by: <xsl:value-of select="$discount"/>
     </order>
  </xsl:template>
</xsl:stylesheet>
<!--</snippet3>-->