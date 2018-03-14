' System.Web.Services.Description.BindingCollection;System.Web.Services.Description.BindingCollection.Item[Int32];
' System.Web.Services.Description.BindingCollection.Item[String];System.Web.Services.Description.BindingCollection.CopyTo

'  The program reads a wsdl document "MathService.wsdl" and instantiates a ServiceDescription instance 
'   from the WSDL document.A BindingCollection instance is then retrieved from this ServiceDescription instance 
'   and it's members are demonstrated. 
 
Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml
Imports Microsoft.VisualBasic

Class [MyClass]
   
   Public Shared Sub Main()
      Dim myBinding As Binding
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read("MathService_input.wsdl")
      Console.WriteLine("Total Number of bindings :" + myServiceDescription.Bindings.Count.ToString())
      ' <Snippet1>	  
      Dim i As Integer
      
      While i < myServiceDescription.Bindings.Count
         Console.WriteLine((ControlChars.Cr + "Binding " + i.ToString()))
         ' Get Binding at index i.
         myBinding = myServiceDescription.Bindings(i)
         Console.WriteLine((ControlChars.Tab + " Name : " + myBinding.Name))
         Console.WriteLine((ControlChars.Tab + " Type : " + myBinding.Type.ToString()))
         i = i + 1
      End While
      ' </Snippet1>
      ' <Snippet2>
      Dim myBindings(myServiceDescription.Bindings.Count) As Binding
      ' Copy BindingCollection to an Array.
      myServiceDescription.Bindings.CopyTo(myBindings, 0)
      Console.WriteLine(ControlChars.Cr + ControlChars.Cr + " Displaying array copied from BindingCollection")

      
      While i < myServiceDescription.Bindings.Count
         Console.WriteLine((ControlChars.Cr + "Binding " + i))
         Console.WriteLine((ControlChars.Tab + " Name : " + myBindings(i).Name))
         Console.WriteLine((ControlChars.Tab + " Type : " + myBindings(i).Type.ToString()))
      End While
      ' </Snippet2>
      ' <Snippet3>    
      ' Get Binding Name = "MathServiceSoap".
      myBinding = myServiceDescription.Bindings("MathServiceHttpGet")
      If Not (myBinding Is Nothing) Then
         Console.WriteLine((ControlChars.Cr + ControlChars.Cr + "Name : " + myBinding.Name))
         Console.WriteLine(("Type : " + myBinding.Type.ToString()))
      End If
      ' </Snippet3>
      myServiceDescription = Nothing
      myBinding = Nothing
   End Sub 'Main
End Class '[MyClass]