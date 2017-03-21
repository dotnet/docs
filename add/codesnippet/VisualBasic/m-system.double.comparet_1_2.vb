         Obj1 = CType(450, Double)

         If A.CompareTo(Obj1) < 0 Then
             Console.WriteLine(A.ToString() + " is less than " + Obj1.ToString() + ".")
         End If

         If (A.CompareTo(Obj1) > 0) Then
             Console.WriteLine(A.ToString() + " is greater than " + Obj1.ToString() + ".")
         End If

         If (A.CompareTo(Obj1) = 0) Then
             Console.WriteLine(A.ToString() + " equals " + Obj1.ToString() + ".")
         End If