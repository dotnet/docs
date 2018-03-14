'<Snippet1>
Imports System

Namespace GlobalizationLibrary

   Class WriteSpecialFolders
   
      Shared Sub Main()
      
         Dim string0 As String = "C:"

         ' Each of the following three strings violates the rule.
         Dim string1 As String = "\Documents and Settings"
         Dim string2 As String = "\All Users"
         Dim string3 As String = "\Application Data"
         Console.WriteLine(string0 & string1 & string2 & string3)

         ' The following statement satisfies the rule.
         Console.WriteLine(Environment.GetFolderPath( _ 
            Environment.SpecialFolder.CommonApplicationData))

      End Sub

   End Class

End Namespace
'</Snippet1>
