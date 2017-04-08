Imports System
Imports System.Windows
Imports System.Security.Permissions

Namespace WindowsApplication1
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		' Audio permission code attributes.

		' <SnippetMediaPermissionAttribute1>
        <MediaPermissionAttribute(SecurityAction.Demand, Audio:=MediaPermissionAudio.AllAudio)>
        Public Sub Method01()
        End Sub
        ' </SnippetMediaPermissionAttribute1>

		' <SnippetMediaPermissionAttribute2>
		<MediaPermissionAttribute(SecurityAction.Demand, Audio := MediaPermissionAudio.NoAudio)>
        Public Sub Method02()
        End Sub
        ' </SnippetMediaPermissionAttribute2>

		' <SnippetMediaPermissionAttribute3>
		<MediaPermissionAttribute(SecurityAction.Demand, Audio := MediaPermissionAudio.SafeAudio)>
        Public Sub Method03()
        End Sub
        ' </SnippetMediaPermissionAttribute3>


        ' <SnippetMediaPermissionAttribute4>
        <MediaPermissionAttribute(SecurityAction.Demand, Audio:=MediaPermissionAudio.SiteOfOriginAudio)>
        Public Sub Method04()
        End Sub
        ' </SnippetMediaPermissionAttribute4>


        <MediaPermissionAttribute(SecurityAction.Demand, Audio:=MediaPermissionAudio.SiteOfOriginAudio)>
        Public Sub Method041()

            ' <SnippetMediaPermission1>
            Dim mediaPermission As New MediaPermission(MediaPermissionAudio.SiteOfOriginAudio)
            ' </SnippetMediaPermission1>

            ' <SnippetMediaPermission6>
            Dim mediaPermissionAudio6 As MediaPermissionAudio = mediaPermission.Audio
            ' </SnippetMediaPermission6>

        End Sub


        ' Image permission code attributes.

        ' <SnippetMediaPermissionAttribute5>
        <MediaPermissionAttribute(SecurityAction.Demand, Image:=MediaPermissionImage.AllImage)>
        Public Sub Method05()
        End Sub
        ' </SnippetMediaPermissionAttribute5>

        ' <SnippetMediaPermissionAttribute6>
        <MediaPermissionAttribute(SecurityAction.Demand, Image:=MediaPermissionImage.NoImage)>
        Public Sub Method06()
        End Sub
        ' </SnippetMediaPermissionAttribute6>



        <MediaPermissionAttribute(SecurityAction.Demand, Image:=MediaPermissionImage.NoImage)>
        Public Sub Method06a()

            ' <SnippetMediaPermission2>
            Dim mediaPermission As New MediaPermission(MediaPermissionImage.NoImage)
            ' </SnippetMediaPermission2>

            ' <SnippetMediaPermission7>
            Dim mediaPermissionImage7 As MediaPermissionImage = mediaPermission.Image
            ' </SnippetMediaPermission7>

        End Sub


        ' <SnippetMediaPermissionAttribute7>
        <MediaPermissionAttribute(SecurityAction.Demand, Image:=MediaPermissionImage.SafeImage)>
        Public Sub Method07()
        End Sub
        ' </SnippetMediaPermissionAttribute7>

        ' <SnippetMediaPermissionAttribute8>
        <MediaPermissionAttribute(SecurityAction.Demand, Image:=MediaPermissionImage.SiteOfOriginImage)>
        Public Sub Method08()
        End Sub
        ' </SnippetMediaPermissionAttribute8>

        ' Video permission code attributes.

        ' <SnippetMediaPermissionAttribute9>
        <MediaPermissionAttribute(SecurityAction.Demand, Video:=MediaPermissionVideo.AllVideo)>
        Public Sub Method09()
        End Sub
        ' </SnippetMediaPermissionAttribute9>


        <MediaPermissionAttribute(SecurityAction.Demand, Video:=MediaPermissionVideo.AllVideo)>
        Public Sub Stub091()

            ' <SnippetMediaPermission3>
            Dim mediaPermission As New MediaPermission(MediaPermissionVideo.AllVideo)
            ' </SnippetMediaPermission3>

            ' <SnippetMediaPermission8>
            Dim mediaPermissionVideo8 As MediaPermissionVideo = mediaPermission.Video
            ' </SnippetMediaPermission8>
        End Sub

        ' <SnippetMediaPermissionAttribute10>
        <MediaPermissionAttribute(SecurityAction.Demand, Video:=MediaPermissionVideo.NoVideo)>
        Public Sub Method10()
        End Sub
        ' </SnippetMediaPermissionAttribute10>

        ' <SnippetMediaPermissionAttribute11>
        <MediaPermissionAttribute(SecurityAction.Demand, Video:=MediaPermissionVideo.SafeVideo)>
        Public Sub Method11()
        End Sub
        ' </SnippetMediaPermissionAttribute11>

        ' <SnippetMediaPermissionAttribute12>
        <MediaPermissionAttribute(SecurityAction.Demand, Video:=MediaPermissionVideo.SiteOfOriginVideo)>
        Public Sub Method12()
        End Sub
        ' </SnippetMediaPermissionAttribute12>

        ' <SnippetMediaPermissionAttribute13>
        <MediaPermissionAttribute(SecurityAction.Demand)>
        Public Sub Method12a()
            Dim mpa As New MediaPermissionAttribute(SecurityAction.Demand)
        End Sub
        ' </SnippetMediaPermissionAttribute13>

        Public Sub Stub13()
            ' <SnippetMediaPermission4>
            ' Provide full access to the resource protected by the permission.
            Dim mediaPermission As New MediaPermission(PermissionState.Unrestricted)
            ' </SnippetMediaPermission4>
        End Sub

        Public Sub Stub14()
            ' <SnippetMediaPermission5>
            ' Provide full access to the resource protected by the permission.
            Dim mediaPermission As New MediaPermission(MediaPermissionAudio.SiteOfOriginAudio, MediaPermissionVideo.SiteOfOriginVideo, MediaPermissionImage.SiteOfOriginImage)
            ' </SnippetMediaPermission5>

        End Sub

        Public Sub Stub15()
            Dim mediaPermission As New MediaPermission(MediaPermissionAudio.AllAudio, MediaPermissionVideo.AllVideo, MediaPermissionImage.AllImage)

            ' <SnippetMediaPermission16>
            Dim isUnrestricted As Boolean = mediaPermission.IsUnrestricted()
            ' </SnippetMediaPermission16>
        End Sub
    End Class
End Namespace