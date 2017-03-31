' <snippet1>
Imports System
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Drawing
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls

Namespace Examples.AspNet

    ' Create a designer class for the SimpleDataList class.
    <System.Security.Permissions.SecurityPermission( _
    System.Security.Permissions.SecurityAction.Demand, _
    Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Public Class SimpleDataListDesigner
        Inherits DataListDesigner

        Private simpleList As SimpleDataList


        ' <snippet2>
        ' Override the GetDesignTimeHtml method to add style to the control
        ' on the design surface.
        Public Overrides Function GetDesignTimeHtml() As String
            ' Cast the control to the Component property of the designer.
            simpleList = CType(Component, SimpleDataList)

            Dim designTimeHtml As String = Nothing

            ' Create variables to hold current property values.
            Dim oldBorderWidth As Unit = simpleList.BorderWidth
            Dim oldBorderColor As Color = simpleList.BorderColor

            ' Set the properties and generate the design-time HTML.
            If (simpleList.Enabled) Then
                Try
                    simpleList.BorderWidth = Unit.Point(5)
                    simpleList.BorderColor = Color.Purple
                    designTimeHtml = MyBase.GetDesignTimeHtml()

                    ' Call the GetErrorDesignTimeHtml method if an
                    ' exception occurs.
                Catch ex As Exception
                    designTimeHtml = GetErrorDesignTimeHtml(ex)

                    ' Return the properties to their original settings.
                Finally
                    simpleList.BorderWidth = oldBorderWidth
                    simpleList.BorderColor = oldBorderColor
                End Try
                ' If the list is not enabled, call the GetEmptyDesignTimeHtml
                ' method.
            Else
                designTimeHtml = GetEmptyDesignTimeHtml()
            End If

            Return designTimeHtml

        End Function
        ' </snippet2>

        ' <snippet3>
        Protected Overrides Function GetEmptyDesignTimeHtml() As String
            Dim emptyText As String

            ' Check the CanEnterTemplateMode property to
            ' specify which text to display if ItemTemplate 
            ' does not contain a value.
            If CanEnterTemplateMode Then
                emptyText = _
                    "<b>Either the Enabled property value is false " + _
                    "or you need to set the ItemTemplate for this " + _
                    "control.<br>Right-click to edit templates.</b>"
            Else
                emptyText = _
                    "<b>You cannot edit templates in this view.<br>" + _
                    "Switch to HTML view to define the ItemTemplate.</b>"
            End If

            Return CreatePlaceHolderDesignTimeHtml(emptyText)
        End Function
        ' </snippet3>

        ' <snippet4>
        ' Generate HTML to indicate that an error has occurred.
        Protected Overrides Function GetErrorDesignTimeHtml(ByVal exc As _
            Exception) As String

            Return CreatePlaceHolderDesignTimeHtml( _
                "<b>An error occurred</b>.<br>Check to ensure that all " + _
                "properties are valid.")
        End Function
        ' </snippet4>


        ' <snippet5>
        ' Override the Initialize method to ensure that
        ' only an instance of the SimpleDataList class is
        ' used by this designer class.
        Public Overrides Sub Initialize(ByVal component As IComponent)
            simpleList = CType(component, SimpleDataList)

            If IsNothing(simpleList) Then
                Throw New ArgumentException("Must be a SimpleDataList.", "component")
            End If

            MyBase.Initialize(component)
        End Sub
        ' </snippet5>
    End Class
End Namespace
' </snippet1>
