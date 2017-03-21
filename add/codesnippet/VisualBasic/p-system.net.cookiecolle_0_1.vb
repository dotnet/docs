        ' Get the cookies in the 'CookieCollection' object using the 'Item' property.


        Try
            If cookies.Count = 0 Then
                Console.WriteLine("No cookies to display")
                Return
            End If
            Console.WriteLine("{0}", cookies("UserName").ToString())
            Console.WriteLine("{0}", cookies("DateOfBirth").ToString())
            Console.WriteLine("{0}", cookies("PlaceOfBirth").ToString())
            Console.WriteLine("")
        Catch e As Exception
            Console.WriteLine(("Exception raised." + ControlChars.Cr + "Error : " + e.Message))
        End Try