<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    //<snippet1>
    //<snippet2>
    ParserError MyParserError = new ParserError();
    //</snippet2>

    //<snippet3>
    MyParserError.ErrorText = "My Error Text";
    //</snippet3>

    //<snippet4>
    MyParserError.Line = 5;
    //</snippet4>

    //<snippet5>
    MyParserError.VirtualPath = "MyPath";
    //</snippet5>
    //</snippet1>
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ParserError Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
