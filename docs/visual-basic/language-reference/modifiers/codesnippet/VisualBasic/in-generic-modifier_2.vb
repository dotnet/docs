        ' Contravariant delegate.
        Public Delegate Sub DContravariant(Of In A)(ByVal argument As A)

        ' Methods that match the delegate signature.
        Public Shared Sub SampleControl(ByVal control As Control)
        End Sub

        Public Shared Sub SampleButton(ByVal control As Button)
        End Sub

        Private Sub Test()

            ' Instantiating the delegates with the methods.
            Dim dControl As DContravariant(Of Control) =
                AddressOf SampleControl
            Dim dButton As DContravariant(Of Button) =
                AddressOf SampleButton

            ' You can assign dControl to dButton
            ' because the DContravariant delegate is contravariant.
            dButton = dControl

            ' Invoke the delegate.
            dButton(New Button())
        End Sub