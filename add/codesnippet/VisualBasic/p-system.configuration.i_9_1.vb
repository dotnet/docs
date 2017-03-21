      Dim myStringDictionary As StringDictionary = Context.Parameters
      If Context.Parameters.Count > 0 Then
         Console.WriteLine("Context Property : ")
         Dim myString As String
         For Each myString In  Context.Parameters.Keys
            Console.WriteLine(Context.Parameters(myString))
         Next myString
      End If