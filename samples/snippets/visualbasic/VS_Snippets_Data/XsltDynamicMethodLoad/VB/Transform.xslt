<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
  xmlns:user="urn:my-scripts">
  <msxsl:script language="C#" implements-prefix="user">
    <![CDATA[
  public double modifyPrice(double price){
    price*=0.9;
    return price;
  }
  ]]>
  </msxsl:script>
  <xsl:template match="Root">
    <Root xmlns="">
      <Price><xsl:value-of select="user:modifyPrice(Price)"/></Price>
    </Root>
  </xsl:template>
</xsl:stylesheet>
