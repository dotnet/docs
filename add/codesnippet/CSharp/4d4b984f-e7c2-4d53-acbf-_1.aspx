<%@ Page Language="C#" %>
<%@ OutputCache VaryByParam="none" Duration="600" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script language="c#" runat="server">

   static string validationstate;
 
   public void Page_Load()
   {
      Response.Cache.AddValidationCallback(new HttpCacheValidateHandler(ValidateCache), null);
      stamp.InnerHtml = DateTime.Now.ToString("r");
   }

   public static void ValidateCache(HttpContext context, Object data, ref HttpValidationStatus status) 
   {
      if (context.Request.QueryString["Valid"] == "false") 
      {
         status = HttpValidationStatus.Invalid;
      } 
      else if (context.Request.QueryString["Valid"] == "ignore") 
      {
         status = HttpValidationStatus.IgnoreThisRequest;
      } 
      else 
      {
         status = HttpValidationStatus.Valid;
      }
   }

</script>