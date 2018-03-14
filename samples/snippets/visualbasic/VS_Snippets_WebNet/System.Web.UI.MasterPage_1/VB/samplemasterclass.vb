' <snippet3>
Class SampleMasterClass
         Inherits System.Web.UI.MasterPage
     Dim asitename As String
     Public Property SiteName() As String
       Get
         Return asitename
       End Get
       Set(ByVal Value as String)
         asitename = Value
       End Set
     End Property
End Class
' </snippet3>