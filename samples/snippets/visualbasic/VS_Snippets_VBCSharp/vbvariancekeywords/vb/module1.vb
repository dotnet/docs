Imports System.Windows.Forms

Module Module1
    '<Snippet1>
    ' Contravariant interface.
    Interface IContravariant(Of In A)
    End Interface

    ' Extending contravariant interface.
    Interface IExtContravariant(Of In A)
        Inherits IContravariant(Of A)
    End Interface

    ' Implementing contravariant interface.
    Class Sample(Of A)
        Implements IContravariant(Of A)
    End Class

    Sub Main()
        Dim iobj As IContravariant(Of Object) = New Sample(Of Object)()
        Dim istr As IContravariant(Of String) = New Sample(Of String)()

        ' You can assign iobj to istr, because
        ' the IContravariant interface is contravariant.
        istr = iobj
    End Sub
    '</Snippet1>
End Module

Module m2
    Class Sample
        '<Snippet2>
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
        '</Snippet2>
    End Class
End Module
Module m3
    '<Snippet3>
    ' Covariant interface.
    Interface ICovariant(Of Out R)
    End Interface

    ' Extending covariant interface.
    Interface IExtCovariant(Of Out R)
        Inherits ICovariant(Of R)
    End Interface

    ' Implementing covariant interface.
    Class Sample(Of R)
        Implements ICovariant(Of R)
    End Class

    Sub Main()
        Dim iobj As ICovariant(Of Object) = New Sample(Of Object)()
        Dim istr As ICovariant(Of String) = New Sample(Of String)()

        ' You can assign istr to iobj because
        ' the ICovariant interface is covariant.
        iobj = istr
    End Sub
    '</Snippet3>
End Module

Module m4
    Public Class Sample
        '<Snippet4>
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
        '</Snippet4>
    End Class

End Module