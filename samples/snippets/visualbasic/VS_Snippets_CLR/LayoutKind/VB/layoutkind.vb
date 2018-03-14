' <Snippet1>
'  The program shows a managed declaration of the PtInRect function and defines Point
'  structure with sequential layout and Rect structure with explicit layout. The PtInRect
'  checks the point lies within the rectangle or not.
Imports System
Imports System.Runtime.InteropServices

   Enum Bool
      [False] = 0
      [True]
   End Enum 
   <StructLayout(LayoutKind.Sequential)>  _
   Public Structure Point
      Public x As Integer
      Public y As Integer
   End Structure 
   
   <StructLayout(LayoutKind.Explicit)>  _   
   Public Structure Rect
      <FieldOffset(0)> Public left As Integer
      <FieldOffset(4)> Public top As Integer
      <FieldOffset(8)> Public right As Integer
      <FieldOffset(12)> Public bottom As Integer
   End Structure 
   
   
   Class LibWrapper
      
      <DllImport("user32.dll", CallingConvention := CallingConvention.StdCall)>  _
      Public Shared Function PtInRect(ByRef r As Rect, p As Point) As Bool
      End Function	
   End Class 'LibWrapper
   
   
   Class TestApplication
      
      Public Shared Sub Main()
         Try
            Dim bPointInRect As Bool = 0
            Dim myRect As New Rect()
            myRect.left = 10
            myRect.right = 100
            myRect.top = 10
            myRect.bottom = 100
            Dim myPoint As New Point()
            myPoint.x = 50
            myPoint.y = 50
            bPointInRect = LibWrapper.PtInRect(myRect, myPoint)
            If bPointInRect = Bool.True Then
               Console.WriteLine("Point lies within the Rect")
            Else
               Console.WriteLine("Point did not lie within the Rect")
            End If
         Catch e As Exception
            Console.WriteLine(("Exception : " + e.Message.ToString()))
         End Try
      End Sub 
   End Class 
' </Snippet1>