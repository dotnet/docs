  if (!myControl.IsPostBack)
  {
    // Add new objects to the HttpApplicationState.
    // These will be maintained as long as the application is active.
    myControl.Application.Add("Author","Shafeeque");
    myControl.Application.Add("Date",new DateTime(2001,6,21));
    // Add an object to the cache with expirations 
    // set to 0.1 minute.
    myControl.Cache.Insert("MyData1", "somevalue", null, DateTime.Now.AddMinutes(0.1), Cache.NoSlidingExpiration);
  }