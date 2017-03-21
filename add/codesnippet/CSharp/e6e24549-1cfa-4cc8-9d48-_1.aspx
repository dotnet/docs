    public void CreateDependency(Object sender, EventArgs e) {
        // Create a cache entry.
        Cache["key1"] = "Value 1";

        // Make key2 dependent on key1.
        String[] dependencyKey = new String[1];
        dependencyKey[0] = "key1";
        CacheDependency dep1 = new CacheDependency(null, dependencyKey);

        // Make a second CacheDependency dependent on dep1.        
        CacheDependency dep2 = new CacheDependency(null, null, dep1);

        Cache.Insert("key2", "Value 2", dep2);

        DisplayValues();
    }