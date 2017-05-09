' <snippet1>
Imports System
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet

<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
Public Class StaticParameter
   Inherits Parameter


   Public Sub New()
   End Sub

' <snippet2>
  ' The StaticParameter(string, object) constructor
  ' initializes the DataValue property and calls the
  ' Parameter(string) constructor to initialize the Name property.
   Public Sub New(name As String, value As Object)
      MyBase.New(name)
      DataValue = value
   End Sub
' </snippet2>

' <snippet3>
   ' The StaticParameter(string, TypeCode, object) constructor
   ' initializes the DataValue property and calls the
   ' Parameter(string, TypeCode) constructor to initialize the Name and
   ' Type properties.
   Public Sub New(name As String, type As TypeCode, value As Object)
      MyBase.New(name, type)
      DataValue = value
   End Sub
' </snippet3>
' <snippet4>
   ' The StaticParameter copy constructor is provided to ensure that
   ' the state contained in the DataValue property is copied to new
   ' instances of the class.
   Protected Sub New(original As StaticParameter)
      MyBase.New(original)
      DataValue = original.DataValue
   End Sub

   ' The Clone method is overridden to call the
   ' StaticParameter copy constructor, so that the data in
   ' the DataValue property is correctly transferred to the
   ' new instance of the StaticParameter.
   Protected Overrides Function Clone() As Parameter
      Return New StaticParameter(Me)
   End Function
' </snippet4>

' <snippet5>
   ' The DataValue can be any arbitrary object and is stored in ViewState.
   Public Property DataValue() As Object
      Get
         Return ViewState("Value")
      End Get
      Set
         ViewState("Value") = value
      End Set
   End Property
' </snippet5>
' <snippet7>
   ' The Value property is a type safe convenience property
   ' used when the StaticParameter represents string data.
   ' It gets the string value of the DataValue property, and
   ' sets the DataValue property directly.
   Public Property Value() As String
      Get
         Dim o As Object = DataValue
         If o Is Nothing OrElse Not TypeOf o Is String Then
            Return String.Empty
         End If
         Return CStr(o)
      End Get
      Set
         DataValue = value
         OnParameterChanged()
      End Set
   End Property
' </snippet7>
' <snippet6>
   ' The Evaluate method is overridden to return the
   ' DataValue property instead of the DefaultValue.
   Protected Overrides Function Evaluate(context As HttpContext, control As Control) As Object
      If context Is Nothing Then
          Return Nothing
      Else
          Return DataValue
      End If
   End Function
' </snippet6>
End Class ' StaticParameter

End Namespace ' Samples.AspNet
' </snippet1>