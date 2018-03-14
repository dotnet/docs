Imports System.Collections.Generic
Module Module1
    Sub Main()
        EnumerateGroup()
    End Sub

    Public Sub EnumerateGroup()
        ' <Snippet1>
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

        ' </Snippet1>

    End Sub

    Sub GroupKey()
        ' <Snippet2>
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

        ' </Snippet2>
    End Sub
End Module
