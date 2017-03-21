        ' Create a parent control.
        Dim c As New System.Windows.Forms.Control()
        c.CreateControl()

        ' Launch the Color Builder using the specified control 
        ' parent and an initial HTML format ("RRGGBB") color string.
        System.Web.UI.Design.ColorBuilder.BuildColor(Me.Component, c, "405599")