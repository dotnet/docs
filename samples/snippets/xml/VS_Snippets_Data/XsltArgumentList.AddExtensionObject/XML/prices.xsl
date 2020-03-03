<!--<snippet3>-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:myObj="urn:price-conv">

<!--Price conversion factor-->
<xsl:param name="conv" select="1.15"/>

  <xsl:template match="bookstore">
  <bookstore>
  <xsl:for-each select="book">
    <book>
    <xsl:copy-of select="node()"/>
       <new-price>
          <xsl:value-of select="myObj:NewPriceFunc(./price, $conv)"/>        
       </new-price>
    </book>
  </xsl:for-each>
  </bookstore>
  </xsl:template>
</xsl:stylesheet>
<!--</snippet3>-->
