<!--<snippet3>-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:param name="date"/>
  <xsl:template match="/">
    <order>
      <date><xsl:value-of select="$date"/></date>
      <total><xsl:value-of select="sum(//price)"/></total>
    </order>
  </xsl:template>
</xsl:stylesheet>
<!--</snippet3>-->
