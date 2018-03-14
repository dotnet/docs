' <snippet6>
Imports System
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.Security.Permissions

Namespace Examples.AspNet

    ' Associate the SimpleDataList class with its designer using the
    ' DesignerAttribute class.

    ' Associate the SimpleDataList class with the DataListComponentEditor
    ' object using the EditorAttribute class.

    <DesignerAttribute( _
        GetType(SimpleDataListDesigner)), _
    EditorAttribute(GetType(DataListComponentEditor), _
        GetType(ComponentEditor)) _
     > _
    Public Class SimpleDataList
        Inherits DataList

        ' To customize the DataList class, insert code here.

    End Class
End Namespace
' </snippet6>
