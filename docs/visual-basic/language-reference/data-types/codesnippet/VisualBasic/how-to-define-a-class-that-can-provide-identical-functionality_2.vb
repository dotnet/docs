Public Sub useSimpleList()
  Dim iList As New simpleList(Of Integer)(2)
  Dim sList As New simpleList(Of String)(3)
  Dim dList As New simpleList(Of Date)(2)
  iList.add(10)
  iList.add(20)
  iList.add(30)
  sList.add("First")
  sList.add("extra")
  sList.add("Second")
  sList.add("Third")
  sList.remove(1)
  dList.add(#1/1/2003#)
  dList.add(#3/3/2003#)
  dList.insert(#2/2/2003#, 1)
  Dim s = 
    "Simple list of 3 Integer items (reported length " &
     CStr(iList.listLength) & "):" &
     vbCrLf & CStr(iList.listItem(0)) &
     vbCrLf & CStr(iList.listItem(1)) &
     vbCrLf & CStr(iList.listItem(2)) &
     vbCrLf &
     "Simple list of 4 - 1 String items (reported length " &
     CStr(sList.listLength) & "):" &
     vbCrLf & CStr(sList.listItem(0)) &
     vbCrLf & CStr(sList.listItem(1)) &
     vbCrLf & CStr(sList.listItem(2)) &
     vbCrLf &
     "Simple list of 2 + 1 Date items (reported length " &
     CStr(dList.listLength) & "):" &
     vbCrLf & CStr(dList.listItem(0)) &
     vbCrLf & CStr(dList.listItem(1)) &
     vbCrLf & CStr(dList.listItem(2))
  MsgBox(s)
End Sub