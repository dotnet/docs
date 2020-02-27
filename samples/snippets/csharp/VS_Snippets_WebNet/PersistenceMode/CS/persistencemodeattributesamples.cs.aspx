<%@ Page %>
<%@ Import NameSpace= "System.Reflection" %>
<%@ Register TagPrefix="PersistenceModeAttributeSamples" Namespace="PersistenceModeAttributeSamples" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" language="c#">
/*    
    System.Web.UI.PersistenceModeAttribute.Attribute;System.Web.UI.PersistenceModeAttribute.Default;
    System.Web.UI.PersistenceModeAttribute.InnerDefaultProperty;System.Web.UI.PersistenceModeAttribute.EncodedInnerDefaultProperty;
    System.Web.UI.PersistenceModeAttribute.InnerProperty;System.Web.UI.PersistenceModeAttribute.Mode
    
   The following example demonstrates the fields 'Attribute','Default','InnerDefaultProperty','EncodedInnerDefaultProperty'
   and 'InnerProperty' and property ' Mode' of class 'PersistenceModeAttribute'.
   The asp code in the body tag is a supplement to the code written in PersistenceModeAttributeSamples.cs.
   The script code uses reflection to determine the attributes applied to the custom control. Evaluates the attribute information
   to ascertain the PersistenceMode of the corresponding property.      
*/
    void Page_Load() 
    {
        // When called on a server control, this method resolves all data-binding 
        // expressions in the server control and in any of its child controls.
        DataBind();
        
// <Snippet4>
// <Snippet5>
// <Snippet6>
// <Snippet7>
// <Snippet8>

        // Get various properties of the custom control and check the attributes applied on them.
        PropertyInfo myPropertyInfo = typeof(PersistenceModeAttributeSamples.MyTemplateControl).GetProperty("Author");
        GetPersistenceMode(myPropertyInfo);    
        myPropertyInfo = typeof(PersistenceModeAttributeSamples.MyTemplateControl).GetProperty("MessageTemplate");
        GetPersistenceMode(myPropertyInfo);         
        myPropertyInfo = typeof(PersistenceModeAttributeSamples.MyTemplateControl).GetProperty("Items");
        GetPersistenceMode(myPropertyInfo);         
    }

// <Snippet9>       
    
    // Gets information about the PersistenceModeAttribute applied to a property.
    private void GetPersistenceMode(PropertyInfo member)
    {
      Response.Write("<br /> Member Name :<b>" + member +"</b>");
      foreach (object memberAttribute in member.GetCustomAttributes(true))
      {
          // Display 'Mode' property value.
          if (memberAttribute is PersistenceModeAttribute)
                  Response.Write("<br />PersistenceModeAttribute 'Mode' is " + ((PersistenceModeAttribute)memberAttribute).Mode);
        
          // Use the static readonly fields of 'PersistenceModeAttribute' class to compare with the current attribute instance.                 
        
          // Default Mode for the PersistenceModeAttribute class is 'Attribute'. 
          // Hence if 'Mode' is 'Attribute' the 'And' evaluation will return true.
          if ( memberAttribute.Equals(PersistenceModeAttribute.Attribute) && memberAttribute.Equals(PersistenceModeAttribute.Default))
                Response.Write("<br />Description: is persistable in an HTML tag as an attribute.");
          else
                if ( memberAttribute.Equals(PersistenceModeAttribute.InnerDefaultProperty))
                  Response.Write("<br />Description: is persistable as inner content of the HTML tag as a child");
          else
                if ( memberAttribute.Equals(PersistenceModeAttribute.InnerProperty))
                  Response.Write("<br />Description: is persistable in the HTML tag as a nested tag"); 
          else
                if ( memberAttribute.Equals(PersistenceModeAttribute.EncodedInnerDefaultProperty))
                  {
                  Response.Write("<br />Description: is persistable as the only inner content of this ASP.NET server control."); 
                  Response.Write("The property value is HTML encoded before being persisted.");                                   
                  }
      }
    }
// </Snippet9>
    
// </Snippet8>
// </Snippet7>
// </Snippet6>
// </Snippet5>
// </Snippet4>
    </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
      <form id="form1" method="POST" runat="server">
         <PersistenceModeAttributeSamples:MyTemplateControl ID="myTemplate" Author="WIPRO" runat="server">
            <MessageTemplate>
               The Count of Items in the collection is 
                    <div style="text-decoration:underline; font-style:italic; font-weight:bold">
                        <%# myTemplate.Items.Count %>
                        <br />
                        Author:
                        <%# Container.Author%>
                     </div>
            </MessageTemplate>
            <Items>
               <asp:ListItem>Item 1</asp:ListItem>
               <asp:ListItem>Item 2</asp:ListItem>
            </Items>
         </PersistenceModeAttributeSamples:MyTemplateControl>
      </form>
   </body>
</html>
