using System;
using System.Windows;
using System.Security.Permissions;

namespace WindowsApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        // Audio permission code attributes.

        // <SnippetMediaPermissionAttribute1>
        [MediaPermissionAttribute(SecurityAction.Demand, Audio = MediaPermissionAudio.AllAudio)]
        // </SnippetMediaPermissionAttribute1>
        public void Stub01() { }

        // <SnippetMediaPermissionAttribute2>
        [MediaPermissionAttribute(SecurityAction.Demand, Audio = MediaPermissionAudio.NoAudio)]
        // </SnippetMediaPermissionAttribute2>
        public void Stub02() { }

        // <SnippetMediaPermissionAttribute3>
        [MediaPermissionAttribute(SecurityAction.Demand, Audio = MediaPermissionAudio.SafeAudio)]
        // </SnippetMediaPermissionAttribute3>
        public void Stub03() { }

        // <SnippetMediaPermissionAttribute4>
        [MediaPermissionAttribute(SecurityAction.Demand, Audio = MediaPermissionAudio.SiteOfOriginAudio)]
        // </SnippetMediaPermissionAttribute4>
        public void Stub04()
        {
            // <SnippetMediaPermission1>
            MediaPermission mediaPermission = new MediaPermission(MediaPermissionAudio.SiteOfOriginAudio);
            // </SnippetMediaPermission1>

            // <SnippetMediaPermission6>
            MediaPermissionAudio mediaPermissionAudio = mediaPermission.Audio;
            // </SnippetMediaPermission6>
        }

        // Image permission code attributes.

        // <SnippetMediaPermissionAttribute5>
        [MediaPermissionAttribute(SecurityAction.Demand, Image = MediaPermissionImage.AllImage)]
        // </SnippetMediaPermissionAttribute5>
        public void Stub05() { }

        // <SnippetMediaPermissionAttribute6>
        [MediaPermissionAttribute(SecurityAction.Demand, Image = MediaPermissionImage.NoImage)]
        // </SnippetMediaPermissionAttribute6>
        public void Stub06()
        {
            // <SnippetMediaPermission2>
            MediaPermission mediaPermission = new MediaPermission(MediaPermissionImage.NoImage);
            // </SnippetMediaPermission2>

            // <SnippetMediaPermission7>
            MediaPermissionImage mediaPermissionImage = mediaPermission.Image;
            // </SnippetMediaPermission7>
        }

        // <SnippetMediaPermissionAttribute7>
        [MediaPermissionAttribute(SecurityAction.Demand, Image = MediaPermissionImage.SafeImage)]
        // </SnippetMediaPermissionAttribute7>
        public void Stub07() { }

        // <SnippetMediaPermissionAttribute8>
        [MediaPermissionAttribute(SecurityAction.Demand, Image = MediaPermissionImage.SiteOfOriginImage)]
        // </SnippetMediaPermissionAttribute8>
        public void Stub08() { }

        // Video permission code attributes.

        // <SnippetMediaPermissionAttribute9>
        [MediaPermissionAttribute(SecurityAction.Demand, Video = MediaPermissionVideo.AllVideo)]
        // </SnippetMediaPermissionAttribute9>
        public void Stub09()
        {
            // <SnippetMediaPermission3>
            MediaPermission mediaPermission = new MediaPermission(MediaPermissionVideo.AllVideo);
            // </SnippetMediaPermission3>

            // <SnippetMediaPermission8>
            MediaPermissionVideo mediaPermissionVideo = mediaPermission.Video;
            // </SnippetMediaPermission8>
        }

        // <SnippetMediaPermissionAttribute10>
        [MediaPermissionAttribute(SecurityAction.Demand, Video = MediaPermissionVideo.NoVideo)]
        // </SnippetMediaPermissionAttribute10>
        public void Stub10() { }

        // <SnippetMediaPermissionAttribute11>
        [MediaPermissionAttribute(SecurityAction.Demand, Video = MediaPermissionVideo.SafeVideo)]
        // </SnippetMediaPermissionAttribute11>
        public void Stub11() { }

        // <SnippetMediaPermissionAttribute12>
        [MediaPermissionAttribute(SecurityAction.Demand, Video = MediaPermissionVideo.SiteOfOriginVideo)]
        // </SnippetMediaPermissionAttribute12>
        public void Stub12() { }

        // <SnippetMediaPermissionAttribute13>
        [MediaPermissionAttribute(SecurityAction.Demand)]
        // </SnippetMediaPermissionAttribute13>
        public void Stub12a()
        {
            MediaPermissionAttribute mpa = new MediaPermissionAttribute(SecurityAction.Demand);
        }

        public void Stub13()
        {
            // <SnippetMediaPermission4>
            // Provide full access to the resource protected by the permission.
            MediaPermission mediaPermission = new MediaPermission(PermissionState.Unrestricted);
            // </SnippetMediaPermission4>
        }

        public void Stub14()
        {
            // <SnippetMediaPermission5>
            // Provide full access to the resource protected by the permission.
            MediaPermission mediaPermission = new MediaPermission(
                MediaPermissionAudio.SiteOfOriginAudio,
                MediaPermissionVideo.SiteOfOriginVideo,
                MediaPermissionImage.SiteOfOriginImage);
            // </SnippetMediaPermission5>

        }

        public void Stub15()
        {
            MediaPermission mediaPermission = new MediaPermission(
                MediaPermissionAudio.AllAudio,
                MediaPermissionVideo.AllVideo,
                MediaPermissionImage.AllImage);

            // <SnippetMediaPermission16>
            bool isUnrestricted = mediaPermission.IsUnrestricted();
            // </SnippetMediaPermission16>
        }
    }
}