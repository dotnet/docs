        Public Overrides Function GetSortedActionItems() _
        As DesignerActionItemCollection
            Dim items As New DesignerActionItemCollection()

            'Define static section header entries.
            items.Add(New DesignerActionHeaderItem("Appearance"))
            items.Add(New DesignerActionHeaderItem("Information"))

            'Boolean property for locking color selections.
            items.Add(New DesignerActionPropertyItem( _
            "LockColors", _
            "Lock Colors", _
            "Appearance", _
            "Locks the color properties."))

            If Not LockColors Then
                items.Add( _
                New DesignerActionPropertyItem( _
                "BackColor", _
                "Back Color", _
                "Appearance", _
                "Selects the background color."))

                items.Add( _
                New DesignerActionPropertyItem( _
                "ForeColor", _
                "Fore Color", _
                "Appearance", _
                "Selects the foreground color."))

                'This next method item is also added to the context menu 
                ' (as a designer verb).
                items.Add( _
                New DesignerActionMethodItem( _
                Me, _
                "InvertColors", _
                "Invert Colors", _
                "Appearance", _
                "Inverts the fore and background colors.", _
                True))
            End If
            items.Add( _
            New DesignerActionPropertyItem( _
            "Text", _
            "Text String", _
            "Appearance", _
            "Sets the display text."))

            'Create entries for static Information section.
            Dim location As New StringBuilder("Location: ")
            location.Append(colLabel.Location)
            Dim size As New StringBuilder("Size: ")
            size.Append(colLabel.Size)

            items.Add( _
            New DesignerActionTextItem( _
            location.ToString(), _
            "Information"))

            items.Add( _
            New DesignerActionTextItem( _
            size.ToString(), _
            "Information"))

            Return items
        End Function