Imports System

Namespace Snippets
   '<snippet1>
   Public Structure Complex
      Private m_Re As Double
      Private m_Im As Double
          
      Public Overloads Function Equals(ob As Object) As Boolean
         If TypeOf ob Is Complex Then
            Dim c As Complex = CType(ob, Complex)
            Return m_Re = c.m_Re And m_Im = c.m_Im
         Else
            Return False
         End If
      End Function
      
      
      Public Overloads Function GetHashCode() As Integer
         Return m_Re.GetHashCode() ^ m_Im.GetHashCode()
      End Function

   End Structure
   '</snippet1>
End Namespace 