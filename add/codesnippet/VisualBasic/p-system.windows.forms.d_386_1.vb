    Class MyDesigner
        Inherits ControlDesigner
        Private myAdorner As Adorner


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (myAdorner IsNot Nothing) Then
                Dim b As System.Windows.Forms.Design.Behavior.BehaviorService _
                    = BehaviorService
                If (b IsNot Nothing) Then
                    b.Adorners.Remove(myAdorner)
                End If
            End If

        End Sub


        Public Overrides Sub Initialize(ByVal component As IComponent)
            MyBase.Initialize(component)

            ' Add the custom set of glyphs using the BehaviorService.  
            ' Glyphs live on adornders.
            myAdorner = New Adorner()
            BehaviorService.Adorners.Add(myAdorner)
            myAdorner.Glyphs.Add(New MyGlyph(BehaviorService, Control))

        End Sub
    End Class