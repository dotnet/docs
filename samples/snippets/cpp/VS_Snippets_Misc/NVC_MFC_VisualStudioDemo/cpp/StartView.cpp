// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "VisualStudioDemo.h"
#include "StartView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CStartView

#define IDC_START_IMAGE 1

IMPLEMENT_DYNCREATE(CStartView, CView)

CStartView::CStartView()
{
}

CStartView::~CStartView()
{
}

BEGIN_MESSAGE_MAP(CStartView, CView)
	ON_WM_ERASEBKGND()
	ON_UPDATE_COMMAND_UI(ID_FILE_SAVE, OnDisableUpdate)
	ON_UPDATE_COMMAND_UI(ID_FILE_SAVE_AS, OnDisableUpdate)
	ON_UPDATE_COMMAND_UI(ID_FILE_PRINT_SETUP, OnDisableUpdate)
	ON_UPDATE_COMMAND_UI(ID_FILE_PRINT_PREVIEW, OnDisableUpdate)
	ON_UPDATE_COMMAND_UI(ID_FILE_PRINT, OnDisableUpdate)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CStartView diagnostics

#ifdef _DEBUG
void CStartView::AssertValid() const
{
	CView::AssertValid();
}

void CStartView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CStartView message handlers

void CStartView::OnInitialUpdate()
{
	CDocument* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	if (m_Image.GetCount() == 0)
	{
		// <snippet33>
		m_Image.SetImageSize (CSize (32, 32));
		m_Image.Load(IDR_START);
		m_Image.SetTransparentColor(RGB(255, 0, 255));
		// </snippet33>
	}

	pDoc->SetTitle(_T("Start Page"));
}

void CStartView::OnDraw(CDC* pDC)
{
	ASSERT_VALID(pDC);

	CRect rectClient;
	GetClientRect(rectClient);

	pDC->FillSolidRect(rectClient, RGB(255, 255, 255));

	m_Image.DrawEx(pDC, rectClient, 0);
}

BOOL CStartView::OnEraseBkgnd(CDC* /*pDC*/)
{
	return TRUE;
}

void CStartView::OnDisableUpdate(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(FALSE);
}
