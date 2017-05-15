' System.Web.Services.Description.BindingCollection;System.Web.Services.Description.Remove;System.Web.Services.Description.Add;
' System.Web.Services.Description.Contains;System.Web.Services.Description.IndexOf

' The following example reads the contents of a file 'MathService.wsdl' into a ServiceDescription instance.
' Removes first binding in the BindingCollection of the ServiceDescription instance and writes the current 
' 'ServiceDescription' instance into a temporary file.
' Adds the same binding back again into the instance and writes to another temporary file.

Imports System
Imports System.Web.Services.Description
Imports Microsoft.VisualBasic

Class [MyClass]
   
   Public Shared Sub Main()
      Dim myBinding As Binding
      ' <Snippet1>      
      ' <Snippet2>
      ' <Snippet3>
      ' <Snippet4>
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read("MathService_input.wsdl")
      Console.WriteLine(("Total Number of bindings defined are:" + myServiceDescription.Bindings.Count.ToString()))
      myBinding = myServiceDescription.Bindings(0)
      
      ' Remove the first binding in the collection.
      myServiceDescription.Bindings.Remove(myBinding)
      Console.WriteLine(("Successfully removed binding " + myBinding.Name))
      Console.WriteLine(("Total Number of bindings defined now are:" + myServiceDescription.Bindings.Count.ToString()))
      myServiceDescription.Write("MathService_temp.wsdl")
      ' </Snippet1>      
      ' Add binding to the ServiceDescription instance.
      myServiceDescription.Bindings.Add(myBinding)
      ' </Snippet2>
      If myServiceDescription.Bindings.Contains(myBinding) Then
         Console.WriteLine(("Successfully added binding " + myBinding.Name))
      End If 
      ' </Snippet3>
      Console.WriteLine(("Binding was added at index " + myServiceDescription.Bindings.IndexOf(myBinding).ToString()))
      Console.WriteLine(("Total Number of bindings defined now are:" + myServiceDescription.Bindings.Count.ToString()))
      myServiceDescription.Write("MathService_temp1.wsdl")
      ' </Snippet4>
      myServiceDescription = Nothing
      myBinding = Nothing
   End Sub 'Main 
End Class '[MyClass]