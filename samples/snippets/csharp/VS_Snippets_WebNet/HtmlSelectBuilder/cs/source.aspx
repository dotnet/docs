<!-- <Snippet1> -->
<%@ Page Language="C#"%>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HtmlSelectBuilder Example</title>
</head>
  <body>
    <form id="Form1" runat="server">
      <h3>HtmlSelectBuilder Example</h3>

      <aspSample:CustomHtmlSelect
       id="customhtmlselect1"
       runat="server">
      <aspSample:MyOption1 optionid="option1" value="1" text="item 1"/>
      <aspSample:MyOption1 optionid="option2" value="2" text="item 2"/>
      <aspSample:MyOption2 optionid="option3" value="3" text="item 3"/>
      <aspSample:MyOption2 optionid="option4" value="4" text="item 4"/>
      </aspSample:CustomHtmlSelect>

    </form>

  </body>

</html>
<!-- </Snippet1> -->
