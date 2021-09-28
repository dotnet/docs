// <snippetRendererManagerCPP>

//+-----------------------------------------------------------------------------
//
//  CRendererManager
//
//      Manages the list of CRenderers. Managed code pinvokes into this class
//      and this class forwards to the appropriate CRenderer.
//
//------------------------------------------------------------------------------

#include "StdAfx.h"

const static TCHAR szAppName[] = TEXT("D3DImageSample");
typedef HRESULT (WINAPI *DIRECT3DCREATE9EXFUNCTION)(UINT SDKVersion, IDirect3D9Ex**);

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager ctor
//
//------------------------------------------------------------------------------
CRendererManager::CRendererManager() 
    : 
    m_pD3D(NULL),
    m_pD3DEx(NULL),
    m_cAdapters(0),
    m_hwnd(NULL),
    m_pCurrentRenderer(NULL),
    m_rgRenderers(NULL),
    m_uWidth(1024),
    m_uHeight(1024),
    m_uNumSamples(0),
    m_fUseAlpha(false),
    m_fSurfaceSettingsChanged(true)
{

}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager dtor
//
//------------------------------------------------------------------------------
CRendererManager::~CRendererManager()
{
    DestroyResources();

    if (m_hwnd)
    {
        DestroyWindow(m_hwnd);
        UnregisterClass(szAppName, NULL);
    }
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::Create
//
//  Synopsis:
//      Creates the manager
//
//------------------------------------------------------------------------------
HRESULT
CRendererManager::Create(CRendererManager **ppManager)
{
    HRESULT hr = S_OK;

    *ppManager = new CRendererManager();
    IFCOOM(*ppManager);

Cleanup:
    return hr;
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::EnsureRenderers
//
//  Synopsis:
//      Makes sure the CRenderer objects exist
//
//------------------------------------------------------------------------------
HRESULT
CRendererManager::EnsureRenderers()
{
    HRESULT hr = S_OK;

    if (!m_rgRenderers)
    {
        IFC(EnsureHWND());

        assert(m_cAdapters);    
        m_rgRenderers = new CRenderer*[m_cAdapters];
        IFCOOM(m_rgRenderers);
        ZeroMemory(m_rgRenderers, m_cAdapters * sizeof(m_rgRenderers[0]));

        for (UINT i = 0; i < m_cAdapters; ++i)
        {
            IFC(CTriangleRenderer::Create(m_pD3D, m_pD3DEx, m_hwnd, i, &m_rgRenderers[i]));
        }

        // Default to the default adapter 
        m_pCurrentRenderer = m_rgRenderers[0];
    }

Cleanup:
    return hr;
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::EnsureHWND
//
//  Synopsis:
//      Makes sure an HWND exists if we need it
//
//------------------------------------------------------------------------------
// <snippetRendererManager_EnsureHWND>
HRESULT
CRendererManager::EnsureHWND()
{
    HRESULT hr = S_OK;

    if (!m_hwnd)
    {
        WNDCLASS wndclass;

        wndclass.style = CS_HREDRAW | CS_VREDRAW;
        wndclass.lpfnWndProc = DefWindowProc;
        wndclass.cbClsExtra = 0;
        wndclass.cbWndExtra = 0;
        wndclass.hInstance = NULL;
        wndclass.hIcon = LoadIcon(NULL, IDI_APPLICATION);
        wndclass.hCursor = LoadCursor(NULL, IDC_ARROW);
        wndclass.hbrBackground = (HBRUSH) GetStockObject (WHITE_BRUSH);
        wndclass.lpszMenuName = NULL;
        wndclass.lpszClassName = szAppName;

        if (!RegisterClass(&wndclass))
        {
            IFC(E_FAIL);
        }

        m_hwnd = CreateWindow(szAppName,
                            TEXT("D3DImageSample"),
                            WS_OVERLAPPEDWINDOW,
                            0,                   // Initial X
                            0,                   // Initial Y
                            0,                   // Width
                            0,                   // Height
                            NULL,
                            NULL,
                            NULL,
                            NULL);
    }

Cleanup:
    return hr;
}
// </snippetRendererManager_EnsureHWND>

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::EnsureD3DObjects
//
//  Synopsis:
//      Makes sure the D3D objects exist
//
//------------------------------------------------------------------------------
// <snippetRendererManager_EnsureD3DObjects>
HRESULT
CRendererManager::EnsureD3DObjects()
{
    HRESULT hr = S_OK;

    HMODULE hD3D = NULL;
    if (!m_pD3D)
    {
        hD3D = LoadLibrary(TEXT("d3d9.dll"));
        DIRECT3DCREATE9EXFUNCTION pfnCreate9Ex = (DIRECT3DCREATE9EXFUNCTION)GetProcAddress(hD3D, "Direct3DCreate9Ex");
        if (pfnCreate9Ex)
        {
            IFC((*pfnCreate9Ex)(D3D_SDK_VERSION, &m_pD3DEx));
            IFC(m_pD3DEx->QueryInterface(__uuidof(IDirect3D9), reinterpret_cast<void **>(&m_pD3D)));
        }
        else
        {
            m_pD3D = Direct3DCreate9(D3D_SDK_VERSION);
            if (!m_pD3D) 
            {
                IFC(E_FAIL);
            }
        }

        m_cAdapters = m_pD3D->GetAdapterCount();
    }

Cleanup:
    if (hD3D)
    {
        FreeLibrary(hD3D);
    }

    return hr;
}
// </snippetRendererManager_EnsureD3DObjects>

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::CleanupInvalidDevices
//
//  Synopsis:
//      Checks to see if any devices are bad and if so, deletes all resources
//
//      We could delete resources and wait for D3DERR_DEVICENOTRESET and reset
//      the devices, but if the device is lost because of an adapter order 
//      change then our existing D3D objects would have stale adapter 
//      information. We'll delete everything to be safe rather than sorry.
//
//------------------------------------------------------------------------------
void
CRendererManager::CleanupInvalidDevices()
{
    for (UINT i = 0; i < m_cAdapters; ++i)
    {
        if (FAILED(m_rgRenderers[i]->CheckDeviceState()))
        {
            DestroyResources();
            break;
        }
    }
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::GetBackBufferNoRef
//
//  Synopsis:
//      Returns the surface of the current renderer without adding a reference
//
//      This can return NULL if we're in a bad device state.
//
//------------------------------------------------------------------------------
HRESULT 
CRendererManager::GetBackBufferNoRef(IDirect3DSurface9 **ppSurface)
{
    HRESULT hr = S_OK;

    // Make sure we at least return NULL
    *ppSurface = NULL;

    CleanupInvalidDevices();

    IFC(EnsureD3DObjects());

    //
    // Even if we never render to another adapter, this sample creates devices
    // and resources on each one. This is a potential waste of video memory,
    // but it guarantees that we won't have any problems (e.g. out of video
    // memory) when switching to render on another adapter. In your own code
    // you may choose to delay creation but you'll need to handle the issues
    // that come with it.
    //

    IFC(EnsureRenderers());

    if (m_fSurfaceSettingsChanged)
    {
        if (FAILED(TestSurfaceSettings()))
        {
            IFC(E_FAIL);
        }

        for (UINT i = 0; i < m_cAdapters; ++i)
        {
            IFC(m_rgRenderers[i]->CreateSurface(m_uWidth, m_uHeight, m_fUseAlpha, m_uNumSamples));
        }

        m_fSurfaceSettingsChanged = false;
    }

    if (m_pCurrentRenderer)
    {
        *ppSurface = m_pCurrentRenderer->GetSurfaceNoRef();
    }

Cleanup:
    // If we failed because of a bad device, ignore the failure for now and 
    // we'll clean up and try again next time.
    if (hr == D3DERR_DEVICELOST)
    {
        hr = S_OK;
    }

    return hr;
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::TestSurfaceSettings
//
//  Synopsis:
//      Checks to see if our current surface settings are allowed on all
//      adapters.
//
//------------------------------------------------------------------------------
// <snippetRendererManager_TestSurfaceSettings>
HRESULT
CRendererManager::TestSurfaceSettings()
{
    HRESULT hr = S_OK;

    D3DFORMAT fmt = m_fUseAlpha ? D3DFMT_A8R8G8B8 : D3DFMT_X8R8G8B8;

    // 
    // We test all adapters because because we potentially use all adapters.
    // But even if this sample only rendered to the default adapter, you
    // should check all adapters because WPF may move your surface to
    // another adapter for you!
    //

    for (UINT i = 0; i < m_cAdapters; ++i)
    {
        // Can we get HW rendering?
        IFC(m_pD3D->CheckDeviceType(
            i,
            D3DDEVTYPE_HAL,
            D3DFMT_X8R8G8B8,
            fmt,
            TRUE
            )); 

        // Is the format okay?
        IFC(m_pD3D->CheckDeviceFormat(
            i,
            D3DDEVTYPE_HAL,
            D3DFMT_X8R8G8B8,
            D3DUSAGE_RENDERTARGET | D3DUSAGE_DYNAMIC, // We'll use dynamic when on XP
            D3DRTYPE_SURFACE,
            fmt
            ));

        // D3DImage only allows multisampling on 9Ex devices. If we can't 
        // multisample, overwrite the desired number of samples with 0.
        if (m_pD3DEx && m_uNumSamples > 1)
        {   
            assert(m_uNumSamples <= 16);

            if (FAILED(m_pD3D->CheckDeviceMultiSampleType(
                i,
                D3DDEVTYPE_HAL,
                fmt,
                TRUE,
                static_cast<D3DMULTISAMPLE_TYPE>(m_uNumSamples),
                NULL
                )))
            {
                m_uNumSamples = 0;
            }
        }
        else
        {
            m_uNumSamples = 0;
        }
    }

Cleanup:
    return hr;
}
// </snippetRendererManager_TestSurfaceSettings>

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::DestroyResources
//
//  Synopsis:
//      Delete all D3D resources
//
//------------------------------------------------------------------------------
void 
CRendererManager::DestroyResources()
{
    SAFE_RELEASE(m_pD3D);
    SAFE_RELEASE(m_pD3DEx);

    for (UINT i = 0; i < m_cAdapters; ++i)
    {
        delete m_rgRenderers[i];
    }
    delete [] m_rgRenderers;
    m_rgRenderers = NULL;

    m_pCurrentRenderer = NULL;
    m_cAdapters = 0;

    m_fSurfaceSettingsChanged = true;
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::SetSize
//
//  Synopsis:
//      Update the size of the surface. Next render will create a new surface.
//
//------------------------------------------------------------------------------
void 
CRendererManager::SetSize(UINT uWidth, UINT uHeight)
{
    if (uWidth != m_uWidth || uHeight != m_uHeight)
    {
        m_uWidth = uWidth;
        m_uHeight = uHeight;
        m_fSurfaceSettingsChanged = true;
    }
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::SetAlpha
//
//  Synopsis:
//      Update the format of the surface. Next render will create a new surface.
//
//------------------------------------------------------------------------------
void
CRendererManager::SetAlpha(bool fUseAlpha)
{
    if (fUseAlpha != m_fUseAlpha)
    {
        m_fUseAlpha = fUseAlpha;
        m_fSurfaceSettingsChanged = true;
    }
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::SetNumDesiredSamples
//
//  Synopsis:
//      Update the MSAA settings of the surface. Next render will create a 
//      new surface.
//
//------------------------------------------------------------------------------
void 
CRendererManager::SetNumDesiredSamples(UINT uNumSamples)
{
    if (m_uNumSamples != uNumSamples)
    {
        m_uNumSamples = uNumSamples;
        m_fSurfaceSettingsChanged = true;
    }
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::SetAdapter
//
//  Synopsis:
//      Update the current renderer. Next render will use the new renderer.
//
//------------------------------------------------------------------------------
// <snippetRendererManager_SetAdapter>
void 
CRendererManager::SetAdapter(POINT screenSpacePoint)
{
    CleanupInvalidDevices();

    //
    // After CleanupInvalidDevices, we may not have any D3D objects. Rather than
    // recreate them here, ignore the adapter update and wait for render to recreate.
    //

    if (m_pD3D && m_rgRenderers)
    {
        HMONITOR hMon = MonitorFromPoint(screenSpacePoint, MONITOR_DEFAULTTONULL);

        for (UINT i = 0; i < m_cAdapters; ++i)
        {
            if (hMon == m_pD3D->GetAdapterMonitor(i))
            {
                m_pCurrentRenderer = m_rgRenderers[i];
                break;
            }
        }
    }
}
// </snippetRendererManager_SetAdapter>

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRendererManager::Render
//
//  Synopsis:
//      Forward to the current renderer
//
//------------------------------------------------------------------------------
HRESULT
CRendererManager::Render()
{
    return m_pCurrentRenderer ? m_pCurrentRenderer->Render() : S_OK;
}
// </snippetRendererManagerCPP>