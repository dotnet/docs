Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



MustInherit Public Class Coll1
    Inherits EventDescriptorCollection
    Protected myNewColl As Object
    
    
    Public Sub New()
        MyBase.New(Nothing)
    End Sub 'New
     
    Protected Sub Method()
        ' <Snippet1>
        myNewColl = Me.Sort(New String() {"D", "B"})
        ' </Snippet1>
    End Sub 'Method 
End Class 'Coll1
