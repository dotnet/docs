Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomADRotatorRender
        Inherits System.Web.UI.WebControls.AdRotator

        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
            Dim navigateUrl As String = System.String.Empty
            Dim imageUrl As String = System.String.Empty
            Dim alternateText As String = System.String.Empty

            ' If the value for the Advertisement File is not empty.
            If Me.AdvertisementFile.Length > 0 Then
                ' Get a random ad.
                GetRandomAd(imageUrl, navigateUrl, alternateText)
            End If

            ' Create and render a new HyperLink Web control.
            Dim bannerLink As New System.Web.UI.WebControls.HyperLink
            Dim key As String
            For Each key In Me.Attributes.Keys
                bannerLink.Attributes(key) = Me.Attributes(key)
            Next key
            If Not (Me.ID Is Nothing) AndAlso Me.ID.Length > 0 Then
                bannerLink.ID = Me.ClientID
            End If
            bannerLink.NavigateUrl = navigateUrl
            bannerLink.Target = Me.Target
            bannerLink.AccessKey = Me.AccessKey
            bannerLink.Enabled = Me.Enabled
            bannerLink.TabIndex = Me.TabIndex
            bannerLink.RenderBeginTag(writer)

            ' Create and render a new Image Web control.
            Dim bannerImage As New System.Web.UI.WebControls.Image
            If ControlStyleCreated Then
                bannerImage.ApplyStyle(Me.ControlStyle)
            End If
            bannerImage.AlternateText = alternateText
            bannerImage.ImageUrl = imageUrl
            bannerImage.ToolTip = Me.ToolTip
            bannerImage.RenderControl(writer)
            bannerLink.RenderEndTag(writer)
        End Sub

        Private Sub GetRandomAd(ByRef imageUrl As String, ByRef navigateUrl As String, ByRef alternateText As String)
            ' Default output parameters values to empty string
            imageUrl = System.String.Empty
            navigateUrl = System.String.Empty
            alternateText = System.String.Empty

            ' Get the Ads from an XML file.
            Dim dataSet As New System.Data.DataSet
            Dim physicalPath As String = MapPathSecure(Me.AdvertisementFile)
            dataSet.ReadXml(physicalPath, System.Data.XmlReadMode.InferSchema)

            ' If Ads were found in the XML File.
            Dim totalAds As Integer = dataSet.Tables(0).Rows.Count
            If totalAds > 0 Then

                ' Select a random Ad.
                Dim randomNumber As New System.Random
                Dim selectedAdIndex As Integer = randomNumber.Next(totalAds)

                ' Output the random Ad's values.
                imageUrl = dataSet.Tables(0).Rows(selectedAdIndex).ItemArray(0).ToString()
                navigateUrl = dataSet.Tables(0).Rows(selectedAdIndex).ItemArray(1).ToString()
                alternateText = dataSet.Tables(0).Rows(selectedAdIndex).ItemArray(2).ToString()
            End If
        End Sub
    End Class
    ' </Snippet2>
End Namespace ' Samples.AspNet