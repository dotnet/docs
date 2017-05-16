Namespace Common

    ''' <summary>
    ''' Implementation of <see cref="INotifyPropertyChanged"/> to simplify models.
    ''' </summary>
    <Windows.Foundation.Metadata.WebHostHidden>
    Public MustInherit Class BindableBase
        Implements INotifyPropertyChanged

        ''' <summary>
        ''' Multicast event for property change notifications.
        ''' </summary>
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        ''' <summary>
        ''' Checks if a property already matches a desired value.  Sets the property and notifies
        ''' listeners only when necessary.
        ''' </summary>
        ''' <typeparam name="T">Type of the property.</typeparam>
        ''' <param name="storage">Reference to a property with both getter and setter.</param>
        ''' <param name="value">Desired value for the property.</param>
        ''' <param name="propertyName">Name of the property used to notify listeners.  This value
        ''' is optional and can be provided automatically when invoked from compilers that support
        ''' CallerMemberName.</param>
        ''' <returns>True if the value was changed, false if the existing value matched the
        ''' desired value.</returns>
        Protected Function SetProperty(Of T)(ByRef storage As T, value As T,
                                        <CallerMemberName> Optional propertyName As String = Nothing) As Boolean

            If Object.Equals(storage, value) Then Return False

            storage = value
            Me.OnPropertyChanged(propertyName)
            Return True
        End Function

        ''' <summary>
        ''' Notifies listeners that a property value has changed.
        ''' </summary>
        ''' <param name="propertyName">Name of the property used to notify listeners.  This value
        ''' is optional and can be provided automatically when invoked from compilers that support
        ''' <see cref="CallerMemberNameAttribute"/>.</param>
        Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

    End Class

End Namespace
