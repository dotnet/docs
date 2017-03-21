        ' Declare a generic method.
        Dim printMethod As New CodeMemberMethod()
        Dim sType As New CodeTypeParameter("S")
        sType.HasConstructorConstraint = True
        Dim tType As New CodeTypeParameter("T")
        tType.HasConstructorConstraint = True

        printMethod.Name = "Print"
        printMethod.TypeParameters.Add(sType)
        printMethod.TypeParameters.Add(tType)
