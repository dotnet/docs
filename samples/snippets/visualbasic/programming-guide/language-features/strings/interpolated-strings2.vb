Imports System.Globalization
Imports System.Reflection

Public Module Example
   Public Sub Main()
      Dim price = 1000
      Dim s2 As IFormattable = $"The cost of this item is {price:C}."  
      ShowInfo(s2)
      CultureInfo.CurrentCulture = New CultureInfo("en-US")
      Console.WriteLine(s2)
      CultureInfo.CurrentCulture = New CultureInfo("fr-FR")
      Console.WriteLine(s2)      
   End Sub

   Private Sub ShowInfo(obj As Object)
      Console.WriteLine($"Displaying member information:{vbCrLf}")
      Dim t = obj.GetType()
      Dim flags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.Static Or BindingFlags.NonPublic
      For Each m In t.GetMembers(flags) 
         Console.Write($"   {m.Name} {m.MemberType}")   
         If m.MemberType = MemberTypes.Property Then
            Dim p = t.GetProperty(m.Name, flags)
            Console.Write($"   Value: {p.GetValue(obj)}")         
         End If
         If m.MemberType = MemberTypes.Field Then
            Dim f = t.GetField(m.Name, flags)
            Console.Write($"   Value: {f.GetValue(obj)}")
         End If
         Console.WriteLine()
      Next
      Console.WriteLine($"-------{vbCrLf}")
   End Sub
End Module
' The example displays the following output:
Displaying member information:

'       get_Format Method
'       GetArguments Method
'       get_ArgumentCount Method
'       GetArgument Method
'       ToString Method
'       System.IFormattable.ToString Method
'       ToString Method
'       Equals Method
'       GetHashCode Method
'       GetType Method
'       Finalize Method
'       MemberwiseClone Method
'       .ctor Constructor
'       Format Property   Value: The cost of this item is {0:C}.
'       ArgumentCount Property   Value: 1
'       _format Field   Value: The cost of this item is {0:C}.
'       _arguments Field   Value: System.Object[]
'       -------
'
'       The cost of this item is $1,000.00.
'       The cost of this item is 1 000,00 €.
' </Snippet1>

