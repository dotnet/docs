    // You can programmatically add a CookieParameter to the
    // SqlDataSource control's SelectParameters collection.
    CookieParameter cookieParam = new CookieParameter("lastname",TypeCode.String,"lname");
    SqlDataSource1.SelectParameters.Add(cookieParam);