Private Sub GetRelation()
    ' Get the collection of a DataSet.
    Dim collection As DataRelationCollection = _
        DataSet1.Relations

    ' Add a relation named CustomerOrders.
    Dim myRel As DataRelation = _
        collection("CustomerOrders")

    ' Print the RelationName.
    Console.WriteLine(myRel.RelationName.ToString())
End Sub