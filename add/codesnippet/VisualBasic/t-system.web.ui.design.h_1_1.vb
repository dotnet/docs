    ' Derive a class from the HyperLinkDataBindingHandler. It will 
    ' resolve  data binding for the CustomHyperlink at design time.
    Public Class CustomHyperLinkDataBindingHandler
        Inherits HyperLinkDataBindingHandler

        ' Override the DataBindControl to set property values in  
        ' the DataBindingCollection at design time.
        Public Overrides Sub DataBindControl( _
            ByVal designerHost As IDesignerHost, ByVal control As Control)

            Dim bindings As DataBindingCollection = _
                CType(control, IDataBindingsAccessor).DataBindings
            Dim imageBinding As DataBinding = bindings("ImageUrl")

            If Not (imageBinding Is Nothing) Then
                Dim hLink As CustomHyperLink = CType(control, CustomHyperLink)
                hLink.ImageUrl = "Image URL."
            End If

            MyBase.DataBindControl(designerHost, control)
        End Sub ' DataBindControl
    End Class ' CustomHyperLinkDataBindingHandler