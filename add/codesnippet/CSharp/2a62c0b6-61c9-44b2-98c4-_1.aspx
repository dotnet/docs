    // You can programmatically add a CookieParameter to the
    // SqlDataSource control's SelectParameters collection.
    CookieParameter cookieParam = new CookieParameter("lastname","lname");
    SqlDataSource1.SelectParameters.Add(cookieParam);