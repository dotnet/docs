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