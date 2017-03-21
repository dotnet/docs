    Private Sub AddMetafileCommentBytes(ByVal e As PaintEventArgs)

        ' Create temporary graphics object for metafile
        ' creation and get handle to its device context.
        Dim newGraphics As Graphics = Me.CreateGraphics()
        Dim hdc As IntPtr = newGraphics.GetHdc()

        ' Create metafile object to record.
        Dim metaFile1 As New Metafile("SampMeta.emf", hdc)

        ' Create graphics object to record metaFile.
        Dim metaGraphics As Graphics = Graphics.FromImage(metaFile1)

        ' Draw rectangle in metaFile.
        metaGraphics.DrawRectangle(New Pen(Color.Black, 5), 0, 0, 100, 100)

        ' Create comment and add to metaFile.
        Dim metaComment As Byte() = {CByte("T"), CByte("e"), CByte("s"), _
        CByte("t")}
        metaGraphics.AddMetafileComment(metaComment)

        ' Dispose of graphics object.
        metaGraphics.Dispose()

        ' Dispose of metafile.
        metaFile1.Dispose()

        ' Release handle to scratch device context.
        newGraphics.ReleaseHdc(hdc)

        ' Dispose of scratch graphics object.
        newGraphics.Dispose()

        ' Create existing metafile object to draw.
        Dim metaFile2 As New Metafile("SampMeta.emf")

        ' Draw metaFile to screen.
        e.Graphics.DrawImage(metaFile2, New Point(0, 0))

        ' Dispose of metafile.
        metaFile2.Dispose()
    End Sub