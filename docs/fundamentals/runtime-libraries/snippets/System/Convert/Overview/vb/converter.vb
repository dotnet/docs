Option Strict On

Namespace ConvertSnippet
   'This class is the snippet for the class System.Convert
   Class Converter

      Public Shared Sub Main()
         '<Snippet1>
         Dim dNumber As Double
         dNumber = 23.15

         Try
            ' Returns 23
            Dim iNumber As Integer
            iNumber = System.Convert.ToInt32(dNumber)
         Catch exp As System.OverflowException
            System.Console.WriteLine("Overflow in double to int conversion.")
         End Try

         ' Returns True
         Dim bNumber As Boolean
         bNumber = System.Convert.ToBoolean(dNumber)

         ' Returns "23.15"
         Dim strNumber As String
         strNumber = System.Convert.ToString(dNumber)

         Try
            ' Returns '2'
            Dim chrNumber As Char
            chrNumber = System.Convert.ToChar(strNumber.Chars(1))
         Catch exp As System.ArgumentNullException
            System.Console.WriteLine("String is null.")
         Catch exp As System.FormatException
            System.Console.WriteLine("String length is greater than 1.")
         End Try

         ' System.Console.ReadLine() returns a string and it
         ' must be converted.
         Dim newInteger As Integer
         newInteger = 0
         Try
            System.Console.WriteLine("Enter an integer:")
            newInteger = System.Convert.ToInt32(System.Console.ReadLine())
         Catch exp As System.ArgumentNullException
            System.Console.WriteLine("String is null.")
         Catch exp As System.FormatException
            System.Console.WriteLine("String does not consist of an " + _
                "optional sign followed by a series of digits.")
         Catch exp As System.OverflowException
            System.Console.WriteLine("Overflow in string to int conversion.")
         End Try

         System.Console.WriteLine("Your integer as a double is {0}", _
                                  System.Convert.ToDouble(newInteger))
         '</Snippet1>
      End Sub
   End Class
End Namespace
