    For Each desc In From element In catalog.<Catalog>.<Book>.<Description>
      ' Replace and preserve inner XML.
      desc.ReplaceWith(<Abstract><%= desc.Nodes %></Abstract>)
    Next

    For Each price In From element In catalog.<Catalog>.<Book>.<Price>
      ' Replace with text value.
      price.ReplaceWith(<MSRP><%= price.Value %></MSRP>)
    Next