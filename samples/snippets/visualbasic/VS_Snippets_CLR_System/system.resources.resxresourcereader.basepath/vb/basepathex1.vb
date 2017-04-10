' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Reflection
Imports System.Resources

Module Example
   Public Sub Main()
      CreateXMLResourceFile()
      
      ' Read the resources in the XML resource file.
      Dim resx As New ResXResourceReader("DogBreeds.resx") 
      Console.WriteLine("Default Base Path: '{0}'", resx.BasePath)
      resx.BasePath = "C:\Data\"
      Console.WriteLine("Current Base Path: '{0}'", resx.BasePath) 
      Console.WriteLine()     
      resx.UseResXDataNodes = True

      Dim dict As IDictionaryEnumerator = resx.GetEnumerator()
      Dim assemblyNames() As AssemblyName = 
                       { New AssemblyName(GetType(Bitmap).Assembly.FullName) }
      Do While dict.MoveNext()
         Dim node As ResXDataNode = CType(dict.Value, ResXDataNode)
         If node.FileRef IsNot Nothing Then
            Dim image As Object = node.GetValue(assemblyNames)
            Console.WriteLine("{0}: {1} from {2}", dict.Key, image.GetType().Name, node.FileRef.Filename)
         Else
            Console.WriteLine("{0}: {1}", node.Name, node.GetValue(CType(Nothing, ITypeResolutionService)))
         End If   
      Loop   
   End Sub
   
   Private Sub CreateXMLResourceFile()
      ' Define an array of ResXFileRef objects for images.
      Dim typeName As String = String.Format("{0}, {1}", GetType(Bitmap).Fullname, GetType(Bitmap).Assembly.FullName)
      Dim imageRefs() As ResXFileRef =
         { New ResXFileRef("images\Akita.jpg", typeName),
           New ResXFileRef("images\Dalmatian.jpg", typeName),
           New ResXFileRef("images\Husky.jpg", typeName),
           New ResXFileRef("images\GreatPyrenees.jpg", typeName),
           New ResXFileRef("images\Malamute.jpg", typeName),
           New ResXFileRef("images\Newfoundland.jpg", typeName),
           New ResXFileRef("images\Rottweiler.jpg", typeName) 
         }
      
      Using resx As New ResXResourceWriter(".\DogBreeds.resx")
         ' Add each ResXFileRef object to the resource file.
         For Each imageRef In imageRefs
            ' Form resource name from name of image.
            Dim name As String = imageRef.FileName
            name = name.Substring(name.IndexOf("\") + 1)
            name = name.Substring(0, name.IndexOf("."))
            Dim node As New ResXDataNode(name, imageRef) 
            resx.AddResource(node)
         Next
         resx.AddResource("CreatedBy", GetType(Example).Assembly.FullName)
      End Using   
   End Sub
End Module
' The example displays the following output:
'       Default Base Path: ''
'       Current Base Path: 'C:\Data\'
'       
'       Akita: Bitmap from C:\Data\images\Akita.jpg
'       Dalmatian: Bitmap from C:\Data\images\Dalmatian.jpg
'       Husky: Bitmap from C:\Data\images\Husky.jpg
'       GreatPyrenees: Bitmap from C:\Data\images\GreatPyrenees.jpg
'       Malamute: Bitmap from C:\Data\images\Malamute.jpg
'       Newfoundland: Bitmap from C:\Data\images\Newfoundland.jpg
'       Rottweiler: Bitmap from C:\Data\images\Rottweiler.jpg
'       CreatedBy: BasePathEx1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
' </Snippet1>
