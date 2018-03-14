 ' <snippet1>
Imports System
Imports System.Web
Imports System.Xml
Imports System.IO
Imports System.Data
Imports System.Web.Caching

Namespace Samples.AspNet.VB

   ' Create a class with static methods.
    Public Class DataHelper   
' <snippet2> 
        ' Create a method that supplied book data
        ' to pages.
        Public Shared Function GetBookData() As DataView
            Dim ctxtCurrent As HttpContext = HttpContext.Current
      
            ' Check for the DataView in the application cache.            
            Dim [Source] As DataView = _
              CType(ctxtCurrent.Cache("bookData"), DataView)
            
            ' If not in the cache, lock this object and
            ' check to see if another request put it in.            
            If [Source] Is Nothing Then
                  
                Dim ds As New DataSet()        
                Dim fs As New FileStream( _
                  ctxtCurrent.Server.MapPath("books.xml"), _
                  FileMode.Open, FileAccess.Read)

                Try
                    Dim reader As New StreamReader(fs)
                    ds.ReadXml(reader)
                Finally
                    fs.Close()
                End Try
         
                [Source] = New DataView(ds.Tables(0))
         
                ' Create a dependency on an XML data source
                ' and put the DataView into the cache with a
                ' dependency and 15 second expiration policy.
                Dim depBooks As New CacheDependency( _
                  ctxtCurrent.Server.MapPath("books.xml"))
                ctxtCurrent.Cache.Insert( _
                  "bookData", [Source], depBooks, _
                   DateTime.Now.AddSeconds(15), TimeSpan.Zero)

            End If
                
            Return [Source]

        End Function 'GetBookData
' </snippet2>    
   
        ' Create a method that supplies author data
        ' to pages.
        Public Shared Function GetAuthorData() As DataView
            Dim ctxt As HttpContext = HttpContext.Current
      
            ' Check for the DataView in the application cache.
            Dim [Source] As DataView = _
              CType(ctxt.Cache("authorData"), DataView)
      
            ' If not in the cache, lock this object and
            ' check to see if another request put it in.
            If [Source] Is Nothing Then
         
                Dim ds As New DataSet()
                Dim fs As New FileStream( _
                  ctxt.Server.MapPath("authors.xml"), _
                  FileMode.Open, FileAccess.Read)
         
                Try
                    Dim reader As New StreamReader(fs)
                    ds.ReadXml(reader)
                Finally
                    fs.Close()
                End Try
         
                [Source] = New DataView(ds.Tables(0))
         
                ' Create a file dependency and add the
                ' DataView to the cache. 
                Dim depAuthors As New CacheDependency( _
                  ctxt.Server.MapPath("authors.xml"))
                ctxt.Cache.Insert("authorData", [Source], depAuthors)         
            End If
                
            Return [Source]

        End Function 
    End Class 
End Namespace

' </snippet1>
