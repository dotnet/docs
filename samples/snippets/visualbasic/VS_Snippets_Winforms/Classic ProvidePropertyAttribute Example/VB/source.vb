Imports System
Imports System.Globalization
Imports System.ComponentModel
Imports System.Windows.Forms



' <Snippet1>
<ProvideProperty("MyProperty", GetType(Control))> _
Public Class SampleClass
    Implements IExtenderProvider
    Protected ciMine As CultureInfo = Nothing

    ' Provides the Get portion of MyProperty. 
    Public Function GetMyProperty(myControl As Control) As CultureInfo
        ' Insert code here.
        Return ciMine
    End Function 'GetMyProperty

    ' Provides the Set portion of MyProperty.
    Public Sub SetMyProperty(myControl As Control, value As String)
        ' Insert code here.
    End Sub 'SetMyProperty

    ' When you inherit from IExtenderProvider, you must implement the 
    ' CanExtend method. 
    Public Function CanExtend(target As [Object]) As Boolean Implements IExtenderProvider.CanExtend
        Return TypeOf target Is Control
    End Function 'CanExtend

    ' Insert additional code here.

End Class
' </Snippet1>
