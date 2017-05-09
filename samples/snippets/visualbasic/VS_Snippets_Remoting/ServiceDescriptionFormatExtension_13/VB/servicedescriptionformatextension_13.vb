' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.ctor
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.Add()
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.Item
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.Find(System.Type type)
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.FindAll(System.Type type)
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.IsHandled()
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.IsRequired()
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.CopyTo()
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.Contains()
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.IndexOf()
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.Remove()
' System.Web.Services.Description.ServiceDescriptionFormatExtensionCollection.Insert()

' The following program demonstrates the class, properties and methods of
' 'ServiceDescriptionFormatExtensionCollection'
' class. It creates a ServiceDescription object, uses it to create
' 'ServiceDescriptionFormatExtensionCollection' object. Collection
' object is used for demonstration of class properties and methods.

' Note: This program requires 'Sample_VB.wsdl' file to be placed in
' the same directory as that of .exe for running.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Collections


Class MyFormatExtension
   Inherits ServiceDescriptionFormatExtension
   
   Public Sub New()
      ' Set the properties.
      Me.Handled = True
      Me.Required = True
   End Sub 'New
End Class 'MyFormatExtension

Class myCollectionSample
   
   Shared Sub Main()
      Try
' <Snippet2>
         Dim myServiceDescription As ServiceDescription = _
                 ServiceDescription.Read("Sample_VB.wsdl")
         Dim myCollection As New ServiceDescriptionFormatExtensionCollection(myServiceDescription)
' </Snippet2>
' <Snippet3>
         Dim mySoapBinding1 As New SoapBinding()
         Dim mySoapBinding2 As New SoapBinding()
         Dim mySoapAddressBinding As New SoapAddressBinding()
         Dim myFormatExtensionObject As New MyFormatExtension()
         ' Add elements to collection.
         myCollection.Add(mySoapBinding1)
         myCollection.Add(mySoapAddressBinding)
         myCollection.Add(mySoapBinding2)
         myCollection.Add(myFormatExtensionObject)
' </Snippet3>
' <Snippet4>
         Console.WriteLine("Collection contains following types of elements: ")
         ' Display the 'Type' of the elements in collection.
         Dim i As Integer
         For i = 0 To myCollection.Count - 1
            Console.WriteLine(myCollection(i).GetType().ToString())
         Next i
' </Snippet4>
' <Snippet5>
         ' Check element of type 'SoapAddressBinding' in collection.
         Dim myObj As Object = myCollection.Find(mySoapAddressBinding.GetType())
         If myObj Is Nothing Then
            Console.WriteLine("Element of type '{0}' not found in collection.", _
                 mySoapAddressBinding.GetType().ToString())
         Else
            Console.WriteLine("Element of type '{0}' found in collection.", _
                 mySoapAddressBinding.GetType().ToString())
         End If
' </Snippet5>
' <Snippet6>
         ' Check all elements of type 'SoapBinding' in collection.
         Dim myObjectArray1(myCollection.Count -1 ) As Object
         myObjectArray1 = myCollection.FindAll(mySoapBinding1.GetType())
         Dim myNumberOfElements As Integer = 0
         Dim myIEnumerator As IEnumerator = myObjectArray1.GetEnumerator()
         
         ' Calculate number of elements of type 'SoapBinding'.
         While myIEnumerator.MoveNext()
            If mySoapBinding1.GetType() Is  myIEnumerator.Current.GetType() Then
               myNumberOfElements += 1
            End If
         End While
         Console.WriteLine("Collection contains {0} objects of type '{1}'.", _
                 myNumberOfElements.ToString(), mySoapBinding1.GetType().ToString())
' </Snippet6>
' <Snippet7>
         ' Check 'IsHandled' status for 'myFormatExtensionObject' object in collection.
         Console.WriteLine("'IsHandled' status for {0} object is {1}.", _
                 myFormatExtensionObject.ToString(), _
                 myCollection.IsHandled(myFormatExtensionObject).ToString())
' </Snippet7>
' <Snippet8>
         ' Check 'IsRequired' status for 'myFormatExtensionObject' object in collection.
         Console.WriteLine("'IsRequired' status for {0} object is {1}.", _
                 myFormatExtensionObject.ToString(), _
                 myCollection.IsRequired(myFormatExtensionObject).ToString())
' </Snippet8>
' <Snippet9>
         ' Copy elements of collection to an Object array.
         Dim myObjectArray2(myCollection.Count -1 ) As Object
         myCollection.CopyTo(myObjectArray2, 0)
         Console.WriteLine("Collection elements are copied to an object array.")
' </Snippet9>
' <Snippet10>
         ' Check for 'myFormatExtension' object in collection.
         If myCollection.Contains(myFormatExtensionObject) Then
' <Snippet11>            
            ' Get index of a 'myFormatExtension' object in collection.
            Console.WriteLine("Index of 'myFormatExtensionObject' is " + _
                 "{0} in collection.", myCollection.IndexOf(myFormatExtensionObject).ToString())
' </Snippet11>
' <Snippet12>
            ' Remove 'myFormatExtensionObject' element from collection.
            myCollection.Remove(myFormatExtensionObject)
            Console.WriteLine("'myFormatExtensionObject' is removed" + _
                 " from collection.")
' </Snippet12>
         End If
' </Snippet10>
' <Snippet13>
         ' Insert 'MyFormatExtension' object.
         myCollection.Insert(0, myFormatExtensionObject)
         Console.WriteLine("'myFormatExtensionObject' is inserted to collection.")
' </Snippet13>
      Catch e As Exception
         Console.WriteLine("The following exception was raised: {0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'myCollectionSample
' </Snippet1>