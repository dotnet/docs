'<snippet1>
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.Design.WebControls.WebParts
Imports System.ComponentModel
Imports System.Collections

' <summary>
' ConnectionsZoneSample provides a blank inheritance of
' the ConnectionsZone class for the purpose of attaching
' a custom designer.
' ConnectionsZoneSampleDesigner shows how to edit the
' PreFilterProperties() method to hide a specific property
' at design time.
' </summary>
Namespace Samples.AspNet.VB.Controls
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(ConnectionsZoneSampleDesigner))> _
    Public Class ConnectionsZoneSample
        Inherits ConnectionsZone
    End Class
    Public Class ConnectionsZoneSampleDesigner
        Inherits ConnectionsZoneDesigner
        ' Here is the property we will hide.
        Private propertyToHide As String = "BackColor"

        Protected Overrides Sub PreFilterProperties(properties As IDictionary)
            ' Invoke the base method. This will hide those properties
            ' specified in ConnectionsZoneDesigner.
            MyBase.PreFilterProperties(properties)

            ' Set attributes to remove it from the property grid and any editors.
            Dim newAttributes As Attribute() = New Attribute() {New BrowsableAttribute(False), New EditorBrowsableAttribute(EditorBrowsableState.Never)}

            Dim [property] As PropertyDescriptor = DirectCast(properties(propertyToHide), PropertyDescriptor)
            If [property] IsNot Nothing Then
                ' Re-create the property with the attributes specified above.
                properties(propertyToHide) = TypeDescriptor.CreateProperty([property].ComponentType, [property], newAttributes)
            End If
        End Sub
    End Class
End Namespace
'</snippet1>