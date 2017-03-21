        ' Create an empty array.
        Dim fruits() As String = {}

        ' Get the last item in the array, or else the default
        ' value for type string (null).
        Dim last As String = fruits.AsQueryable().LastOrDefault()

        MsgBox(IIf(String.IsNullOrEmpty(last), "[STRING IS NULL OR EMPTY]", last))

        ' This code produces the following output:
        ' [STRING IS NULL OR EMPTY]
