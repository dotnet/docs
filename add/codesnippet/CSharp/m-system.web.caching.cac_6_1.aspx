    public void CreateDependency(Object sender, EventArgs e) {
        // Create a cache entry.
        Cache["key1"] = "Value 1";

        // Make key2 dependent on key1.
        String[] dependencyKey = new String[1];
        dependencyKey[0] = "key1";
        CacheDependency dependency = new CacheDependency(null, dependencyKey);

        Cache.Insert("key2", "Value 2", dependency);

        DisplayValues();
    }