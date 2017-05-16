<!--<snippet2>-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:template match="/">
     <xsl:apply-templates select="*"/>
     <xsl:copy-of select="."/>
  </xsl:template>

  <xsl:template match="*">
     <xsl:apply-templates select="//author"/>
  </xsl:template>

  <xsl:template match="author">
    <xsl:if test="not (last-name)">
       <xsl:message terminate="no">Author name is not in the correct format <xsl:copy-of select="."/>
       </xsl:message>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>
<!--</snippet2>-->