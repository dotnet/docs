      // Instantiate a standalone .resources file from its filename.
      var rr1 = new System.Resources.ResourceReader("Resources1.resources");

      // Instantiate a standalone .resources file from a stream.
      var fs = new System.IO.FileStream(@".\Resources2.resources",
                                        System.IO.FileMode.Open);
      var rr2 = new System.Resources.ResourceReader(fs);      