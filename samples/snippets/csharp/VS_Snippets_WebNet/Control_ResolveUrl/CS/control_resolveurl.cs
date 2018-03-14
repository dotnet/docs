// System.Web.UI.Control.ResolveUrl; 
/* The following program demonstrates the method 'ResolveUrl'
   of 'System.Web.UI.Control' class.    

   A custom class 'MyResolveUrl' is created by inheriting from 
   'Control' Class. Method 'RenderContents' is overridden to create a new Image 
   instance. ImageUrl is obtained by resolving Url from one of the custom control's properties.
*/
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace ResolveUrlSample
{
// <Snippet1>
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
      protected override void Render(HtmlTextWriter output)
      {           
         Image myImage = new Image();
         // Resolve Url.
         myImage.ImageUrl = ResolveUrl(this.ImageUrl);
         myImage.RenderControl(output);         
      }     
   }
// </Snippet1>
}
