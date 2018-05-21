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