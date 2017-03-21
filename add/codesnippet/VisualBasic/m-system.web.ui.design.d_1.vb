            ' Applies styles based on the Name of the AutoFormat
            Public Overrides Sub Apply(ByVal inLabel As Control)
                If TypeOf inLabel Is IndentLabel Then
                    Dim ctl As IndentLabel = CType(inLabel, IndentLabel)

                    ' Apply formatting according to the Name
                    If Me.Name.Equals("MyClassic") Then
                        ' For MyClassic, apply style elements directly to the control
                        ctl.ForeColor = Color.Gray
                        ctl.BackColor = Color.LightGray
                        ctl.Font.Size = FontUnit.XSmall
                        ctl.Font.Name = "Verdana,Geneva,Sans-Serif"
                    ElseIf Me.Name.Equals("MyBright") Then
                        ' For MyBright, apply style elements to the Style object
                        Me.Style.ForeColor = Color.Maroon
                        Me.Style.BackColor = Color.Yellow
                        Me.Style.Font.Size = FontUnit.Medium

                        ' Merge the AutoFormat style with the control's style
                        ctl.MergeStyle(Me.Style)
                    Else
                        ' For the Default format, apply style elements to the control
                        ctl.ForeColor = Color.Black
                        ctl.BackColor = Color.Empty
                        ctl.Font.Size = FontUnit.XSmall
                    End If
                End If
            End Sub