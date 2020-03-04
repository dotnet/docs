// <snippet1>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace D3DHost
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set up the initial state for the D3DImage.
            HRESULT.Check(SetSize(512, 512));
            HRESULT.Check(SetAlpha(false));
            HRESULT.Check(SetNumDesiredSamples(4));

            // 
            // Optional: Subscribing to the IsFrontBufferAvailableChanged event.
            //
            // If you don't render every frame (e.g. you only render in 
            // reaction to a button click), you should subscribe to the
            // IsFrontBufferAvailableChanged event to be notified when rendered content 
            // is no longer being displayed. This event also notifies you when 
            // the D3DImage is capable of being displayed again. 
            
            // For example, in the button click case, if you don't render again when 
            // the IsFrontBufferAvailable property is set to true, your 
            // D3DImage won't display anything until the next button click.
            //
            // Because this application renders every frame, there is no need to
            // handle the IsFrontBufferAvailableChanged event.
            // 
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);

            //
            // Optional: Multi-adapter optimization
            //
            // The surface is created initially on a particular adapter.
            // If the WPF window is dragged to another adapter, WPF
            // ensures that the D3DImage still shows up on the new
            // adapter. 
            //
            // This process is slow on Windows XP.
            //
            // Performance is better on Vista with a 9Ex device. It's only 
            // slow when the D3DImage crosses a video-card boundary.
            //
            // To work around this issue, you can move your surface when
            // the D3DImage is displayed on another adapter. To
            // determine when that is the case, transform a point on the
            // D3DImage into screen space and find out which adapter
            // contains that screen space point.
            //
            // When your D3DImage straddles two adapters, nothing  
            // can be done, because one will be updating slowly.
            //
            _adapterTimer = new DispatcherTimer();
            _adapterTimer.Tick += new EventHandler(AdapterTimer_Tick);
            _adapterTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _adapterTimer.Start();

            //
            // Optional: Surface resizing
            //
            // The D3DImage is scaled when WPF renders it at a size 
            // different from the natural size of the surface. If the
            // D3DImage is scaled up significantly, image quality 
            // degrades. 
            // 
            // To avoid this, you can either create a very large
            // texture initially, or you can create new surfaces as
            // the size changes. Below is a very simple example of
            // how to do the latter.
            //
            // By creating a timer at Render priority, you are guaranteed
            // that new surfaces are created while the element
            // is still being arranged. A 200 ms interval gives
            // a good balance between image quality and performance.
            // You must be careful not to create new surfaces too 
            // frequently. Frequently allocating a new surface may 
            // fragment or exhaust video memory. This issue is more 
            // significant on XDDM than it is on WDDM, because WDDM 
            // can page out video memory.
            //
            // Another approach is deriving from the Image class, 
            // participating in layout by overriding the ArrangeOverride method, and
            // updating size in the overriden method. Performance will degrade
            // if you resize too frequently.
            //
            // Blurry D3DImages can still occur due to subpixel 
            // alignments. 
            //
            _sizeTimer = new DispatcherTimer(DispatcherPriority.Render);
            _sizeTimer.Tick += new EventHandler(SizeTimer_Tick);
            _sizeTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            _sizeTimer.Start();
        }

        ~MainWindow()
        {
            Destroy();
        }

        void AdapterTimer_Tick(object sender, EventArgs e)
        {
            POINT p = new POINT(imgelt.PointToScreen(new Point(0, 0)));

            HRESULT.Check(SetAdapter(p));
        }

        void SizeTimer_Tick(object sender, EventArgs e)
        {
            // The following code does not account for RenderTransforms.
            // To handle that case, you must transform up to the root and 
            // check the size there.

            // Given that the D3DImage is at 96.0 DPI, its Width and Height 
            // properties will always be integers. ActualWidth/Height 
            // may not be integers, so they are cast to integers. 
            uint actualWidth = (uint)imgelt.ActualWidth;
            uint actualHeight = (uint)imgelt.ActualHeight;
            if ((actualWidth > 0 && actualHeight > 0) &&
                (actualWidth != (uint)d3dimg.Width || actualHeight != (uint)d3dimg.Height))
            {
                HRESULT.Check(SetSize(actualWidth, actualHeight));
            }
        }

        // <snippet2>
        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            RenderingEventArgs args = (RenderingEventArgs)e;

            // It's possible for Rendering to call back twice in the same frame 
            // so only render when we haven't already rendered in this frame.
            if (d3dimg.IsFrontBufferAvailable && _lastRender != args.RenderingTime)
            {
                IntPtr pSurface = IntPtr.Zero;
                HRESULT.Check(GetBackBufferNoRef(out pSurface));
                if (pSurface != IntPtr.Zero)
                {
                    // <snippet3>
                    d3dimg.Lock();
                    // Repeatedly calling SetBackBuffer with the same IntPtr is 
                    // a no-op. There is no performance penalty.
                    d3dimg.SetBackBuffer(D3DResourceType.IDirect3DSurface9, pSurface);
                    HRESULT.Check(Render());
                    d3dimg.AddDirtyRect(new Int32Rect(0, 0, d3dimg.PixelWidth, d3dimg.PixelHeight));
                    d3dimg.Unlock();
                    // </snippet3>

                    _lastRender = args.RenderingTime;
                }
            }
        }
        // </snippet2>

        DispatcherTimer _sizeTimer;
        DispatcherTimer _adapterTimer;
        TimeSpan _lastRender;

        // Import the methods exported by the unmanaged Direct3D content.

        [DllImport("D3DCode.dll")]
        static extern int GetBackBufferNoRef(out IntPtr pSurface);

        [DllImport("D3DCode.dll")]
        static extern int SetSize(uint width, uint height);

        [DllImport("D3DCode.dll")]
        static extern int SetAlpha(bool useAlpha);

        [DllImport("D3DCode.dll")]
        static extern int SetNumDesiredSamples(uint numSamples);

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public POINT(Point p)
            {
                x = (int)p.X;
                y = (int)p.Y;
            }

            public int x;
            public int y;
        }

        [DllImport("D3DCode.dll")]
        static extern int SetAdapter(POINT screenSpacePoint);

        [DllImport("D3DCode.dll")]
        static extern int Render();

        [DllImport("D3DCode.dll")]
        static extern void Destroy();
    }

    public static class HRESULT
    {
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void Check(int hr)
        {
            Marshal.ThrowExceptionForHR(hr);
        }
    }
}
// </snippet1>