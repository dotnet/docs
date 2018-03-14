<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html >

<head id="Head1" runat="server">
    <title>$addHandler Example</title>
    <style type="text/css">
    #UpdatePanel1 { 
      width:300px; height:100px;
     }
    </style>
</head>
<body>
	<h1>$addHandler Example</h1>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" GroupingText="Update Panel">
                   <asp:Label ID="Label1" runat="server" Text="Click button to see event details."></asp:Label>
                   <br /><br />
                   <asp:Button ID="Button1" runat="server" Text="Button" AccessKey="b"  />
                   <br /><br />
                   <asp:Label ID="Label2" runat="server"></asp:Label>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

<script type="text/javascript">
    $addHandler($get("Button1"), "click", processEventInfo);
    var myArray = ['altKey', 'button', 'charCode', 'clientX', 'clientY',
                   'ctrlKey', 'offsetX', 'offsetY', 'screenX', 'screenY', 
                   'shiftKey', 'target', 'type'];

    // Event handler displays element properties specified in array
    function processEventInfo(eventElement) {
        var result = '';
        for (var i = 0, l = myArray.length; i < l; i++) {
            var arrayVal = myArray[i];
            if (typeof(arrayVal) !== 'undefined') {
                // Example: eventElement.clientX
                result += arrayVal + " = " + eval("eventElement." + arrayVal) + '<br/>';
            }
        }
        $get('Label2').innerHTML = result;
    }
 </script>
 <!-- </Snippet1> -->
 
