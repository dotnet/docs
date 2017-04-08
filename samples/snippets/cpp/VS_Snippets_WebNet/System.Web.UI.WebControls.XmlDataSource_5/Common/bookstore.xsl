<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="bookstore">
  <bookstore>
    <xsl:apply-templates select="genre"/>
  </bookstore>
</xsl:template>

<xsl:template match="genre">
  <genre>
    <xsl:attribute name="name">
      <xsl:value-of select="@name"/>
    </xsl:attribute>
    <xsl:apply-templates select="book"/>
  </genre>
</xsl:template>

<xsl:template match="book">
  <book>
    <xsl:attribute name="ISBN">
      <xsl:value-of select="@ISBN"/>
    </xsl:attribute>
    <xsl:attribute name="title">
      <xsl:value-of select="title"/>
    </xsl:attribute>
    <xsl:attribute name="price">
      <xsl:value-of select="price"/>
    </xsl:attribute>
    <xsl:apply-templates select="chapters/chapter" />
  </book>
</xsl:template>

<xsl:template match="chapter">
  <chapter>
    <xsl:attribute name="num">
      <xsl:value-of select="@num"/>
    </xsl:attribute>
    <xsl:attribute name="name">
      <xsl:value-of select="@name"/>
    </xsl:attribute>
    <xsl:apply-templates/>
  </chapter>
</xsl:template>

</xsl:stylesheet>
