    private string FormatTimeStamp(DateTime time)
    {
      return String.Format("{0} at {1}",
        time.ToLongDateString(), time.ToLongTimeString());
    }

    public override Stream Open()
    {
      string templateFile = HostingEnvironment.ApplicationPhysicalPath + "App_Data\\template.txt";
      string pageTemplate;
      DateTime now = DateTime.Now;

      // Try to get the page template out of the cache.
      pageTemplate = (string)HostingEnvironment.Cache.Get("pageTemplate");

      if (pageTemplate == null)
      {
        // Get the page template.
        using (StreamReader reader = new StreamReader(templateFile))
        {
          pageTemplate = reader.ReadToEnd();
        }

        // Set template timestamp
        pageTemplate = pageTemplate.Replace("%templateTimestamp%", 
          FormatTimeStamp(now));

        // Make pageTemplate dependent on the template file.
        CacheDependency cd = new CacheDependency(templateFile);

        // Put pageTemplate into cache for maximum of 20 minutes.
        HostingEnvironment.Cache.Add("pageTemplate", pageTemplate, cd,
          Cache.NoAbsoluteExpiration,
          new TimeSpan(0, 20, 0),
          CacheItemPriority.Default, null);
      }

      // Put the page data into the template.
      pageTemplate = pageTemplate.Replace("%file%", this.Name);
      pageTemplate = pageTemplate.Replace("%content%", content);

      // Get the data time stamp from the cache.
      DateTime dataTimeStamp = (DateTime)HostingEnvironment.Cache.Get("dataTimeStamp");
      pageTemplate = pageTemplate.Replace("%dataTimestamp%", 
        FormatTimeStamp(dataTimeStamp));
      pageTemplate = pageTemplate.Replace("%pageTimestamp%", 
        FormatTimeStamp(now));

      // Put the page content on the stream.
      Stream stream = new MemoryStream();
      StreamWriter writer = new StreamWriter(stream);

      writer.Write(pageTemplate);
      writer.Flush();
      stream.Seek(0, SeekOrigin.Begin);

      return stream;
    }