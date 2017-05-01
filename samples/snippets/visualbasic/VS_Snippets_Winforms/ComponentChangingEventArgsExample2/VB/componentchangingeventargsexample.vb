Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace MiscCompModSamplesVB

    Public Class ComponentChangingEventArgsExample

        Public Sub New()
        End Sub 'New

        '<Snippet1>
        ' This example method creates a ComponentChangingEventArgs using the specified arguments.
        ' Typically, this type of event args is created by a design mode subsystem.  
        Public Function CreateComponentChangingEventArgs(ByVal component As Object, ByVal member As MemberDescriptor) As ComponentChangingEventArgs
            Dim args As New ComponentChangingEventArgs(component, member)

            ' The component that is about to change:       args.Component
            ' The member that is about to change:          args.Member

            Return args
        End Function
        '</Snippet1>

    End Class 'ComponentChangingEventArgsExample 
End Namespace 'MiscCompModSamples