        ' Generate the design-time markup.
        Public Overrides Function GetDesignTimeHtml( _
            ByVal regions As DesignerRegionCollection) As String

            ' Make the control more visible in the designer.  
            ' Enclose the markup in a table with an orange border. 
            Dim openTableMarkup As String = _
                "<table><tr><td style=""border:4 solid #FF7F00;"">"
            Dim closeTableMarkup As String = "</td></tr></table>"

            ' Call the base method to generate the markup.
            Dim markup As String = MyBase.GetDesignTimeHtml(regions)

            Return openTableMarkup & markup & closeTableMarkup

        End Function ' GetDesignTimeHtml