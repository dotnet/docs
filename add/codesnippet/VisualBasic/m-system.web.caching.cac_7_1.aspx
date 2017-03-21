            ' Make key1 dependent on several files.
            Dim files(2) as String
            files(0) = Server.MapPath("isbn.xml")
            files(1) = Server.MapPath("customer.xml")
            Dim dependency as new CacheDependency(files)

            Cache.Insert("key1", "Value 1", dependency)
        End If