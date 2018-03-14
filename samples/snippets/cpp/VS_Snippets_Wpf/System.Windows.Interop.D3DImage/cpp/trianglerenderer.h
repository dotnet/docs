// <snippetTriangleRendererH>
#pragma once

class CTriangleRenderer : public CRenderer
{
public:
    static HRESULT Create(IDirect3D9 *pD3D, IDirect3D9Ex *pD3DEx, HWND hwnd, UINT uAdapter, CRenderer **ppRenderer);
    ~CTriangleRenderer();

    HRESULT Render();

protected:
    HRESULT Init(IDirect3D9 *pD3D, IDirect3D9Ex *pD3DEx, HWND hwnd, UINT uAdapter);

private:
    CTriangleRenderer();

    IDirect3DVertexBuffer9 *m_pd3dVB;
};
// </snippetTriangleRendererH>