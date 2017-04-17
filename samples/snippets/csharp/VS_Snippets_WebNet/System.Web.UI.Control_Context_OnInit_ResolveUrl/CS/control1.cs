using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControl1 
{

 public class ParentControl : Control 
 {
   [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
// <snippet1>
   protected override bool OnBubbleEvent(object sender, EventArgs e)
   {

      // Use the Context property to write text to the TraceContext object
      // associated with the current request.
      Context.Trace.Write("The ParentControl's OnBubbleEvent method is called.");
      Context.Trace.Write("The Source of event is: " + sender.ToString());

      return true;
   }
// </snippet1>

   [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
   protected override void Render( HtmlTextWriter myWriter)
   {
      myWriter.Write("ParentControl");
      RenderChildren(myWriter);
   }
 }

 public class ChildControl : Button
 {
   [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
   protected override void OnClick(EventArgs e) 
   {
      base.OnClick(e);
      Context.Trace.Write("The ChildControl's OnClick method is called.");
      // Bubble this event to parent.
      RaiseBubbleEvent(this, e);
   }
 }

 public class MyResolveUrl:Control
 {
   private string _ImageUrl;     
   public string ImageUrl
   {
      get
      {
         return _ImageUrl;
      }
      set
      {
         _ImageUrl = value;
      }
   }
// <snippet2>
   [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
   protected override void Render(HtmlTextWriter output)
   {           
      Image myImage = new Image();
      // Use the ResolveUrl method to assign a URL
      // path to the Image.
      myImage.ImageUrl = ResolveUrl(this.ImageUrl);
      myImage.RenderControl(output);         
   }
// </snippet2>     
 }

 public class myLabel : WebControl
 {
   string _text;

   public myLabel() : base ("H1")
   {
   }

   public string Text
   {
      get{ return _text;}
      set{ _text = value;}
   }
// <snippet3>
   // Override the OnInit method to set _text to
   // a default value if it is null.
   [System.Security.Permissions.PermissionSet
       (System.Security.Permissions.SecurityAction.Demand, 
        Name="FullTrust")] 
   protected override void OnInit(EventArgs e)
   {
      base.OnInit(e);
      if ( _text == null)
           _text = "Here is some default text.";
   }
// </snippet3>

   [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
   protected override void RenderContents(HtmlTextWriter writer)
   {
      writer.Write(_text);
   } 
 }
}   

