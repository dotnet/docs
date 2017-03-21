        <Verification("ADA", "1194.22(a)", VerificationReportLevel.Error, 1, "The image is missing a text equivalent.", VerificationRule.NotEmptyString, "ImageUrl")> _
        <Verification("WCAG", "1.1", VerificationReportLevel.Error, 1, "The image is missing a text equivalent.", VerificationRule.NotEmptyString, "ImageUrl")> _
        Public Property ImageText() As String
            Get
                If ViewState("ImageText") Is Nothing Then
                    Return String.Empty
                Else
                    Return CType(ViewState("ImageText"), String)
                End If
            End Get
            Set(ByVal value As String)
                ViewState("ImageText") = value
            End Set
        End Property


        Public Property ImageUrl() As String
            Get
                If ViewState("ImageUrl") Is Nothing Then
                    Return String.Empty
                Else
                    Return CType(ViewState("ImageUrl"), String)
                End If
            End Get
            Set(ByVal value As String)
                ViewState("ImageUrl") = value
            End Set
        End Property