         'Get the cookies in the 'CookieCollection' object using the 'Item' property.
         Try
            If cookies.Count = 0 Then
                Console.WriteLine("No cookies to display")
                Return
            End If
            Dim j As Integer
            For j = 0 To cookies.Count - 1
                Console.WriteLine("{0}", cookies(j).ToString())
            Next j
            Console.WriteLine("")
        Catch e As Exception
            Console.WriteLine(("Exception raised." + ControlChars.Cr + "Error : " + e.Message))
        End Try