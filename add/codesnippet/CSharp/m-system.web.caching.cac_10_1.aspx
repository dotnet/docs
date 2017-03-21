        // Create a DateTime object that determines
        // when dependency monitoring begins.
        DateTime dt = DateTime.Now;
            // Make key1 dependent on several files.
            String[] files = new String[2];
            files[0] = Server.MapPath("isbn.xml");
            files[1] = Server.MapPath("customer.xml");
            CacheDependency dep = new CacheDependency(files, dt);

            Cache.Insert("key1", "Value 1", dep);
        }