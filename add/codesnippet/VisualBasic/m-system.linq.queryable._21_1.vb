        ' Create two arrays. The second is empty.
        Dim fruits1() As String = {"orange"}
        Dim fruits2() As String = {}

        ' Get the only item in the first array, or else
        ' the default value for type string (null).
        Dim fruit1 As String = fruits1.AsQueryable().SingleOrDefault()
        MsgBox("First Query: " + fruit1)

        ' Get the only item in the second array, or else
        ' the default value for type string (null). 
        Dim fruit2 As String = fruits2.AsQueryable().SingleOrDefault()
        MsgBox("Second Query: " & _
            IIf(String.IsNullOrEmpty(fruit2), "No such string!", fruit2))

        ' This code produces the following output:

        ' First Query: orange
        ' Second Query: No such string!
