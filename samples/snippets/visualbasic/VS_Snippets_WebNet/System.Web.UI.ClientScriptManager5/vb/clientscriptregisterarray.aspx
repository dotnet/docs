<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Define the array name and values.
    Dim arrName As String = "MyArray"
    Dim arrValue As String = """1"", ""2"", ""text"""
    
    ' Define the hidden field name and initial value.
    Dim hiddenName As String = "MyHiddenField"
    Dim hiddenValue As String = "3"
    
    ' Define script name and type.
    Dim csname As String = "ConcatScript"
    Dim cstype As Type = Me.GetType()
        
    ' Get a ClientScriptManager reference from the Page class.
    Dim cs As ClientScriptManager = Page.ClientScript

    ' Register the array with the Page class.
    cs.RegisterArrayDeclaration(arrName, arrValue)
    
    ' Register the hidden field with the Page class.
    cs.RegisterHiddenField(hiddenName, hiddenValue)

    ' Check to see if the  script is already registered.
    If (Not cs.IsClientScriptBlockRegistered(cstype, csname)) Then
      Dim cstext As StringBuilder = New StringBuilder()
      cstext.Append("<script type=""text/javascript\""> function DoClick() {")
      cstext.Append("Form1.Message.value='Sum = ' + ")
      cstext.Append("(parseInt(" + arrName + "[0])+")
      cstext.Append("parseInt(" + arrName + "[1])+")
      cstext.Append("parseInt(" + Form1.Name + "." + hiddenName + ".value));} </")
      cstext.Append("script>")
      cs.RegisterClientScriptBlock(cstype, csname, cstext.ToString(), False)
    End If
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ClientScriptManager Example</title>
  </head>
  <body>
     <form    id="Form1"
            runat="server">
     <input type="text"
            id="Message" />
     <input type="button" 
            onclick="DoClick()" 
            value="Run Script" />
     </form>
  </body>
</html>
<!-- </Snippet1> -->
