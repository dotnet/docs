        ' Generate the design-time markup for the control 
        ' when the template is empty.
        Protected Overrides Function GetEmptyDesignTimeHtml() As String

            ' Generate a design-time placeholder containing the names of all
            ' the role groups.
            Dim myLoginViewCtl As MyLoginView = CType(ViewControl, MyLoginView)
            Dim roleGroups As RoleGroupCollection = myLoginViewCtl.RoleGroups
            Dim RoleNames As String = Nothing
            Dim rgX As Integer

            ' If there are any role groups, form a string of their names.
            If roleGroups.Count > 0 Then

                roleNames = "Role Groups: <br /> &nbsp;&nbsp;" & _
                    roleGroups(0).ToString()

                For rgX = 1 To roleGroups.Count - 1
                    roleNames &= "<br /> &nbsp;&nbsp;" & _
                        roleGroups(rgX).ToString()
                Next rgX
            End If

            Return CreatePlaceHolderDesignTimeHtml(roleNames)

        End Function ' GetEmptyDesignTimeHtml