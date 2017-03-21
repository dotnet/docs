          ' Assign a value to a string variable
          ' and encode it to a page as a 
          ' URL parameter.      
          param = "ID=City State"
          writer.WriteBreak()
          writer.WriteEncodedUrlParameter(param)