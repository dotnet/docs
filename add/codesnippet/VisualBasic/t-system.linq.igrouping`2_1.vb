        ' Get an IGrouping object.
        Dim group As IGrouping(Of System.Reflection.MemberTypes, System.Reflection.MemberInfo) = _
            Type.GetType("String").GetMembers(). _
            GroupBy(Function(ByVal member) member.MemberType). _
            First()

        ' Output the key of the IGrouping, then iterate
        ' through each value in the sequence of values
        ' of the IGrouping and output its Name property.
        MsgBox(String.Format("\nValues that have the key '{0}':", group.Key))
        For Each mi As System.Reflection.MemberInfo In group
            MsgBox(mi.Name)
        Next

        ' The output is similar to:

        ' Values that have the key 'Method':
        ' get_Chars
        ' get_Length
        ' IndexOf
        ' IndexOfAny
        ' LastIndexOf
        ' LastIndexOfAny
        ' Insert
        ' Replace
        ' Replace
        ' Remove
        ' Join
        ' Join
        ' Equals
        ' Equals
        ' Equals
        ' ...
