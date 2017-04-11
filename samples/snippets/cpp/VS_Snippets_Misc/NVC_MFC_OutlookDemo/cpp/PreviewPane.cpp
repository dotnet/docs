// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "OutlookDemo.h"
#include "PreviewPane.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

const int nHorzMargin = 2;
const int nVertMargin = 2;

/////////////////////////////////////////////////////////////////////////////
// CPreviewPane

IMPLEMENT_DYNCREATE(CPreviewPane, CView)

CPreviewPane::CPreviewPane()
{
}

CPreviewPane::~CPreviewPane()
{
}

BEGIN_MESSAGE_MAP(CPreviewPane, CView)
	ON_WM_ERASEBKGND()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPreviewPane drawing

void CPreviewPane::OnDraw(CDC* pDC)
{
	CRect rectClient;
	GetClientRect(rectClient);

	CRect rectCaption = rectClient;
	rectCaption.bottom = rectCaption.top + afxGlobalData.GetTextHeight() + 4;

	CRect rectMessage = rectClient;
	rectMessage.top = rectCaption.bottom;

	pDC->FillRect(rectCaption, &afxGlobalData.brBarFace);
	pDC->FillRect(rectMessage, &afxGlobalData.brWindow);

	int nOldBkMode = pDC->SetBkMode(TRANSPARENT);
	COLORREF clrOldText = pDC->SetTextColor(afxGlobalData.clrBarText);
	CFont* pOldFont = (CFont*) pDC->SelectStockObject(DEFAULT_GUI_FONT);

	CRect rectText = rectCaption;
	rectText.left += 2 * nHorzMargin;
	rectText.right -= 2 * nHorzMargin + rectText.Height();

	CString strCaption = _T("Preview area...");
	pDC->DrawText(strCaption, rectText, DT_END_ELLIPSIS | DT_SINGLELINE | DT_VCENTER);

	pDC->SetTextColor(afxGlobalData.clrWindowText);

	rectText = rectMessage;
	rectText.DeflateRect(nHorzMargin, nVertMargin);

	CString strText = _T("Message body");
	pDC->DrawText(strText, rectText, DT_WORDBREAK | DT_END_ELLIPSIS);

	pDC->SelectObject(pOldFont);
	pDC->SetTextColor(clrOldText);
	pDC->SetBkMode(nOldBkMode);
}

/////////////////////////////////////////////////////////////////////////////
// CPreviewPane diagnostics

#ifdef _DEBUG
void CPreviewPane::AssertValid() const
{
	CView::AssertValid();
}

void CPreviewPane::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CPreviewPane message handlers

BOOL CPreviewPane::OnEraseBkgnd(CDC* /*pDC*/)
{
	return TRUE;
}
