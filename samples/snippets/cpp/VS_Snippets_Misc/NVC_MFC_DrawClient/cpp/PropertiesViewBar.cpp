// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "DrawClient.h"
#include "PropertiesViewBar.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif


CPropertiesViewBar::CPropertiesViewBar(void)
{
}

CPropertiesViewBar::~CPropertiesViewBar(void)
{
}

BEGIN_MESSAGE_MAP(CPropertiesViewBar, CDockablePane)
	ON_WM_CREATE()
	ON_WM_SIZE()
	ON_WM_SETFOCUS()
	ON_COMMAND (ID_EXPAND, OnPropListTreeMode)
	ON_UPDATE_COMMAND_UI (ID_EXPAND, OnUpdatePropListTreeMode)
	ON_COMMAND (ID_SORTINGGROUP, OnPropListAlphabetMode)
	ON_UPDATE_COMMAND_UI (ID_SORTINGGROUP, OnUpdatePropListAlphabetMode)
END_MESSAGE_MAP()

void CPropertiesViewBar::AdjustLayout ()
{
	if (GetSafeHwnd () == NULL)
	{
		return;
	}

	CRect rectClient;
	GetClientRect (rectClient);

	int cyTlb = m_wndToolBar.CalcFixedLayout (FALSE, TRUE).cy;

	m_wndToolBar.SetWindowPos (NULL,
							   rectClient.left, 
							   rectClient.top, 
							   rectClient.Width (),
							   cyTlb,
							   SWP_NOACTIVATE | SWP_NOZORDER);


	m_wndPropList.SetWindowPos (NULL,
								  rectClient.left, 
								  rectClient.top + cyTlb, 
								  rectClient.Width (),
								  rectClient.Height () - cyTlb,
								  SWP_NOACTIVATE | SWP_NOZORDER);
}
int CPropertiesViewBar::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CDockablePane::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	CRect rectDummy;
	rectDummy.SetRectEmpty ();

	if (!m_wndPropList.Create (WS_VISIBLE | WS_CHILD, rectDummy, this, 2))
	{
		TRACE0("Failed to create Properies Grid \n");
		return -1;      // fail to create
	}

	m_wndToolBar.Create (this, AFX_DEFAULT_TOOLBAR_STYLE, IDR_PROPERTIES);
	m_wndToolBar.LoadToolBar (IDR_PROPERTIES, 0, 0, TRUE /* Is locked */);

	m_wndPropList.SetVSDotNetLook (TRUE);
	m_wndPropList.SetGroupNameFullWidth (TRUE);
	m_wndPropList.EnableDescriptionArea (TRUE);

	m_wndToolBar.SetPaneStyle(m_wndToolBar.GetPaneStyle() |
		CBRS_TOOLTIPS | CBRS_FLYBY);
		
	m_wndToolBar.SetPaneStyle (
		m_wndToolBar.GetPaneStyle () & 
			~(CBRS_GRIPPER | CBRS_SIZE_DYNAMIC | CBRS_BORDER_TOP | CBRS_BORDER_BOTTOM | CBRS_BORDER_LEFT | CBRS_BORDER_RIGHT));

	m_wndToolBar.SetOwner (this);

	// All commands will be routed via this control , not via the parent frame:
	m_wndToolBar.SetRouteCommandsViaFrame (FALSE);

	AdjustLayout ();
	return 0;
}

void CPropertiesViewBar::OnSize(UINT nType, int cx, int cy) 
{
	CDockablePane::OnSize(nType, cx, cy);
	AdjustLayout ();
}

void CPropertiesViewBar::OnSetFocus(CWnd* pOldWnd)
{
	CDockablePane::OnSetFocus(pOldWnd);
	m_wndPropList.SetFocus ();
}
void CPropertiesViewBar::OnPropListTreeMode ()
{
	m_wndPropList.SetAlphabeticMode (FALSE);
}
void CPropertiesViewBar::OnPropListAlphabetMode ()
{
	m_wndPropList.SetAlphabeticMode (TRUE);
}
void CPropertiesViewBar::OnUpdatePropListTreeMode (CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck (!m_wndPropList.IsAlphabeticMode ());
}
void CPropertiesViewBar::OnUpdatePropListAlphabetMode (CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck (m_wndPropList.IsAlphabeticMode ());
}


