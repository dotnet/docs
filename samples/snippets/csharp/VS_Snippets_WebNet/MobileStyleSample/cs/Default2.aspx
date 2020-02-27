<%@ Page Language="C#" Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<script runat="server">
    //<Snippet2>
    public class CustomStyle : 
        System.Web.UI.MobileControls.Style
        {
            private string themeNameKey;

            public CustomStyle(string name)
            {
                themeNameKey = 
                    RegisterStyle(name, typeof(String), 
                        String.Empty, true).ToString();
            }
            
            public string ThemeName
            {
                get
                {
                    return this[themeNameKey].ToString();
                }
                set
                {
                    this[themeNameKey] = value;
                }
            }
        }
        //</Snippet2>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">

    </mobile:form>
</body>
</html>
