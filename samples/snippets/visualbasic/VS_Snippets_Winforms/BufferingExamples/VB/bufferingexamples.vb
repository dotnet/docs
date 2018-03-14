Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class BufferingExamples
    Inherits Form
    Private appDomainBufferedGraphicsContext As BufferedGraphicsContext
    Private grafx As BufferedGraphics   
    
    Public Sub New()
        '<Snippet1>
        ' Retrieves the BufferedGraphicsContext for the 
        ' current application domain.
        Dim appDomainGraphicsContext As BufferedGraphicsContext = BufferedGraphicsManager.Current
        '</Snippet1>
        
        appDomainGraphicsContext.MaximumBuffer = New Size(400, 400)        
        appDomainBufferedGraphicsContext = BufferedGraphicsManager.Current
        
        '<Snippet2>
        ' Sets the maximum size for the graphics buffer 
        ' of the buffered graphics context. Any allocation 
        ' requests for a buffer larger than this will create 
        ' a temporary buffered graphics context to host 
        ' the graphics buffer.
        appDomainBufferedGraphicsContext.MaximumBuffer = New Size(400, 400)
        '</Snippet2>
        
        '<Snippet3>
        ' Allocates a graphics buffer using the pixel format 
        ' of the specified Graphics object.
        grafx = appDomainBufferedGraphicsContext.Allocate(Me.CreateGraphics(), New Rectangle(0, 0, 400, 400))
        '</Snippet3>
    End Sub   
    
    '<Snippet5>
    Private Sub RenderToGraphics(g As Graphics)
        grafx.Render(g)
    End Sub    
    '</Snippet5>
    
    '<Snippet6>
    Private Sub RenderToDeviceContextHandle(hDC As IntPtr)
        grafx.Render(hDC)
    End Sub    
    '</Snippet6>

    Private Sub AllocateFromHDC()          
        '<Snippet4>
        ' Allocates a graphics buffer using the pixel format 
        ' of the specified handle to device context.
        grafx = appDomainBufferedGraphicsContext.Allocate(Me.Handle, New Rectangle(0, 0, 400, 400))
        '</Snippet4>
    End Sub
    
    <STAThread()>  _
    Public Shared Sub Main(args() As String)
        Application.Run(New BufferingExamples())
    End Sub
    
End Class