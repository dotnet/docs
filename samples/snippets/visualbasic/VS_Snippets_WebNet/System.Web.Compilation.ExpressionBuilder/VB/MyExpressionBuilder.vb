' <Snippet1> 
Imports System
Imports System.CodeDom
Imports System.Web.UI
Imports System.ComponentModel
Imports System.Web.Compilation
Imports System.Web.UI.Design

' Apply ExpressionEditorAttributes to allow the 
' expression to appear in the designer.
<ExpressionPrefix("MyCustomExpression")> _
<ExpressionEditor("MyCustomExpressionEditor")> _
Public Class MyExpressionBuilder
    Inherits ExpressionBuilder
    ' Create a method that will return the result 
    ' set for the expression argument.
    Public Shared Function GetEvalData(ByVal expression As String, _
       ByVal target As Type, ByVal entry As String) As Object
        Return expression
    End Function

    ' <Snippet3>
    Public Overrides Function EvaluateExpression(ByVal target As Object, _
       ByVal entry As BoundPropertyEntry, ByVal parsedData As Object, _
       ByVal context As ExpressionBuilderContext) As Object
        Return GetEvalData(entry.Expression, target.GetType(), entry.Name)
    End Function
    ' </Snippet3> 

    ' <Snippet4> 
    Public Overrides Function GetCodeExpression(ByVal entry _
       As BoundPropertyEntry, ByVal parsedData As Object, ByVal context _
       As ExpressionBuilderContext) As CodeExpression
        Dim type1 As Type = entry.DeclaringType
        Dim descriptor1 As PropertyDescriptor = _
           TypeDescriptor.GetProperties(type1)(entry.PropertyInfo.Name)
        Dim expressionArray1(2) As CodeExpression
        expressionArray1(0) = New CodePrimitiveExpression(entry.Expression.Trim())
        expressionArray1(1) = New CodeTypeOfExpression(type1)
        expressionArray1(2) = New CodePrimitiveExpression(entry.Name)
        Return New CodeCastExpression(descriptor1.PropertyType, _
           New CodeMethodInvokeExpression(New CodeTypeReferenceExpression _
           (MyBase.GetType()), "GetEvalData", expressionArray1))
    End Function
    ' </Snippet4> 

    ' <Snippet2>
    Public Overrides ReadOnly Property SupportsEvaluate() As Boolean
        Get
            Return True
        End Get
    End Property
    ' </Snippet2>
End Class
' </Snippet1>

