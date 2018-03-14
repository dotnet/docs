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
#include "MailBar.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMailBar dialog

CMailBar::CMailBar()
{
}

void CMailBar::DoDataExchange(CDataExchange* pDX)
{
	CPaneDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CMailBar, CPaneDialog)
	ON_WM_SIZE()
	ON_WM_ERASEBKGND()
	ON_WM_CTLCOLOR()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMailBar message handlers

void CMailBar::AdjustWidth(int cx, UINT uiCtrlID)
{
	const int nMargin = 10;

	CWnd* pWnd = GetDlgItem(uiCtrlID);
	if (pWnd == NULL)
	{
		return;
	}

	CRect rect;
	pWnd->GetWindowRect(rect);
	ScreenToClient(rect);

	rect.right = cx - nMargin;

	pWnd->SetWindowPos(NULL, -1, -1, rect.Width(), rect.Height(), SWP_NOMOVE | SWP_NOACTIVATE | SWP_NOZORDER);
}

void CMailBar::OnSize(UINT nType, int cx, int cy)
{
	CPaneDialog::OnSize(nType, cx, cy);

	AdjustWidth(cx, IDC_MAIL_TO_NAME);
	AdjustWidth(cx, IDC_MAIL_CC_NAME);
	AdjustWidth(cx, IDC_MAIL_SUBJECT_NAME);

}

BOOL CMailBar::OnEraseBkgnd(CDC* pDC)
{
	CRect rectClient;
	GetClientRect(rectClient);

	// <snippet4>
	// CDC* pDC
	// CRect rectClient
	// The this pointer points to a CMailBar class which extends the CPaneDialog class.
	CMFCVisualManager::GetInstance()->OnFillBarBackground(pDC, this, rectClient, rectClient);
	// </snippet4>

	return TRUE;
}

HBRUSH CMailBar::OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor)
{
#define MAX_CLASS_NAME 255
#define STATIC_CLASS _T("Static")
#define BUTTON_CLASS _T("Button")

	if (nCtlColor == CTLCOLOR_STATIC || nCtlColor == CTLCOLOR_BTN)
	{
		TCHAR lpszClassName [MAX_CLASS_NAME + 1];

		::GetClassName(pWnd->GetSafeHwnd(), lpszClassName, MAX_CLASS_NAME);
		CString strClass = lpszClassName;

		if (strClass == STATIC_CLASS || strClass == BUTTON_CLASS)
		{
			pDC->SetBkMode(TRANSPARENT);
			return(HBRUSH) ::GetStockObject(HOLLOW_BRUSH);
		}
	}

	return CPaneDialog::OnCtlColor(pDC, pWnd, nCtlColor);
}

