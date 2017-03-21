
            ' Create a new webrequest to the mentioned URL.
            Dim myWebRequest As WebRequest = WebRequest.Create(url)

            ' Set 'Preauthenticate'  property to true.
            myWebRequest.PreAuthenticate = True
            Console.WriteLine(ControlChars.Cr + "Please enter your credentials for the requested Url")
            Console.WriteLine("UserName")
            Dim UserName As String = Console.ReadLine()
            Console.WriteLine("Password")
            Dim Password As String = Console.ReadLine()

            ' Create a New 'NetworkCredential' object.
            Dim networkCredential As New NetworkCredential(UserName, Password)

            ' Associate the 'NetworkCredential' object with the 'WebRequest' object.
            myWebRequest.Credentials = networkCredential

            ' Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
