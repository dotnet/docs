<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>FontNamesConverter Example</title>
<script language="VB" runat="server">
    Sub Page_Load(sender As Object, e As EventArgs)
        
        ' Declare local variables.
        Dim culture As New System.Globalization.CultureInfo("en")
        Dim context As System.ComponentModel.ITypeDescriptorContext = Nothing
        Dim names As Object
        Dim name_string As Object
        
        ' Create FontNamesConverter object.
        Dim fontconverter As New FontNamesConverter()
        
        ' Create original list of fonts.
        Dim font_list As String = "arial, times new roman, verdana"
        
        ' Check for type compatibility.
        If fontconverter.CanConvertFrom(context, GetType(String)) Then
            
            ' Display original string.
            Label1.Text = "Original String :" & "<br /><br />" & font_list
            
            ' Convert string to array to strings and display results.
            names = fontconverter.ConvertFrom(context, culture, font_list)
            Label2.Text = "Converted to Array of Strings : " & "<br /><br />"
            Dim name_element As String
            For Each name_element In CType(names, String())
                Label2.Text &= name_element & "<br />"
            Next name_element
            
            ' Convert array of strings back to a string and display results.
            name_string = fontconverter.ConvertTo(context, culture, names, _
                GetType(String))
            Label3.Text = "Converted back to String :" & "<br /><br />" & _
                CType(name_string, String)
        End If 
    End Sub 'Page_Load
  </script>

</head>
<body>

   <h3>FontNamesConverter Example</h3>
   <br />

   <form id="form1" runat="server">
        
      <asp:Label id="Label1" runat="server"/>
      <br /><hr />
      <asp:Label id="Label2" runat="server"/>
      <br /><hr />
      <asp:Label id="Label3" runat="server"/>
        
   </form>

</body>
</html>
   
<!--</Snippet1>-->
