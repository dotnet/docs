' System.Web.Services.Description.ServiceDescriptionCollection.Insert()
' System.Web.Services.Description.ServiceDescriptionCollection.Item(String)
' System.Web.Services.Description.ServiceDescriptionCollection.CopyTo()

' The following program demonstrates 'Item' property, 'Insert' and 'CopyTo' 
' methods of the 'ServiceDescriptionCollection' class. It creates an instance of 
' 'ServiceDescriptionCollection' and adds 'ServiceDescription' objects to the 
' collection. The elements of the collection are copied to a 'ServiceDescription' 
' array.
' 
' Note: This program requires 'DataTypes_VB.wsdl' and 'MathService_VB.wsdl' 
' files to be placed in the same directory as that of .exe for running.


Imports System
Imports System.Web.Services.Description

Class MyServiceDescriptionCollection
   
   Public Shared Sub Main()
      Try
         Dim myServiceDescription1 As ServiceDescription = _
                 ServiceDescription.Read("DataTypes_VB.wsdl")
         myServiceDescription1.Name = "DataTypes"
         Dim myServiceDescription2 As ServiceDescription = _
                 ServiceDescription.Read("MathService_VB.wsdl")
         myServiceDescription2.Name = "MathService"
         
         ' Create the object of 'ServiceDescriptionCollection' class.
         Dim myCollection As New ServiceDescriptionCollection()
         ' Add 'ServiceDescription' objects.
         myCollection.Add(myServiceDescription1)
' <Snippet11>
         ' Insert a ServiceDescription into the collection.
         myCollection.Insert(1, myServiceDescription2)
' </Snippet11>      
' <Snippet12>
         ' Get a ServiceDescription from the collection using 
         ' the Item property.
         Dim myServiceDescription As ServiceDescription = _
            myCollection("http://tempuri1.org/")
' </Snippet12>
         Console.WriteLine("Name of the object retrieved using 'Item' property: " + _
                 myServiceDescription.Name)
' <Snippet13>
         Dim myArray(myCollection.Count -1 ) As ServiceDescription

         ' Copy the collection to a ServiceDescription array.
         myCollection.CopyTo(myArray, 0)
         Dim i As Integer
         For i = 0 To myArray.Length - 1
            Console.WriteLine("Name of element in array: " & _
            myArray(i).Name)
         Next i
' </Snippet13>
      Catch e As Exception
         Console.WriteLine("The following exception was raised: {0}", e.Message.ToString())
      End Try
   End Sub 'Main 
End Class 'MyServiceDescriptionCollection
