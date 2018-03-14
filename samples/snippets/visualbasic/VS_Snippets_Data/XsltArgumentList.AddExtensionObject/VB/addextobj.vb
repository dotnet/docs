'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl

Public Class Sample
        
    Public Shared Sub Main() 
        
        ' Create the XslCompiledTransform and load the stylesheet.
        Dim xslt As New XslCompiledTransform()
        xslt.Load("prices.xsl")
        
        ' Create an XsltArgumentList.
        Dim xslArg As New XsltArgumentList()
        
        ' Add an object to calculate the new book price.
        Dim obj As New BookPrice()
        xslArg.AddExtensionObject("urn:price-conv", obj)
        
        
        Using w As XmlWriter = XmlWriter.Create("output.xml")
            ' Transform the file.
            xslt.Transform("books.xml", xslArg, w)
        End Using


    
    End Sub 'Main 
    
    ' Convert the book price to a new price using the conversion factor.    
    Public Class BookPrice
        
        Private newprice As Decimal = 0
                
        Public Function NewPriceFunc(ByVal price As Decimal, ByVal conv As Decimal) As Decimal 
            Dim tmp As Decimal = price * conv
            newprice = Decimal.Round(tmp, 2)
            Return newprice        
        End Function 'NewPriceFunc

    End Class 'BookPrice

End Class 'Sample
'</snippet1>