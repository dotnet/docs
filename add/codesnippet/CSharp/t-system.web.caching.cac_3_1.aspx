// Insert the cache item.
CacheDependency dep = new CacheDependency(fileName, dt);
cache.Insert("key", "value", dep);

// Check whether CacheDependency.HasChanged is true.
if (dep.HasChanged)
  Response.Write("<p>The dependency has changed.");  
else Response.Write("<p>The dependency has not changed.");