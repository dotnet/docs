            ' Not allowed:
            ' Dim aType = New With { .
            '    PropertyName = "Value"

            ' Allowed:
            Dim aType = New With {.PropertyName =
                "Value"}



            Dim log As New EventLog()

            ' Not allowed:
            ' With log
            '    .
            '      Source = "Application"
            ' End With

            ' Allowed:
            With log
                .Source =
                  "Application"
            End With