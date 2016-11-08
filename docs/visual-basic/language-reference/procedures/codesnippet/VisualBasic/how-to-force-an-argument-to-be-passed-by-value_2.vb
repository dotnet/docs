    Dim str As String = "Cannot be replaced if passed ByVal"

    ' The following call passes str ByVal even though it is declared ByRef.
    Call setNewString((str))
    ' The parentheses around str protect it from change.
    MsgBox(str)

    ' The following call allows str to be passed ByRef as declared.
    Call setNewString(str)
    ' Variable str is not protected from change.
    MsgBox(str)