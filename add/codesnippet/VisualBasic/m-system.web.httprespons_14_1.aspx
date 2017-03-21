      ' Clear headers to ensure none
      ' are sent to the requesting browser
      ' and set the content type.
      Response.ClearHeaders()
      Response.ContentType = "image/jpeg"