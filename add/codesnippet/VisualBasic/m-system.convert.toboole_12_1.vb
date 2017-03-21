      Dim objects() As Object = {16.33, -24, 0, "12", "12.7", String.Empty, _
                                 "1String", "True", "false", Nothing, _
                                 New System.Collections.ArrayList() }
      For Each obj As Object In objects
         If obj IsNot Nothing Then
            Console.Write("{0,-40}  -->  ", _
                          String.Format("{0} ({1})", obj, obj.GetType().Name))
         Else
            Console.Write("{0,-40}  -->  ", "Nothing")   
         End If
         Try
            Console.WriteLine("{0}", Convert.ToBoolean(obj))
         Catch e As FormatException
            Console.WriteLine("Bad Format")
         Catch e As InvalidCastException
            Console.WriteLine("No Conversion")
         End Try   
      Next     
      ' The example displays the following output:
      '       16.33 (Double)                            -->  True
      '       -24 (Int32)                               -->  True
      '       0 (Int32)                                 -->  False
      '       12 (String)                               -->  Bad Format
      '       12.7 (String)                             -->  Bad Format
      '        (String)                                 -->  Bad Format
      '       1String (String)                          -->  Bad Format
      '       True (String)                             -->  True
      '       false (String)                            -->  False
      '       Nothing                                   -->  False
      '       System.Collections.ArrayList (ArrayList)  -->  No Conversion