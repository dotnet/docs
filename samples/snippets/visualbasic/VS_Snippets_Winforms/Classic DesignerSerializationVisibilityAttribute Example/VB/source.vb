' <Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms

Namespace DesignerSerializationVisibilityTest
    _
    ' The code for this user control declares a public property of type DimensionData with a DesignerSerializationVisibility 
    ' attribute set to DesignerSerializationVisibility.Content, indicating that the properties of the object should be serialized.

    ' The public, not hidden properties of the object that are set at design time will be persisted in the initialization code
    ' for the class object. Content persistence will not work for structs without a custom TypeConverter.		
    Public Class ContentSerializationExampleControl
        Inherits System.Windows.Forms.UserControl
        Private components As System.ComponentModel.Container = Nothing


        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Dimensions() As DimensionData
            Get
                Return New DimensionData(Me)
            End Get
        End Property


        Public Sub New()
            InitializeComponent()
        End Sub 'New


        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If (components IsNot Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose


        Private Sub InitializeComponent()
        End Sub 'InitializeComponent
    End Class 'ContentSerializationExampleControl

    ' This attribute indicates that the public properties of this object should be listed in the property grid.
   <TypeConverterAttribute(GetType(System.ComponentModel.ExpandableObjectConverter))> _   
    Public Class DimensionData
        Private owner As Control

        ' This class reads and writes the Location and Size properties from the Control which it is initialized to.
        Friend Sub New(ByVal owner As Control)
            Me.owner = owner
        End Sub 'New


        Public Property Location() As Point
            Get
                Return owner.Location
            End Get
            Set(ByVal Value As Point)
                owner.Location = Value
            End Set
        End Property


        Public Property FormSize() As Size
            Get
                Return owner.Size
            End Get
            Set(ByVal Value As Size)
                owner.Size = Value
            End Set
        End Property
    End Class 'DimensionData
End Namespace 'DesignerSerializationVisibilityTest
' </Snippet1>