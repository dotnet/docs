         Dim myPropertyInfo() As PropertyInfo
         ' Get the properties of 'Type' class object.
         myPropertyInfo = Type.GetType("System.Type").GetProperties()
         Console.WriteLine("Properties of System.Type are:")
         Dim i As Integer
         For i = 0 To myPropertyInfo.Length - 1
            Console.WriteLine(myPropertyInfo(i).ToString())
         Next i