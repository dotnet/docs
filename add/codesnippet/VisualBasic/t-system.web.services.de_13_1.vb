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
         Dim myServiceDescription As ServiceDescription = _
                 ServiceDescription.Read("Sample_VB.wsdl")
         Dim myCollection As New ServiceDescriptionFormatExtensionCollection(myServiceDescription)
         Dim mySoapBinding1 As New SoapBinding()
         Dim mySoapBinding2 As New SoapBinding()
         Dim mySoapAddressBinding As New SoapAddressBinding()
         Dim myFormatExtensionObject As New MyFormatExtension()
         ' Add elements to collection.
         myCollection.Add(mySoapBinding1)
         myCollection.Add(mySoapAddressBinding)
         myCollection.Add(mySoapBinding2)
         myCollection.Add(myFormatExtensionObject)
         Console.WriteLine("Collection contains following types of elements: ")
         ' Display the 'Type' of the elements in collection.
         Dim i As Integer
         For i = 0 To myCollection.Count - 1
            Console.WriteLine(myCollection(i).GetType().ToString())
         Next i
         ' Check element of type 'SoapAddressBinding' in collection.
         Dim myObj As Object = myCollection.Find(mySoapAddressBinding.GetType())
         If myObj Is Nothing Then
            Console.WriteLine("Element of type '{0}' not found in collection.", _
                 mySoapAddressBinding.GetType().ToString())
         Else
            Console.WriteLine("Element of type '{0}' found in collection.", _
                 mySoapAddressBinding.GetType().ToString())
         End If
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
         ' Check 'IsHandled' status for 'myFormatExtensionObject' object in collection.
         Console.WriteLine("'IsHandled' status for {0} object is {1}.", _
                 myFormatExtensionObject.ToString(), _
                 myCollection.IsHandled(myFormatExtensionObject).ToString())
         ' Check 'IsRequired' status for 'myFormatExtensionObject' object in collection.
         Console.WriteLine("'IsRequired' status for {0} object is {1}.", _
                 myFormatExtensionObject.ToString(), _
                 myCollection.IsRequired(myFormatExtensionObject).ToString())
         ' Copy elements of collection to an Object array.
         Dim myObjectArray2(myCollection.Count -1 ) As Object
         myCollection.CopyTo(myObjectArray2, 0)
         Console.WriteLine("Collection elements are copied to an object array.")
         ' Check for 'myFormatExtension' object in collection.
         If myCollection.Contains(myFormatExtensionObject) Then
            ' Get index of a 'myFormatExtension' object in collection.
            Console.WriteLine("Index of 'myFormatExtensionObject' is " + _
                 "{0} in collection.", myCollection.IndexOf(myFormatExtensionObject).ToString())
            ' Remove 'myFormatExtensionObject' element from collection.
            myCollection.Remove(myFormatExtensionObject)
            Console.WriteLine("'myFormatExtensionObject' is removed" + _
                 " from collection.")
         End If
         ' Insert 'MyFormatExtension' object.
         myCollection.Insert(0, myFormatExtensionObject)
         Console.WriteLine("'myFormatExtensionObject' is inserted to collection.")
      Catch e As Exception
         Console.WriteLine("The following exception was raised: {0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'myCollectionSample