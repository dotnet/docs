'<Snippet1>
Imports System.Runtime.InteropServices

<ComImport()>
<Guid("8DA56996-A151-4136-B474-32784559F6DF")>
Public Interface ISampleInterface
    Sub GetUserInput()
    ReadOnly Property UserInput As String
    '</Snippet1>
    '<Snippet3>
    Function GetDate() As Date
    '</Snippet3>
    '<Snippet4>
End Interface
'</Snippet4>



