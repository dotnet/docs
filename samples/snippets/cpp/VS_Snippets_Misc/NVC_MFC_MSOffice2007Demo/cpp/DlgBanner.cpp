// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// http://msdn.microsoft.com/officeui.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

#include "stdafx.h"
#include "MSOffice2007Demo.h"
#include "DlgBanner.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDlgBanner

CDlgBanner::CDlgBanner()
{
}

CDlgBanner::~CDlgBanner()
{
}

BEGIN_MESSAGE_MAP(CDlgBanner, CStatic)
	//{{AFX_MSG_MAP(CDlgBanner)
	ON_WM_PAINT()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDlgBanner message handlers

void CDlgBanner::OnPaint()
{
	CPaintDC dc(this); // device context for painting

	CRect rect;
	GetClientRect(rect);

	CFont* pOldFont = dc.SelectObject(&afxGlobalData.fontBold);
	ASSERT(pOldFont != NULL);

	dc.SetTextColor(CMFCVisualManager::GetInstance()->OnDrawMenuLabel(&dc, rect));
	dc.SetBkMode(TRANSPARENT);

	rect.DeflateRect(5, 0);

	CString strText;
	GetWindowText(strText);

	dc.DrawText(strText, rect, DT_LEFT | DT_SINGLELINE | DT_VCENTER);

	dc.SelectObject(pOldFont);
}

