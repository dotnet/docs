<!--<snippet3>-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
  xmlns:user="urn:my-scripts">
  <msxsl:script language="C#" implements-prefix="user">
  <![CDATA[
  public double circumference(double radius){
    double pi = 3.14;
    double circ = pi*radius*2;
    return circ;
  }
  ]]>
  </msxsl:script>
  <xsl:template match="data">
    <circles>
      <xsl:for-each select="circle">
        <circle>
          <xsl:copy-of select="node()"/>
          <circumference>
            <xsl:value-of select="user:circumference(radius)"/>
          </circumference>
        </circle>
      </xsl:for-each>
    </circles>
  </xsl:template>
</xsl:stylesheet>
<!--</snippet3>-->