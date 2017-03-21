      ' Set the page's content type to JPEG files
      ' and clears all content output from the buffer stream.
      Response.ContentType = "image/jpeg"
      Response.Clear()
      
      ' Buffer response so that page is sent
      ' after processing is complete.
      Response.BufferOutput = True