        ' Create the regions and design-time markup. Called by the designer host.
        Public Overrides Function GetDesignTimeHtml(ByVal regions As DesignerRegionCollection) As String
            ' Create 3 regions: 2 clickable headers and an editable row
            regions.Add(New DesignerRegion(Me, "Header0"))
            regions.Add(New DesignerRegion(Me, "Header1"))

            ' Create an editable region and add it to the regions
            Dim editableRegion As EditableDesignerRegion = _
                New EditableDesignerRegion(Me, _
                    "Content" & myControl.CurrentView, False)
            regions.Add(editableRegion)

            ' Set the highlight for the selected region
            regions(myControl.CurrentView).Highlight = True

            ' Use the base class to render the markup
            Return MyBase.GetDesignTimeHtml()
        End Function