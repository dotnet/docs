// <snippetRendererCPP>
//+-----------------------------------------------------------------------------
//
//  CRenderer
//
//      An abstract base class that creates a device and a target render 
//      surface. Derive from this class and override Init() and Render() 
//      to do your own rendering. See CTriangleRenderer for an example.


//------------------------------------------------------------------------------

#include "StdAfx.h"

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRenderer ctor
//
//------------------------------------------------------------------------------
CRenderer::CRenderer() : m_pd3dDevice(NULL), m_pd3dDeviceEx(NULL), m_pd3dRTS(NULL)
{
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRenderer dtor
//
//------------------------------------------------------------------------------
CRenderer::~CRenderer()
{
    SAFE_RELEASE(m_pd3dDevice);
    SAFE_RELEASE(m_pd3dDeviceEx);
    SAFE_RELEASE(m_pd3dRTS);
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRenderer::CheckDeviceState
//
//  Synopsis:
//      Returns the status of the device. 9Ex devices are a special case because 
//      TestCooperativeLevel() has been deprecated in 9Ex.
//
//------------------------------------------------------------------------------
HRESULT 
CRenderer::CheckDeviceState()
{
    if (m_pd3dDeviceEx)
    {
        return m_pd3dDeviceEx->CheckDeviceState(NULL);
    }
    else if (m_pd3dDevice)
    {
        return m_pd3dDevice->TestCooperativeLevel();
    }
    else
    {
        return D3DERR_DEVICELOST;
    }
}

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRenderer::CreateSurface
//
//  Synopsis:
//      Creates and sets the render target
//
//------------------------------------------------------------------------------
// <snippetRenderer_CreateSurface>
HRESULT
CRenderer::CreateSurface(UINT uWidth, UINT uHeight, bool fUseAlpha, UINT m_uNumSamples)
{
    HRESULT hr = S_OK;

    SAFE_RELEASE(m_pd3dRTS);

    IFC(m_pd3dDevice->CreateRenderTarget(
        uWidth,
        uHeight,
        fUseAlpha ? D3DFMT_A8R8G8B8 : D3DFMT_X8R8G8B8,
        static_cast<D3DMULTISAMPLE_TYPE>(m_uNumSamples),
        0,
        m_pd3dDeviceEx ? FALSE : TRUE,  // Lockable RT required for good XP perf
        &m_pd3dRTS,
        NULL
        ));

    IFC(m_pd3dDevice->SetRenderTarget(0, m_pd3dRTS));

Cleanup:
    return hr;
}
// </snippetRenderer_CreateSurface>

//+-----------------------------------------------------------------------------
//
//  Member:
//      CRenderer::Init
//
//  Synopsis:
//      Creates the device
//
//------------------------------------------------------------------------------
// <snippetRenderer_Init>
HRESULT 
CRenderer::Init(IDirect3D9 *pD3D, IDirect3D9Ex *pD3DEx, HWND hwnd, UINT uAdapter)
{
    HRESULT hr = S_OK;

    D3DPRESENT_PARAMETERS d3dpp;
    ZeroMemory(&d3dpp, sizeof(d3dpp));
    d3dpp.Windowed = TRUE;
    d3dpp.BackBufferFormat = D3DFMT_UNKNOWN;
    d3dpp.BackBufferHeight = 1;
    d3dpp.BackBufferWidth = 1;
    d3dpp.SwapEffect = D3DSWAPEFFECT_DISCARD;

    D3DCAPS9 caps;
    DWORD dwVertexProcessing;
    IFC(pD3D->GetDeviceCaps(uAdapter, D3DDEVTYPE_HAL, &caps));
    if ((caps.DevCaps & D3DDEVCAPS_HWTRANSFORMANDLIGHT) == D3DDEVCAPS_HWTRANSFORMANDLIGHT)
    {
        dwVertexProcessing = D3DCREATE_HARDWARE_VERTEXPROCESSING;
    }
    else
    {
        dwVertexProcessing = D3DCREATE_SOFTWARE_VERTEXPROCESSING;
    }

    if (pD3DEx)
    {
        IDirect3DDevice9Ex *pd3dDevice = NULL;
        IFC(pD3DEx->CreateDeviceEx(
            uAdapter,
            D3DDEVTYPE_HAL,
            hwnd,
            dwVertexProcessing | D3DCREATE_MULTITHREADED | D3DCREATE_FPU_PRESERVE,
            &d3dpp,
            NULL,
            &m_pd3dDeviceEx
            ));

        IFC(m_pd3dDeviceEx->QueryInterface(__uuidof(IDirect3DDevice9), reinterpret_cast<void**>(&m_pd3dDevice)));  
    }
    else 
    {
        assert(pD3D);

        IFC(pD3D->CreateDevice(
            uAdapter,
            D3DDEVTYPE_HAL,
            hwnd,
            dwVertexProcessing | D3DCREATE_MULTITHREADED | D3DCREATE_FPU_PRESERVE,
            &d3dpp,
            &m_pd3dDevice
            ));
    }

Cleanup:
    return hr;
}
// </snippetRenderer_Init>
// </snippetRendererCPP>