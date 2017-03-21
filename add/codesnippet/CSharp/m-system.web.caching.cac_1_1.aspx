     IDictionaryEnumerator CacheEnum = Cache.GetEnumerator();
     while (CacheEnum.MoveNext())
     {
       cacheItem = Server.HtmlEncode(CacheEnum.Current.ToString()); 
       Response.Write(cacheItem);
     }