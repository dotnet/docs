' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Imports Microsoft.VisualBasic
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Drawing
Imports System.IO
Imports System.Resources
Imports System.Resources.Tools

Module Example
   Public Sub Main()
      CreateResXFile()
      
      Dim sw As New StreamWriter(".\DemoResources.vb")
      Dim errors() As String = Nothing
      Dim provider As New VBCodeProvider()
      Dim code As CodeCompileUnit = StronglyTypedResourceBuilder.Create("Demo.resx", "DemoResources", 
                                                                        "DemoApp", provider, 
                                                                        false, errors)    
      If errors.Length > 0 Then
         For Each [error] In errors
            Console.WriteLine([error]) 
         Next
      End If
      provider.GenerateCodeFromCompileUnit(code, sw, New CodeGeneratorOptions())                                         
      sw.Close()
   End Sub
   
   Private Sub CreateResXFile()
      Dim logo As New Bitmap(".\Logo.bmp")

      Dim rw As New ResXResourceWriter(".\Demo.resx")
      rw.AddResource("Logo", logo) 
      rw.AddResource("AppTitle", "Demo Application")
      rw.Generate()
      rw.Close()
   End Sub
End Module
' </Snippet1>

