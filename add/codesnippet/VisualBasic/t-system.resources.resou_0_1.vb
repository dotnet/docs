      ' Instantiate a standalone .resources file from its filename.
      Dim rr1 As New System.Resources.ResourceReader("Resources1.resources")

      ' Instantiate a standalone .resources file from a stream.
      Dim fs As New System.IO.FileStream(".\Resources2.resources",
                                         System.IO.FileMode.Open)
      Dim rr2 As New System.Resources.ResourceReader(fs)      