<!--<Snippet1>-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script language="VB" runat="server">
     Sub Page_Load(Src As Object, e As EventArgs)
         Message.InnerHtml = Message.InnerHtml & _
             "<h5>The FirstSelect select box's " & _
             "Attribute collection contains:</h5>"

         Dim keys As IEnumerator = _
             FirstSelect.Attributes.Keys.GetEnumerator

         Do While keys.MoveNext
             Dim key As String = keys.Current
             Message.InnerHtml = Message.InnerHtml & key _
                 & "=" & FirstSelect.Attributes(key) & "<br />"
         Loop
     End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Attribute Collection Sample</title>
</head>
<body>

    <p>
        <span id="Message" enableviewstate="false" 
            runat="server" />
    </p>
    <p>
        Make a selection:
        <select id="FirstSelect" runat="server" 
           style="padding:1; width:40; font: 16pt verdana;
           background-color:Aqua; color:black;">
           <option>This</option>
           <option>That</option>
           <option>Other</option>
        </select>
    </p>

</body>
</html>
<!--</Snippet1>-->
