<!--<snippet3>-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:output method="text" omit-xml-declaration="yes"/>
  <xsl:template match="bookstore">
      Sorted Book Titles:
        <xsl:apply-templates select="book">
          <xsl:sort select="title"/>
        </xsl:apply-templates>
   </xsl:template>
  <xsl:template match="book">
          Title:  <xsl:value-of select="node()"/>
  </xsl:template>
</xsl:stylesheet>
<!--</snippet3>-->

