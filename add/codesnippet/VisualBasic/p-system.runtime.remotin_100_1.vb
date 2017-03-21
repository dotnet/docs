         Console.WriteLine("Message Properties")
         Dim myDictionary As IDictionary = myMesg.Properties
         Dim myEnum As IDictionaryEnumerator = CType(myDictionary.GetEnumerator(), IDictionaryEnumerator)

         While myEnum.MoveNext()
            Dim myKey As Object = myEnum.Key
            Dim myKeyName As String = myKey.ToString()
            Dim myValue As Object = myEnum.Value

            Console.WriteLine( "{0} : {1}", myKeyName, myEnum.Value)
            If myKeyName = "__Args" Then
               Dim myArgs As Object() = CType(myValue, Object())
               Dim myInt As Integer
               For myInt = 0 To myArgs.Length - 1
                  Console.WriteLine(  "arg: {0} myValue: {1}", myInt, myArgs(myInt))
               Next myInt
            End If
            If myKeyName = "__MethodSignature" And Not (myValue Is Nothing) Then
               Dim myArgs As Object() = CType(myValue, Object())
               Dim myInt As Integer
               For myInt = 0 To myArgs.Length - 1
                  Console.WriteLine("arg: {0} myValue: {1}", myInt, myArgs(myInt))
               Next myInt
            End If
         End While

         Console.WriteLine("myUrl1 {0} object URI{1}", myUrl, myObjectURI)

         myDictionary("__Uri") = myUrl
         Console.WriteLine("URI {0}", myDictionary("__URI"))
