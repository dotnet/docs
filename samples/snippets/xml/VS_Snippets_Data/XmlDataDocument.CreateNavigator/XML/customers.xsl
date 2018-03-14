<!--<snippet2>-->
<!-- Stylesheet to sort customers by city-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

  <xsl:template match="NewDataSet">
    <HTML>
      <BODY>
        <TABLE BORDER="2">
          <TR>
            <TD>Company Name</TD>
            <TD>Contact Name</TD>
            <TD>City</TD>
          </TR>
         <xsl:apply-templates select="Customers">
            <xsl:sort select="City"/>
         </xsl:apply-templates>
        </TABLE>
      </BODY>
    </HTML>
  </xsl:template>

  <xsl:template match="Customers">
    <TR>
      <TD><xsl:value-of select="CompanyName"/></TD>
      <TD><xsl:value-of select="ContactName"/></TD>
      <TD><xsl:value-of select="City"/></TD>
    </TR>
  </xsl:template>

</xsl:stylesheet>
<!--</snippet2>-->
