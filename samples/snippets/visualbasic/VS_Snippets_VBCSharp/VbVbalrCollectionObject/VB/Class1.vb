Public Class Class1

  '****************************************************************************
  Shared Sub TestGetEnumerator()
    '<Snippet7>
    Dim customers As New Collection
    ' Insert code to add elements to the customers collection.
    Dim custEnum As IEnumerator = customers.GetEnumerator()
    custEnum.Reset()
    Dim thisCustomer As Object
    While custEnum.MoveNext()
        thisCustomer = custEnum.Current()
        ' Insert code to process this element of the collection.
    End While
    '</Snippet7>
  End Sub

  '****************************************************************************
  Shared Sub BirthdayCollection()
    '<Snippet5>
    Dim birthdays As New Collection()
    birthdays.Add(New DateTime(2001, 1, 12), "Bill")
    birthdays.Add(New DateTime(2001, 1, 13), "Joe")
    birthdays.Add(New DateTime(2001, 1, 14), "Mike")
    birthdays.Add(New DateTime(2001, 1, 15), "Pete")
    '</Snippet5>

    '<Snippet6>
    MsgBox("Number of birthdays in collection: " & CStr(birthdays.Count))
    '</Snippet6>

    '<Snippet8>
    Dim aBirthday As DateTime
    aBirthday = birthdays.Item("Bill")
    MsgBox(CStr(aBirthday))
    aBirthday = birthdays("Bill")
    MsgBox(CStr(aBirthday))
    '</Snippet8>

    '<Snippet9>
    birthdays.Remove(1)
    birthdays.Remove("Mike")
    '</Snippet9>

    MsgBox("Number of birthdays in collection: " & CStr(birthdays.Count))
  End Sub


  '****************************************************************************
  Class Customer
    Private _accountNumber As String
    Public Property accountNumber() As String
      Get
        Return _accountNumber
      End Get
      Set(ByVal value As String)
        _accountNumber = value
      End Set
    End Property
  End Class


  '****************************************************************************
  Shared Sub TestContains()
    Dim newCustomer As New Customer

    '<Snippet4>
    Dim customers As New Microsoft.VisualBasic.Collection()
    Dim accountNumber As String = "1234"
    ' Insert code that obtains new customer objects.
    ' Use the new customer's account number as the key.
    customers.Add(newCustomer, accountNumber)
    ' The preceding statements can be repeated for several customers.
    Dim searchNumber As String = "1234"
    ' Insert code to obtain an account number to search for.
    If customers.Contains(searchNumber) Then
        MsgBox("The desired customer is in the collection.")
    Else
        MsgBox("The desired customer is not in the collection.")
    End If
    '</Snippet4>

  End Sub


  '****************************************************************************
  Shared Function TestClear() As Integer
    '<Snippet3>
    Dim customers As New Microsoft.VisualBasic.Collection()
    ' Insert code that adds customers to collection.
    customers.Clear()
    '</Snippet3>

    Return customers.Count
  End Function


  '****************************************************************************
  '<Snippet1>
  Public Class nameClass
      Public instanceName As String
  End Class
  Sub classNamer()
      ' Create a Visual Basic Collection object.
      Dim names As New Microsoft.VisualBasic.Collection()
      Dim key As Integer
      Dim msg As String
      Dim name As String
      Dim nameList As String = ""
      ' 1. Get names from the user to add to the collection.
      Do
          Dim inst As New nameClass()
          key += 1
          msg = "Please enter a name for this object." & vbCrLf &
                "Press Cancel to see names in collection."
          name = InputBox(msg, "Name the Collection items")
          inst.instanceName = name
          ' If user entered a name, add it to the collection.
          If inst.instanceName <> "" Then
              names.Add(inst, CStr(key))
          End If
      Loop Until name = ""
      ' 2. Create and display a list of names from the collection.
      For Each oneInst As nameClass In names
          nameList &= oneInst.instanceName & vbCrLf
      Next oneInst
      MsgBox(nameList, , "Instance Names in names Collection")
      ' 3. Remove elements from the collection without disposing of the collection.
      For count As Integer = 1 To names.Count
          names.Remove(1)
          ' Since Visual Basic collections are reindexed automatically, 
          ' remove the first member on each iteration.
      Next count
  End Sub
  '</Snippet1>

End Class
