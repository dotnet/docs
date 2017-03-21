         Dim myVariable1 As UInt32 = UInt32.Parse(20)
         Dim myVariable2 As UInt32 = UInt32.Parse(20)

         ' Display the declaring type.
         Console.WriteLine(ControlChars.NewLine + "Type of 'myVariable1' is '{0}' and" +  _ 
                  " value is :{1}", myVariable1.GetType().ToString(), myVariable1.ToString())
         Console.WriteLine("Type of 'myVariable2' is '{0}' and" +  _
               " value is :{1}", myVariable2.GetType().ToString(), myVariable2.ToString())
         ' Compare 'myVariable1' instance with 'myVariable2' Object.
         If myVariable1.Equals(myVariable2) Then
            Console.WriteLine(ControlChars.NewLine + "Structures 'myVariable1' and" +  _
               " 'myVariable2' are equal")
         Else
            Console.WriteLine(ControlChars.NewLine + "Structures 'myVariable1' and" +  _
                  " 'myVariable2' are not equal")
         End If