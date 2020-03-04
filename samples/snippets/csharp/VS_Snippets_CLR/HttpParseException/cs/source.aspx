<!-- <Snippet1> -->
<%@ Page Language="C#"%>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS" Assembly="Samples.AspNet.CS" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpParseException Example</title>
</head>
  <body>
    <form id="Form1" runat="server">
      <h3>HttpParseException Example</h3>

      <aspSample:CustomHtmlSelectWithHttpParseException
       id="customhtmlselect1"
       runat="server">
      <aspSample:MyCustomOption optionid="option1" value="1"/>
      <aspSample:MyCustomOption optionid="option2" value="2"/>
      <aspSample:MyCustomOption optionid="option3" value="3"/>
      </aspSample:CustomHtmlSelectWithHttpParseException>

    </form>

  </body>

</html>
<!-- </Snippet1> -->
