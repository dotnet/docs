   Response.Cache.SetExpires(DateTime.Now.AddSeconds(60))
   Response.Cache.SetCacheability(HttpCacheability.Public)
   Response.Cache.SetValidUntilExpires(False)
   Response.Cache.VaryByParams("Category") = True

   If Response.Cache.VaryByParams("Category") Then
      '...
   End If
    