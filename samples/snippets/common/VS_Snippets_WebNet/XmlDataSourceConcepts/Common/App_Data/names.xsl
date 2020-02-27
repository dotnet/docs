<!-- <Snippet6> -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="People">
  <Names>
    <xsl:apply-templates select="Person"/>
  </Names>
</xsl:template>

<xsl:template match="Person">
  <xsl:apply-templates select="Name"/>
</xsl:template>

<xsl:template match="Name">
  <name><xsl:value-of select="LastName"/>, <xsl:value-of select="FirstName"/></name>
</xsl:template>

</xsl:stylesheet>
<!-- </Snippet6> -->
