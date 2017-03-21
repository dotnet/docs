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