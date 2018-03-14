'<Snippet1>
#Const CODE_ANALYSIS = True
Imports System
Imports System.Diagnostics.CodeAnalysis



Class Library
    
    '<Snippet2>
    <SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", MessageId:="isChecked"), _
     SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId:="fileIdentifier")> _
    Shared Sub FileNode(ByVal name As String, ByVal isChecked As Boolean)
        Dim fileIdentifier As String = name
        Dim fileName As String = name
        Dim version As String = String.Empty

    End Sub 'FileNode
    '</Snippet2>
End Class 'Library 
'</Snippet1>