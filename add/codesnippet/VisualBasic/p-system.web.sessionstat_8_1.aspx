    For Each s As String In Session.Contents
      Response.Write(String.Format("{0} = {1}<br />", s, Session(s)))
    Next