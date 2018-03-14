<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
  xmlns:user="urn:my-scripts">
  <msxsl:script language="C#" implements-prefix="user">
    <![CDATA[
  public string discount(string price){
    char[] trimChars = { '$' };
    //trim leading $, convert price to type double
    double discount_value = Convert.ToDouble(price.TrimStart(trimChars));
    //apply 10% discount and round appropriately
    discount_value = .9*discount_value;
    //convert value to decimal and format as currency
    string discount_price = discount_value.ToString("C");
    return discount_price;
  }
  ]]>
  </msxsl:script>
  <xsl:template match="catalog">
    <html>
      <head></head>
      <body>
        <table border="1">
          <tr>
            <th align="left">Title</th>
            <th align="left">Author</th>
            <th align="left">Genre</th>
            <th align="left">Publish Date</th>
            <th align="left">Price</th>
          </tr>
          <xsl:for-each select="book">
            <tr>
              <td>
                <xsl:value-of select="title"/>
              </td>
              <td>
                <xsl:value-of select="author"/>
              </td>
              <td>
                <xsl:value-of select="genre"/>
              </td>
              <td>
                <xsl:value-of select="publish_date"/>
              </td>
              <!--<td><xsl:value-of select="user:discount(price)"/></td>-->
              <xsl:choose>
                <xsl:when test="genre = 'Fantasy'">
                  <td>
                    <xsl:value-of select="user:discount(price)"/>
                  </td>
                </xsl:when>
                <xsl:otherwise>
                  <td>
                    <xsl:value-of select="price"/>
                  </td>
                </xsl:otherwise>
              </xsl:choose>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
