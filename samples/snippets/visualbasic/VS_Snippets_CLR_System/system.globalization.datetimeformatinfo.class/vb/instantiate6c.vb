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
      ' Create the neutral DateTimeFormatInfo object.
      Dim dtfi As DateTimeFormatInfo = CultureInfo.GetCultureInfo(name).DateTimeFormat
      ' Retrieve all specific cultures of the neutral culture.
      Dim cultures() As CultureInfo = Array.FindAll(CultureInfo.GetCultures(CultureTypes.SpecificCultures), 
                               Function(culture) culture.Name.StartsWith(name + "-", StringComparison.OrdinalIgnoreCase))
      ' Create an array of DateTimeFormatInfo properties
      Dim properties() As PropertyInfo = GetType(DateTimeFormatInfo).GetProperties(BindingFlags.Instance Or BindingFlags.Public)
      Dim hasOneMatch As Boolean = False

      For Each ci In cultures
         Dim match As Boolean = True     
         ' Get the DateTimeFormatInfo for a specific culture.
         Dim specificDtfi As DateTimeFormatInfo = ci.DateTimeFormat
         ' Compare the property values of the two.
         For Each prop In properties
            ' We're not interested in the value of IsReadOnly.     
            If prop.Name = "IsReadOnly" Then Continue For
            
            ' For arrays, iterate the individual elements to see if they are the same.
            If prop.PropertyType.IsArray Then 
               Dim nList As IList = CType(prop.GetValue(dtfi, Nothing), IList)
               Dim sList As IList = CType(prop.GetValue(specificDtfi, Nothing), IList)
               If nList.Count <> sList.Count Then
                  match = false
Console.WriteLine("   Different n in {2} array for {0} and {1}", name, ci.Name, prop.Name)
                  Exit For
               End If 

               For ctr As Integer = 0 To nList.Count - 1
                  If Not nList(ctr).Equals(sList(ctr)) 
                     match = false
Console.WriteLine("   {0} value different for {1} and {2}", prop.Name, name, ci.Name)                     
                     Exit For
                  End If     
               Next
               
               If Not match Then Exit For
            ' Get non-array values.
            Else
               Dim specificValue As Object = prop.GetValue(specificDtfi)
               Dim neutralValue As Object = prop.GetValue(dtfi)
                               
               ' Handle comparison of Calendar objects.
               If prop.Name = "Calendar" Then 
                  ' The cultures have a different calendar type.
                  If specificValue.ToString() <> neutralValue.ToString() Then
Console.WriteLine("   Different calendar types for {0} and {1}", name, ci.Name)
                     match = False
                     Exit For
                  End If
                   
                  If TypeOf specificValue Is GregorianCalendar Then
                     If CType(specificValue, GregorianCalendar).CalendarType <> CType(neutralValue, GregorianCalendar).CalendarType Then
Console.WriteLine("   Different Gregorian calendar types for {0} and {1}", name, ci.Name)
                        match = False
                        Exit For
                     End If
                  End If
               Else If Not specificValue.Equals(neutralValue) Then
                  match = false
Console.WriteLine("   Different {0} values for {1} and {2}", prop.Name, name, ci.Name)                  
                  Exit For   
               End If
            End If        
         Next
         If match Then
            Console.WriteLine("DateTimeFormatInfo object for '{0}' matches '{1}'", 
                                      name, ci.Name)
            hasOneMatch = True
         End If                                       
      Next
      If Not hasOneMatch Then
         Console.WriteLine("DateTimeFormatInfo object for '{0}' --> No Match", name)            
      End If
      
      Console.WriteLine()
   End Sub
End Module
' </Snippet6>
