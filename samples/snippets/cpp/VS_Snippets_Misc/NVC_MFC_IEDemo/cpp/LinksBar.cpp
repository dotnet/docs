// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "IEDemo.h"
#include "LinksBar.h"
#include "LinkButton.h"
#include "IEDemoDoc.h"
#include "IEDemoView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

IMPLEMENT_SERIAL(CLinksBar, CMFCToolBar, 1)

/////////////////////////////////////////////////////////////////////////////
// CLinksBar

CLinksBar::CLinksBar()
{
}

CLinksBar::~CLinksBar()
{
}


BEGIN_MESSAGE_MAP(CLinksBar, CMFCToolBar)
	//{{AFX_MSG_MAP(CLinksBar)
	ON_WM_CREATE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()


/////////////////////////////////////////////////////////////////////////////
// CLinksBar message handlers

int CLinksBar::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CMFCToolBar::OnCreate(lpCreateStruct) == -1)
		return -1;

	RestoreOriginalstate ();
	return 0;
}

BOOL CLinksBar::OnSendCommand (const CMFCToolBarButton* pButton)
{
	CLinkButton* pLinkButton = DYNAMIC_DOWNCAST (CLinkButton, pButton);
	if (pLinkButton == NULL)
	{
		// Defauult processing
		return FALSE;
	}

	CString strURL = pLinkButton->GetURL ();

	((CIEDemoView*)GetParentFrame ()->GetActiveView())->Navigate2 (strURL, 0, NULL);
	return TRUE;
}

BOOL CLinksBar::RestoreOriginalstate ()
{
	RemoveAllButtons ();

	InsertButton (CLinkButton (_T("MSDN Home"), _T("http://www.msdn.com")));
	InsertButton (CLinkButton (_T("Microsoft Home"), _T("http://www.microsoft.com")));
	InsertButton (CLinkButton (_T("Visual C++ Developer Center"), _T("http://msdn2.microsoft.com/visualc/")));

	EnableCustomizeButton (TRUE, -1, _T(""));

	AdjustLayout ();
	Invalidate ();

	return TRUE;
}
