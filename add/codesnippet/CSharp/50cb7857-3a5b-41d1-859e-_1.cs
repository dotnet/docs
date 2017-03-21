Cache.Insert("DSN", connectionString, null, DateTime.Now.AddMinutes(2), TimeSpan.Zero, CacheItemPriority.High, onRemove);
   