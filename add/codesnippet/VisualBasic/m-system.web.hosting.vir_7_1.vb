
    Private Function FormatTimeStamp(ByVal time As DateTime) As String
      Return String.Format("{0} at {1}", _
        time.ToLongDateString(), time.ToLongTimeString)
    End Function

    Public Overrides Function Open() As System.IO.Stream
      Dim templateFile As String
      templateFile = HostingEnvironment.ApplicationPhysicalPath & "App_Data\template.txt"

      Dim pageTemplate As String
      Dim now As DateTime
      now = DateTime.Now

      ' Try to get the page template out of the cache.
      pageTemplate = CType(HostingEnvironment.Cache.Get("pageTemplate"), String)

      If pageTemplate Is Nothing Then
        ' Get the page template.
        Try
          pageTemplate = My.Computer.FileSystem.ReadAllText(templateFile)
        Catch fileException As Exception
          Throw fileException
        End Try

        ' Set template timestamp.
        pageTemplate = pageTemplate.Replace("%templateTimestamp%", _
          FormatTimeStamp(Now))

        ' Make pageTemplate dependent on the template file.
        Dim cd As CacheDependency
        cd = New CacheDependency(templateFile)

        ' Put pageTemplate into cache for maximum of 20 minutes.
        HostingEnvironment.Cache.Add("pageTemplate", pageTemplate, cd, _
          Cache.NoAbsoluteExpiration, _
          New TimeSpan(0, 20, 0), _
          CacheItemPriority.Default, Nothing)
      End If

      ' Put the page data into the template.
      pageTemplate = pageTemplate.Replace("%file%", Me.Name)
      pageTemplate = pageTemplate.Replace("%content%", content)

      ' Get the data timestamp from the cache.
      Dim dataTimeStamp As DateTime
      dataTimeStamp = CType(HostingEnvironment.Cache.Get("dataTimeStamp"), DateTime)
      pageTemplate = pageTemplate.Replace("%dataTimestamp%", _
        FormatTimeStamp(dataTimeStamp))

      ' Set a timestamp for the page.
      Dim pageTimeStamp As String
      pageTimeStamp = FormatTimeStamp(now)
      pageTemplate = pageTemplate.Replace("%pageTimestamp%", pageTimeStamp)

      ' Put the page content on the stream.
      Dim stream As MemoryStream
      stream = New MemoryStream()

      Dim writer As StreamWriter
      writer = New StreamWriter(stream)

      writer.Write(pageTemplate)
      writer.Flush()
      stream.Seek(0, SeekOrigin.Begin)

      Return stream
    End Function