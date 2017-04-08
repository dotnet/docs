' <Snippet4>
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports System.Web.DynamicData
Imports System.Text

Partial Public Class DocGetTable
	Inherits System.Web.UI.Page
	 Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	 End Sub

	' Use GetTable methods.
	Public Function GetAdresses(ByVal index As Integer) As String
		' Get the default data model.
		Dim model As MetaModel = MetaModel.Default

		Dim mTable As MetaTable

		Select Case index
			Case 0
				' <Snippet41>
				' Get the metatable for the table with the
				' specified entity type.
				mTable = model.GetTable(GetType(CustomerAddress))
				' </Snippet41>
			Case 1
				' <Snippet42>
				' Get the metatable for the table with the 
				' specified table name.
				mTable = model.GetTable("CustomerAddresses")
				' </Snippet42>
			Case 2
				' <Snippet43>
				' Get the metatable for the table with the 
				' specified table name and the specified data
				' context.
				mTable = model.GetTable("CustomerAddresses", GetType(AdventureWorksLTDataContext))
				' </Snippet43>
			Case Else
				mTable = model.GetTable(GetType(CustomerAddress))
		End Select

		' The following code dislays the actual value 
		' (adress) associated with a customer and link
		' to the related Addresses table.
		Dim fkColumn As MetaForeignKeyColumn = CType(mTable.GetColumn("Address"), MetaForeignKeyColumn)

		Dim row As Customer = CType(GetDataItem(), Customer)


		Dim addressList As New StringBuilder()

		For Each childRow As CustomerAddress In row.CustomerAddresses
			addressList.Append(childRow.AddressType)
			addressList.Append(":<br/>")
			addressList.Append("<a href='")
			addressList.Append(fkColumn.GetForeignKeyDetailsPath(childRow.Address))
			addressList.Append("'>")
			addressList.Append(childRow.Address.AddressLine1)
			addressList.Append("</a><br/><br/>")
		Next childRow

		Return addressList.ToString()

	End Function

End Class
' </Snippet4>