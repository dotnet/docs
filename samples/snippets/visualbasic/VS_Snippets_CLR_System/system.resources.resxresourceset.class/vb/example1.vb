' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Imports System.Collections
Imports System.Drawing
Imports System.Resources

Module Example
   Public Sub Main()
      CreateResXFile()
      
      Dim resSet As New ResXResourceSet(".\StoreResources.resx")
      Dim dict As IDictionaryEnumerator = resSet.GetEnumerator()
      Do While dict.MoveNext()
         Dim key As String = CStr(dict.Key)
         ' Retrieve resource by name.
         If typeof dict.Value Is String Then
            Console.WriteLine("{0}: {1}", key, resSet.GetString(key))
         Else
            Console.WriteLine("{0}: {1}", key, resSet.GetObject(key))   
         End If
      Loop
   End Sub
   
   Private Sub CreateResXFile()
      Dim logo As New Bitmap(".\Logo.bmp")
      Dim node As ResXDataNode
      
      Dim rw As New ResXResourceWriter(".\StoreResources.resx")
      node = New ResXDataNode("Logo", logo)
      node.Comment = "The corporate logo."
      rw.AddResource(node) 
      rw.AddResource("AppTitle", "Store Locations")
      node = New ResXDataNode("nColumns", 5)
      node.Comment = "The number of columns in the Store Location table"
      rw.AddResource(node)
      rw.AddResource("City", "City")
      rw.AddResource("State", "State")
      rw.AddResource("Code", "Zip Code")
      rw.AddResource("Telephone", "Phone")
      rw.Generate()
      rw.Close()
   End Sub
End Module
' The example displays the following output:
'       Telephone: Phone
'       Code: Zip Code
'       State: State
'       City: City
'       nColumns: 5
'       AppTitle: Store Locations
'       Logo: System.Drawing.Bitmap
' </Snippet1>

