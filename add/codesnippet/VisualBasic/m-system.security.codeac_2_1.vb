        Public Overrides Function Union(ByVal target As IPermission) As IPermission
#If (Debug) Then

            Console.WriteLine("************* Entering Union *********************")
#End If
            If target Is Nothing Then
                Return Me
            End If
#If (Debug) Then
            Console.WriteLine(("This is = " + CType(Me, NameIdPermission).Name))
            Console.WriteLine(("Target is " + CType(target, NameIdPermission).m_name))
#End If
            If Not VerifyType(target) Then
                Throw New ArgumentException(String.Format("Argument_WrongType", Me.GetType().FullName))
            End If

            Dim operand As NameIdPermission = CType(target, NameIdPermission)

            If operand.IsSubsetOf(Me) Then
                Return Me.Copy()
            ElseIf Me.IsSubsetOf(operand) Then
                Return operand.Copy()
            Else
                Return Nothing
            End If
        End Function 'Union