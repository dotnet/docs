        <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
        Public Overrides Function GetChildControlType(ByVal tagName As String, ByVal attribs As IDictionary) As Type

            ' Distinguish between two possible types of child controls.
            If tagName.ToLower().EndsWith("myoption1") Then
                Return GetType(MyOption1)
            ElseIf tagName.ToLower().EndsWith("myoption2") Then
                Return GetType(MyOption2)
            End If
            Return Nothing

        End Function 