' Find the number of members in the StaticObjects collection.
Dim ObjCount As Integer = Application.StaticObjects.Count
' Create an array of the same size.
Dim MyObjArray(ObjCount) As Object
' Copy the entire collection into the array.
Application.StaticObjects.CopyTo(MyObjArray, 0)
