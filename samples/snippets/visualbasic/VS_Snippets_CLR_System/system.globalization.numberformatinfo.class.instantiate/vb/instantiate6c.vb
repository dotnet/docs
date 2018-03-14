' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Reflection

Module Example
   Public Sub Main()
      ' Get all the neutral cultures
      Dim names As New List(Of String)
      Array.ForEach(CultureInfo.GetCultures(CultureTypes.NeutralCultures),
                    Sub(culture) names.Add(culture.Name))
      names.Sort()
      For Each name In names
         ' Ignore the invariant culture.
         If name = "" Then Continue For
         
         ListSimilarChildCultures(name)        
      Next
   End Sub

   Private Sub ListSimilarChildCultures(name As String)
      ' Create the neutral NumberFormatInfo object.
      Dim nfi As NumberFormatInfo = CultureInfo.GetCultureInfo(name).NumberFormat
      ' Retrieve all specific cultures of the neutral culture.
      Dim cultures() As CultureInfo = Array.FindAll(CultureInfo.GetCultures(CultureTypes.SpecificCultures), 
                               Function(culture) culture.Name.StartsWith(name + "-", StringComparison.OrdinalIgnoreCase))
      ' Create an array of NumberFormatInfo properties
      Dim properties() As PropertyInfo = GetType(NumberFormatInfo).GetProperties(BindingFlags.Instance Or BindingFlags.Public)
      Dim hasOneMatch As Boolean = False

      For Each ci In cultures
         Dim match As Boolean = True     
         ' Get the NumberFormatInfo for a specific culture.
         Dim specificNfi As NumberFormatInfo = ci.NumberFormat
         ' Compare the property values of the two.
         For Each prop In properties
            ' We're not interested in the value of IsReadOnly.     
            If prop.Name = "IsReadOnly" Then Continue For
            
            ' For arrays, iterate the individual elements to see if they are the same.
            If prop.PropertyType.IsArray Then 
               Dim nList As IList = CType(prop.GetValue(nfi, Nothing), IList)
               Dim sList As IList = CType(prop.GetValue(specificNfi, Nothing), IList)
               If nList.Count <> sList.Count Then
                  match = false
                  Exit For
               End If 

               For ctr As Integer = 0 To nList.Count - 1
                  If Not nList(ctr).Equals(sList(ctr)) 
                     match = false
                     Exit For
                  End If     
               Next
            Else If Not prop.GetValue(specificNfi).Equals(prop.GetValue(nfi))
               match = false
               Exit For   
            End If        
         Next
         If match Then
            Console.WriteLine("NumberFormatInfo object for '{0}' matches '{1}'", 
                                      name, ci.Name)
            hasOneMatch = true
         End If                                       
      Next
      If Not hasOneMatch Then
         Console.WriteLine("NumberFormatInfo object for '{0}' --> No Match", name)            
      End If
      
      Console.WriteLine()
   End Sub
End Module
' </Snippet6>
