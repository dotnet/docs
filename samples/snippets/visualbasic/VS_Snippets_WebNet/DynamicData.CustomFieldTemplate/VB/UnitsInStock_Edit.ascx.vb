Imports System
' <Snippet4> 
Imports System.Web.DynamicData
Imports System.Collections.Specialized

Partial Public Class DynamicData_FieldTemplates_UnitsInStock_Edit
    Inherits FieldTemplateUserControl
    Protected Sub Page_Load(ByVal sender As Object, _
                            ByVal e As EventArgs)
        TextBox1.ToolTip = Column.Description

        ' Set the required validation.
        SetUpValidator(RequiredFieldValidator1)
        SetUpValidator(CompareValidator1)

        ' This validator is used to customize the
        ' data field editing. The range is defined
        ' in the Product partial class.
        SetUpValidator(RangeValidator1)

        SetUpValidator(DynamicValidator1)
    End Sub

    Protected Overloads Overrides Sub ExtractValues( _
    ByVal dictionary As IOrderedDictionary)
        ' Assign the new value entered by the user.
        dictionary(Column.Name) = ConvertEditedValue(TextBox1.Text)
    End Sub
End Class
' </Snippet4>