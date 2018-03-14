        If TypeOf inStream Is 
          IO.FileStream AndAlso
          inStream IsNot
          Nothing Then

            ReadFile(inStream)

        End If