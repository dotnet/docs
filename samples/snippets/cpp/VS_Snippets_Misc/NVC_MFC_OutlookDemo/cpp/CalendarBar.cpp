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
#include "CalendarBar.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

const int nBorderSize = 10;

/////////////////////////////////////////////////////////////////////////////
// CCalendarBar

CCalendarBar::CCalendarBar()
{
	m_nMyCalendarsY = 0;
}

CCalendarBar::~CCalendarBar()
{
}

BEGIN_MESSAGE_MAP(CCalendarBar, CWnd)
	ON_WM_CREATE()
	ON_WM_ERASEBKGND()
	ON_WM_SIZE()
	ON_WM_PAINT()
	ON_WM_SETTINGCHANGE()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CCalendarBar message handlers

int CCalendarBar::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	CRect rectDummy(0, 0, 0, 0);
	m_wndCalendar.Create(WS_CHILD | WS_VISIBLE, rectDummy, this, 1);

	CBitmap bmp;
	bmp.LoadBitmap(IDB_PAGES_SMALL_HC);

	m_Images.Create(16, 16, ILC_COLOR24 | ILC_MASK, 0, 0);
	m_Images.Add(&bmp, RGB(255, 0, 255));

	return 0;
}

BOOL CCalendarBar::OnEraseBkgnd(CDC* /*pDC*/)
{
	return TRUE;
}

void CCalendarBar::OnSize(UINT nType, int cx, int cy)
{
	CWnd::OnSize(nType, cx, cy);

	int nMyCalendarsHeight = 70;

	if (m_wndCalendar.GetSafeHwnd() != NULL)
	{
		m_wndCalendar.SetWindowPos(NULL, nBorderSize, nBorderSize, cx - 2 * nBorderSize, cy - 2 * nBorderSize - nMyCalendarsHeight - 10, SWP_NOZORDER | SWP_NOACTIVATE);
	}

	m_nMyCalendarsY = cy - nMyCalendarsHeight;
}

BOOL CCalendarBar::Create(const RECT& rect, CWnd* pParentWnd, UINT nID)
{
	return CWnd::Create(NULL, _T(""), WS_CHILD | WS_VISIBLE, rect, pParentWnd, nID);
}

void CCalendarBar::OnPaint()
{
	CPaintDC dc(this); // device context for painting

	CRect rectClient;
	GetClientRect(rectClient);

	dc.FillRect(rectClient, &afxGlobalData.brWindow);

	if (rectClient.bottom - m_nMyCalendarsY > 0)
	{
		CRect rectMyCalendarsCaption = rectClient;
		rectMyCalendarsCaption.top = m_nMyCalendarsY;
		rectMyCalendarsCaption.bottom = rectMyCalendarsCaption.top + afxGlobalData.GetTextHeight(TRUE) * 3 / 2;

		COLORREF clrText = CMFCVisualManager::GetInstance()->OnDrawPaneCaption(&dc, NULL, FALSE, rectMyCalendarsCaption, CRect(0, 0, 0, 0));

		CPen* pOldPen = dc.SelectObject(&afxGlobalData.penBarShadow);

		dc.MoveTo(rectMyCalendarsCaption.left - 1, rectMyCalendarsCaption.top);
		dc.LineTo(rectMyCalendarsCaption.right, rectMyCalendarsCaption.top);

		dc.SelectStockObject(BLACK_PEN);

		dc.MoveTo(rectMyCalendarsCaption.left - 1, rectMyCalendarsCaption.bottom);
		dc.LineTo(rectMyCalendarsCaption.right, rectMyCalendarsCaption.bottom);

		dc.SelectObject(pOldPen);

		CRect rectText = rectMyCalendarsCaption;
		rectText.DeflateRect(10, 0);

		dc.SetBkMode(TRANSPARENT);
		dc.SetTextColor(clrText);

		CFont* pOldFont = dc.SelectObject(&afxGlobalData.fontRegular);

		CString str = _T("My Calendars");
		dc.DrawText(str, rectText, DT_VCENTER | DT_LEFT | DT_SINGLELINE);

		CRect rectCalendar = rectClient;
		rectCalendar.top = rectMyCalendarsCaption.bottom + 5;
		rectCalendar.bottom = rectCalendar.top + afxGlobalData.GetTextHeight(TRUE) * 3 / 2 - 5;

		dc.FillSolidRect(rectCalendar, RGB(255, 255, 213));

		rectCalendar.DeflateRect(20, 0);
		m_Images.Draw(&dc, 3, rectCalendar.TopLeft(), 0);

		rectCalendar.left += 20;

		str = _T("Calendar");

		dc.SetTextColor(afxGlobalData.clrHotLinkNormalText);
		dc.DrawText(str, rectCalendar, DT_VCENTER | DT_LEFT | DT_SINGLELINE);

		dc.SelectObject(pOldFont);
	}
}


