using System;
using System.Web;
using System.Web.UI;


public class Page1: Page
{

// <Snippet1>

private void Page_Load(Object sender, EventArgs e)
{
   Response.Cache.AddValidationCallback(new HttpCacheValidateHandler(CacheValidate1), null);
}

public void CacheValidate1(HttpContext context, Object data, ref HttpValidationStatus status) 
{
   if (context.Request.QueryString["Valid"] == "false") 
   {
      status = HttpValidationStatus.Invalid;
   }
   else 
   {
      status = HttpValidationStatus.Valid;
   }
}
    
// </Snippet1>

}
