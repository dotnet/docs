  // Create a custom ControlBuilder that interprets nested elements
  // named myitem as TextBoxes. If this class is called in a 
  // ControlBuilderAttribute applied to a custom control, when
  // that control is created in a page and it contains child elements
  // that are named myitem, the child elements will be rendered as 
  // TextBox server controls. This control builder also ignores literal
  // strings between elements when it is associated with a control.
  [AspNetHostingPermission(SecurityAction.Demand, 
     Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class MyItemControlBuilder : ControlBuilder 
  {
     // Override the GetChildControlType method to detect
     // child elements named myitem.
     public override Type GetChildControlType(String tagName,
                                       IDictionary attributes)
     {
        if (String.Compare(tagName, "myitem", true) == 0) 
        {
           return typeof(TextBox);
        }
        return null;
     }

     // Override the AppendLiteralString method so that literal
     // text between rows of controls are ignored.  
     public override void AppendLiteralString(string s) 
     {
       // Ignores literals between rows.
     }
  }