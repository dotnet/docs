Imports System
Imports System.CodeDom
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization

Namespace CodeDomSerializerExceptionExampleVB
    _
    Class CodeDomSerializerExceptionExampleVB

        <STAThread()> _
        Shared Sub Main()
            '<Snippet1>
            Throw New CodeDomSerializerException("This exception was raised as an example.", New CodeLinePragma("Example.txt", 20))
            '</Snippet1>
        End Sub 'Main 

    End Class 'CodeDomSerializerExceptionExample

End Namespace 'CodeDomSerializerExceptionExample