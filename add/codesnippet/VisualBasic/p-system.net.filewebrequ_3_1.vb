                    ' Create a Uri object.to access the file requested by the user. 
                    Dim myUrl As New Uri("file://" + fileName)

                    ' Create a FileWebRequest object.for the requeste file.
                    myFileWebRequest = CType(WebRequest.CreateDefault(myUrl), FileWebRequest)

                    ' Set the time-out to the value selected by the user.
                    myFileWebRequest.Timeout = timeout
