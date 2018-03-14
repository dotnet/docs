 '<SNIPPET1>
Imports System
Imports System.Security.Cryptography


Public Class OidSample
   Shared msg As String
   Public Shared Sub Main()
      ' Assign values to strings.
      Dim Value1 As String = "1.2.840.113549.1.1.1"
      Dim Name1 As String = "3DES"
      Dim Value2 As String = "1.3.6.1.4.1.311.20.2"
      Dim InvalidName As String = "This name is not a valid name"
      Dim InvalidValue As String = "1.1.1.1.1.1.1.1"
      
      ' Create new Oid objects using the specified values.
      ' Note that the corresponding Value or Friendly Name property is automatically added to the object.
      Dim o1 As New Oid(Value1)
      Dim o2 As New Oid(Name1)
      
      ' Create a new Oid object using the specified Value and Friendly Name properties.
      ' Note that the two are not compared to determine if the Value is associated 
      '  with the Friendly Name.
      Dim o3 As New Oid(Value2, InvalidName)
      
      'Create a new Oid object using the specified Value. Note that if the value
      '  is invalid or not known, no value is assigned to the Friendly Name property.
      Dim o4 As New Oid(InvalidValue)
      
      'Write out the property information of the Oid objects.
	msg = "Oid1: Automatically assigned Friendly Name: " & o1.FriendlyName & ", " & o1.Value
	MsgBox(msg)
      'Console.WriteLine("Oid1: Automatically assigned Friendly Name: {0}, {1}", o1.FriendlyName, o1.Value)


      'Console.WriteLine("Oid2: Automatically assigned Value: {0}, {1}", o2.FriendlyName, o2.Value)
	msg = "Oid2: Automatically assigned Value: " & o2.FriendlyName & ", " & o2.Value
	MsgBox(msg)


      'Console.WriteLine("Oid3: Name and Value not compared: {0}, {1}", o3.FriendlyName, o3.Value)
	msg = "Oid3: Name and Value not compared: " & o3.FriendlyName & ", " & o3.Value
	MsgBox(msg)



     ' Console.WriteLine("Oid4: Invalid Value used: {0}, {1} {2}", o4.FriendlyName, o4.Value, Environment.NewLine)
	msg = "Oid4: Invalid Value used: " & o4.FriendlyName & ", " & o4.Value
	MsgBox(msg)
 

     
      'Create an Oid collection and add several Oid objects.
      Dim oc As New OidCollection()
      oc.Add(o1)
      oc.Add(o2)
      oc.Add(o3)
     ' Console.WriteLine("Number of Oids in the collection: {0}", oc.Count)
      ' Console.WriteLine("Is synchronized: {0} {1}", oc.IsSynchronized, Environment.NewLine)

	msg = "Number of Oids in the collection: " & oc.Count
	MsgBox(msg)
	msg = "Is synchronized: " & oc.IsSynchronized
	MsgBox(msg)

      
      'Create an enumerator for moving through the collection.
      Dim oe As OidEnumerator = oc.GetEnumerator()
      'You must execute a MoveNext() to get to the first item in the collection.
      oe.MoveNext()
      ' Write out Oids in the collection.
      'Console.WriteLine("First Oid in collection: {0},{1}", oe.Current.FriendlyName, oe.Current.Value)
	msg = "First Oid in collection: " & oe.Current.FriendlyName & ", " & oe.Current.Value
	MsgBox(msg)

      oe.MoveNext()
     ' Console.WriteLine("Second Oid in collection: {0},{1}", oe.Current.FriendlyName, oe.Current.Value)
	msg = "Second Oid in collection: " & oe.Current.FriendlyName & ", " & oe.Current.Value
	MsgBox(msg)

      'Return index in the collection to the beginning.
      oe.Reset()
   End Sub 'Main
End Class 'OidSample
'</SNIPPET1>