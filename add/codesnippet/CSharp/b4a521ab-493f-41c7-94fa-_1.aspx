    public void CreateDependency(Object sender, EventArgs e) {
        // Create a DateTime object.
        DateTime dt = DateTime.Now.AddSeconds(10);

        // Create a cache entry.
        Cache["key1"] = "Value 1";

        // Make key2 dependent on key1.
        String[] dependencyKey = new String[1];
        dependencyKey[0] = "key1";
        CacheDependency dep1 = new CacheDependency(null, dependencyKey);

        // Make a second CacheDependency dependent on dep1.
        // and use dt to start change monitoring.        
        CacheDependency dep2 = new CacheDependency(null, null, dep1, dt);

        Cache.Insert("key2", "Value 2", dep2);

        DisplayValues();
    }