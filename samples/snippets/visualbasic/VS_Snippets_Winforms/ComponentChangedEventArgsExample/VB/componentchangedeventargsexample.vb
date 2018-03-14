Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace MiscCompModSamplesVB

    Public Class ComponentChangedEventArgsExample

        Public Sub New()
        End Sub 'New

        '<Snippet1>        
        ' This example method creates a ComponentChangedEventArgs using the specified arguments.
        ' Typically, this type of event args is created by a design mode subsystem.            
        Public Function CreateComponentChangedEventArgs(ByVal component As Object, ByVal member As MemberDescriptor, ByVal oldValue As Object, ByVal newValue As Object) As ComponentChangedEventArgs
            ' Creates a component changed event args with the specified arguments.
            Dim args As New ComponentChangedEventArgs(component, member, oldValue, newValue)

            ' The component that has changed:              args.Component
            ' The member of the component that changed:    args.Member
            ' The old value of the member:                 args.oldValue
            ' The new value of the member:                 args.newValue
            Return args
        End Function
        '</Snippet1>

    End Class 'ComponentChangedEventArgsExample 
End Namespace 'MiscCompModSamples