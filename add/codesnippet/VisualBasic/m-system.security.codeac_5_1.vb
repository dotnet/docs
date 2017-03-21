        Public Overrides Function IsSubsetOf(ByVal target As IPermission) As Boolean

#If (Debug) Then

            Console.WriteLine("************* Entering IsSubsetOf *********************")
#End If
            If target Is Nothing Then
                Console.WriteLine("IsSubsetOf: target == null")
                Return False
            End If
#If (Debug) Then
            Console.WriteLine(("This is = " + CType(Me, NameIdPermission).Name))
            Console.WriteLine(("Target is " + CType(target, NameIdPermission).m_name))
#End If
            Try
                Dim operand As NameIdPermission = CType(target, NameIdPermission)

                ' The following check for unrestricted permission is only included as an example for
                ' permissions that allow the unrestricted state. It is of no value for this permission.
                If True = operand.m_Unrestricted Then
                    Return True
                ElseIf True = Me.m_Unrestricted Then
                    Return False
                End If

                If Not (Me.m_name Is Nothing) Then
                    If operand.m_name Is Nothing Then
                        Return False
                    End If
                    If Me.m_name = "" Then
                        Return True
                    End If
                End If
                If Me.m_name.Equals(operand.m_name) Then
                    Return True
                Else
                    ' Check for wild card character '*'.
                    Dim i As Integer = operand.m_name.LastIndexOf("*")

                    If i > 0 Then
                        Dim prefix As String = operand.m_name.Substring(0, i)

                        If Me.m_name.StartsWith(prefix) Then
                            Return True
                        End If
                    End If
                End If

                Return False
            Catch
                Throw New ArgumentException(String.Format("Argument_WrongType", Me.GetType().FullName))
            End Try
        End Function
