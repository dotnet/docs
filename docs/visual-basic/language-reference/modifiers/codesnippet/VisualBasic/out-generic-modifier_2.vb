        ' Covariant delegate.
        Public Delegate Function DCovariant(Of Out R)() As R

        ' Methods that match the delegate signature.
        Public Shared Function SampleControl() As Control
            Return New Control()
        End Function

        Public Shared Function SampleButton() As Button
            Return New Button()
        End Function

        Private Sub Test()

            ' Instantiating the delegates with the methods.
            Dim dControl As DCovariant(Of Control) =
                AddressOf SampleControl
            Dim dButton As DCovariant(Of Button) =
                AddressOf SampleButton

            ' You can assign dButton to dControl
            ' because the DCovariant delegate is covariant.
            dControl = dButton

            ' Invoke the delegate.
            dControl()
        End Sub