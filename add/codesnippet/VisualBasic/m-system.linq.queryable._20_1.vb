        ' Create a list of MemberInfo objects.
        Dim members As List(Of System.Reflection.MemberInfo) = GetType(String).GetMembers().ToList()

        ' Return only those items that can be cast to type PropertyInfo.
        Dim propertiesOnly As IQueryable(Of System.Reflection.PropertyInfo) = _
                members.AsQueryable().OfType(Of System.Reflection.PropertyInfo)()

        Dim output As New System.Text.StringBuilder
        output.AppendLine("Members of type 'PropertyInfo' are:")
        For Each pi As System.Reflection.PropertyInfo In propertiesOnly
            output.AppendLine(pi.Name)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' Members of type 'PropertyInfo' are:
        ' Chars
        ' Length
