<!--<snippet3>-->
<!--Stylesheet to sort all books by title-->
<!--Created 2/13/2001-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="bookstore">
      <books>
        <xsl:apply-templates select="book">
          <xsl:sort select="title"/>
        </xsl:apply-templates>
       </books>
   </xsl:template>
  <xsl:template match="book">
          <book><xsl:copy-of select="node()"/></book>
  </xsl:template>
</xsl:stylesheet>
<!--</snippet3>-->
