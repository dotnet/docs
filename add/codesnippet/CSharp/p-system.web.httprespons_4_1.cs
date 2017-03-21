   Response.Cache.SetExpires(DateTime.Now.AddSeconds(60));
   Response.Cache.SetCacheability(HttpCacheability.Public);
   Response.Cache.SetValidUntilExpires(false);
   Response.Cache.VaryByParams["Category"] = true;

   if (Response.Cache.VaryByParams["Category"])
   {
      //...
   }