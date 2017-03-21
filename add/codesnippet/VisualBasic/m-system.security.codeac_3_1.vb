        Public Overrides Function Intersect(ByVal target As IPermission) As IPermission
            Console.WriteLine("************* Entering Intersect *********************")
            If target Is Nothing Then
                Return Nothing
            End If
#If (Debug) Then

            Console.WriteLine(("This is = " + CType(Me, NameIdPermission).Name))
            Console.WriteLine(("Target is " + CType(target, NameIdPermission).m_name))
#End If
            If Not VerifyType(target) Then
                Throw New ArgumentException(String.Format("Argument is wrong type.", Me.GetType().FullName))
            End If

            Dim operand As NameIdPermission = CType(target, NameIdPermission)

            If operand.IsSubsetOf(Me) Then
                Return operand.Copy()
            ElseIf Me.IsSubsetOf(operand) Then
                Return Me.Copy()
            Else
                Return Nothing
            End If
        End Function 'Intersect