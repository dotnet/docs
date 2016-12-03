        Dim getSortColumn = Function(index As Integer)
                                Select Case index
                                    Case 0
                                        Return "FirstName"
                                    Case 1
                                        Return "LastName"
                                    Case 2
                                        Return "CompanyName"
                                    Case Else
                                        Return "LastName"
                                End Select
                            End Function