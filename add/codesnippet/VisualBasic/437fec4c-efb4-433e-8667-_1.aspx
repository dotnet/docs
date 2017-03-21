    ' You can programmatically add a CookieParameter to the
    ' SqlDataSource control's SelectParameters collection.
    Dim cookieParam As New CookieParameter("lastname",TypeCode.String,"lname")
    SqlDataSource1.SelectParameters.Add(cookieParam)