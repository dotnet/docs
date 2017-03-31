Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design


Namespace MiscCompModSamples    

    Public Class ComponentEventArgsExample

        Public Sub New()
        End Sub 'New

        '<Snippet1>
        ' This example method creates a ComponentEventArgs using the specified argument.
        ' Typically, this type of event args is created by a design mode subsystem.  
        Public Function CreateComponentEventArgs(ByVal component As IComponent) As ComponentEventArgs

            Dim args As New ComponentEventArgs(component)

            ' The component that is related to the event:  args.Component

            Return args
        End Function
        '</Snippet1>
    End Class 'ComponentEventArgsExample 
End Namespace 'MiscCompModSamples