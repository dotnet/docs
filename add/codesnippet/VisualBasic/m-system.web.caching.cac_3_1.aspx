   Dim CacheEnum As IDictionaryEnumerator = Cache.GetEnumerator()
   While CacheEnum.MoveNext()
      cacheItem = Server.HtmlEncode(CacheEnum.Current.Value.ToString())
      Response.Write(cacheItem)
   End While