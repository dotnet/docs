        ' Get a sequence of IGrouping objects.
        Dim memberQuery As  _
        IEnumerable(Of IGrouping(Of System.Reflection.MemberTypes, System.Reflection.MemberInfo)) = _
            Type.GetType("String").GetMembers(). _
            GroupBy(Function(ByVal member) member.MemberType)

        ' Output the key of each IGrouping object and the count of values.
        For Each group As  _
        IGrouping(Of System.Reflection.MemberTypes, System.Reflection.MemberInfo) In memberQuery
            MsgBox(String.Format("(Key) {0} (Member count) {1}", group.Key, group.Count()))
        Next

        ' The output is similar to:
        ' (Key) Method (Member count) 113
        ' (Key) Constructor (Member count) 8
        ' (Key) Property (Member count) 2
        ' (Key) Field (Member count) 1
