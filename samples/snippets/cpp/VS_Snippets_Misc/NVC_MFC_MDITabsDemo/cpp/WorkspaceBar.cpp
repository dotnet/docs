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
#include "MDITabsDemo.h"
#include "WorkspaceBar.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#pragma warning(disable: 4800)  // 'LPCVARIANT' : forcing value to bool 'true' or 'false' (performance warning)

const int nBorderSize = 1;

static TCHAR* lpszMDITabsStyles [] = 
{
	_T("None"),
	_T("MDI Tabs (Standard)"),
	_T("MDI Tabbed Groups"),
	NULL
};


static TCHAR* lpszStyles [] = 
{
	_T("3D Tabs"),
	_T("OneNote"),
	_T("Visual Studio 2005"),
	NULL
};

/////////////////////////////////////////////////////////////////////////////
// CWorkspaceBar

BEGIN_MESSAGE_MAP(CWorkspaceBar, CDockablePane)
	ON_WM_CREATE()
	ON_WM_SIZE()
	ON_WM_PAINT()
	ON_REGISTERED_MESSAGE(AFX_WM_PROPERTY_CHANGED, OnPropertyChanged)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CWorkspaceBar construction/destruction

CWorkspaceBar::CWorkspaceBar()
{
	// TODO: add one-time construction code here

}

CWorkspaceBar::~CWorkspaceBar()
{
}

/////////////////////////////////////////////////////////////////////////////
// CWorkspaceBar message handlers

int CWorkspaceBar::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CDockablePane::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	CRect rectDummy;
	rectDummy.SetRectEmpty ();

	if (!m_wndPropList.Create (WS_VISIBLE | WS_CHILD, rectDummy, this, 1))
	{
		TRACE0("Failed to create Properies Grid \n");
		return -1;      // fail to create
	}

	m_wndPropList.EnableHeaderCtrl (FALSE);
	m_wndPropList.EnableDescriptionArea ();
	m_wndPropList.SetVSDotNetLook ();

	CMFCPropertyGridProperty* pMDITabsProp = new CMFCPropertyGridProperty (_T("Enable MDI Tabs"), 
		lpszMDITabsStyles [1],
		_T("Enable or disable either the standard MDI Tabs feature, or MDI Tabbed Groups feature"), 
		idShowMDITabs);

	pMDITabsProp->AddOption (_T ("None"));
	pMDITabsProp->AddOption (_T ("MDI Tabs (Standard)"));
	pMDITabsProp->AddOption (_T ("MDI Tabbed Groups"));

	int i = 0;
	for (i = 0; lpszMDITabsStyles [i] != NULL; i++)
	{
		pMDITabsProp->AddOption (lpszMDITabsStyles [i]);
	}

	switch (theApp.m_Options.m_nMDITabsType)
	{
	case CMDITabOptions::None:
		pMDITabsProp->SetValue (lpszMDITabsStyles [0]);
		break;

	case CMDITabOptions::MDITabsStandard:
		pMDITabsProp->SetValue (lpszMDITabsStyles [1]);
		break;

	case CMDITabOptions::MDITabbedGroups:
		pMDITabsProp->SetValue (lpszMDITabsStyles [2]);
		break;
	}

	pMDITabsProp->AllowEdit (FALSE);

	m_wndPropList.AddProperty (pMDITabsProp);

	COleVariant varTabsOnTop((short)(theApp.m_Options.m_bTabsOnTop == TRUE), VT_BOOL);
	m_wndPropList.AddProperty (new CMFCPropertyGridProperty (_T("Tabs on top"), varTabsOnTop,
		_T("Show MDI tabs on top"), idTabsOnTop));

	COleVariant varActiveTabCloseButton((short)(theApp.m_Options.m_bActiveTabCloseButton == TRUE), VT_BOOL);
	m_wndPropList.AddProperty (new CMFCPropertyGridProperty (_T("Active tab \"Close\" button"), varActiveTabCloseButton,
		_T("Show \"Close\" button on the active tab right side"), idActiveTabCloseButton));

	CMFCPropertyGridProperty* pProp = new CMFCPropertyGridProperty (_T("MDI Tabs style"), _T(""),
		_T("One of: VS.NET, OneNote or Visual Studio 2005"), idTabsStyle);

	for (i = 0; lpszStyles [i] != NULL; i++)
	{
		pProp->AddOption (lpszStyles [i]);
	}

	switch (theApp.m_Options.m_nTabsStyle)
	{
	case CMFCTabCtrl::STYLE_3D_SCROLLED:
		pProp->SetValue (lpszStyles [0]);
		break;

	case CMFCTabCtrl::STYLE_3D_ONENOTE:
		pProp->SetValue (lpszStyles [1]);
		break;

	case CMFCTabCtrl::STYLE_3D_VS2005:
		pProp->SetValue (lpszStyles [2]);
		break;
	}

	pProp->AllowEdit (FALSE);
	m_wndPropList.AddProperty (pProp);

	COleVariant varTabsAutoColor((short)(theApp.m_Options.m_bTabsAutoColor == TRUE), VT_BOOL);
	m_wndPropList.AddProperty (new CMFCPropertyGridProperty (_T("Tabs auto-color"), varTabsAutoColor,
		_T("Set MDI tabs automatic color"), idTabsAutoColor));

	COleVariant varMDITabsIcons((short)(theApp.m_Options.m_bMDITabsIcons == TRUE), VT_BOOL);
	m_wndPropList.AddProperty (new CMFCPropertyGridProperty (_T("Tab icons"), varMDITabsIcons,
		_T("Show document icons on MDI tabs"), idMDITabsIcons));

	COleVariant varMDITabsDocMenu((short)(theApp.m_Options.m_bMDITabsDocMenu == TRUE), VT_BOOL);
	m_wndPropList.AddProperty (new CMFCPropertyGridProperty (_T("Tabs document menu"), varMDITabsDocMenu,
		_T("Show menu with a list of opened documents"), idMDITabsDocMenu));

	COleVariant varDragMDITabs((short)(theApp.m_Options.m_bDragMDITabs == TRUE), VT_BOOL);
	m_wndPropList.AddProperty (new CMFCPropertyGridProperty (_T("Drag tabs"), varDragMDITabs,
		_T("Enable MDI tabs order changing"), idDragMDITabs));

	COleVariant varMDITabsContextMenu((short)(theApp.m_Options.m_bMDITabsContextMenu == TRUE), VT_BOOL);
	m_wndPropList.AddProperty (new CMFCPropertyGridProperty (_T("Context Menu"), varMDITabsContextMenu,
		_T("Enable MDI tabs context menu"), idMDITabsContextMenu));

	CMFCPropertyGridProperty* pBorderProp = new CMFCPropertyGridProperty (_T("Border Size"), 
		(COleVariant) ((short) theApp.m_Options.m_nMDITabsBorderSize),
		_T("Set MDI border"), idMDITabsBorderSize);
	pBorderProp->EnableSpinControl (TRUE, 0, 10);
	pBorderProp->AllowEdit(FALSE);

	m_wndPropList.AddProperty (pBorderProp);

	COleVariant varDisableMDIChildRedraw((short)(theApp.m_Options.m_bDisableMDIChildRedraw == TRUE), VT_BOOL);
	m_wndPropList.AddProperty (new CMFCPropertyGridProperty (_T("No optimize MDI child redraw"), varDisableMDIChildRedraw,
		_T("Disable MDI Child redraw optimization"), idDisableMDIChildRedraw));

	COleVariant varFlatFrame((short)(theApp.m_Options.m_bFlatFrame == TRUE), VT_BOOL);
	m_wndPropList.AddProperty (new CMFCPropertyGridProperty (_T("Flat Frame"), varFlatFrame,
		_T("Enable or disable 3D frame around MDI client area"), idFlatFrame));

	COleVariant varCustomTooltips((short)(theApp.m_Options.m_bCustomTooltips == TRUE), VT_BOOL);
	m_wndPropList.AddProperty (new CMFCPropertyGridProperty (_T("Custom Tooltips"), varCustomTooltips,
		_T("Enable MDI tabs custom tooltips"), idCustomTooltips));

	SetPropState ();
	return 0;
}

void CWorkspaceBar::OnSize(UINT nType, int cx, int cy) 
{
	CDockablePane::OnSize(nType, cx, cy);

	// Tab control should cover a whole client area:
	m_wndPropList.SetWindowPos (NULL, nBorderSize, nBorderSize, 
		cx - 2 * nBorderSize, cy - 2 * nBorderSize,
		SWP_NOACTIVATE | SWP_NOZORDER);
}

void CWorkspaceBar::OnPaint() 
{
	CPaintDC dc(this); // device context for painting
	
	CRect rectTree;
	m_wndPropList.GetWindowRect (rectTree);
	ScreenToClient (rectTree);

	rectTree.InflateRect (nBorderSize, nBorderSize);
	dc.Draw3dRect (rectTree,	::GetSysColor (COLOR_3DSHADOW), 
								::GetSysColor (COLOR_3DSHADOW));
}

LRESULT CWorkspaceBar::OnPropertyChanged (WPARAM,LPARAM lParam)
{
	CMFCPropertyGridProperty* pProp = (CMFCPropertyGridProperty*) lParam;

	BOOL bResetMDIChild = FALSE;

	switch ((int) pProp->GetData ())
	{
	case idShowMDITabs:
		{
			CString strShowMdiTabOption = (LPCTSTR) (_bstr_t)pProp->GetValue ();
			bResetMDIChild = TRUE;

			for (int i = 0; lpszMDITabsStyles [i] != NULL; i++)
			{
				if (strShowMdiTabOption == lpszMDITabsStyles [i])
				{
					switch (i)
					{
					case 0:
						theApp.m_Options.m_nMDITabsType = CMDITabOptions::None;
						break;

					case 1:
						theApp.m_Options.m_nMDITabsType = CMDITabOptions::MDITabsStandard;
						break;

					case 2:
						theApp.m_Options.m_nMDITabsType = CMDITabOptions::MDITabbedGroups;
						break;
					}
					break;
				}
			}
			
			SetPropState ();
		}
		break;

	case idTabsOnTop:
		theApp.m_Options.m_bTabsOnTop = pProp->GetValue().boolVal == VARIANT_TRUE;
		break;

	case idActiveTabCloseButton:
		theApp.m_Options.m_bActiveTabCloseButton = pProp->GetValue().boolVal == VARIANT_TRUE;
		break;

	case idTabsStyle:
		{
			CString strStyle = (LPCTSTR) (_bstr_t)pProp->GetValue ();

			for (int i = 0; lpszStyles [i] != NULL; i++)
			{
				if (strStyle == lpszStyles [i])
				{
					switch (i)
					{
					case 0:
						theApp.m_Options.m_nTabsStyle = CMFCTabCtrl::STYLE_3D_SCROLLED;
						break;

					case 1:
						theApp.m_Options.m_nTabsStyle = CMFCTabCtrl::STYLE_3D_ONENOTE;
						break;

					case 2:
						theApp.m_Options.m_nTabsStyle = CMFCTabCtrl::STYLE_3D_VS2005;
						break;
					}
					break;
				}
			}
		}
		break;

	case idTabsAutoColor:
		theApp.m_Options.m_bTabsAutoColor = pProp->GetValue().boolVal == VARIANT_TRUE;
		break;

	case idMDITabsIcons:
		theApp.m_Options.m_bMDITabsIcons = pProp->GetValue().boolVal == VARIANT_TRUE;
		break;

	case idMDITabsDocMenu:
		theApp.m_Options.m_bMDITabsDocMenu = pProp->GetValue().boolVal == VARIANT_TRUE;
		break;

	case idDragMDITabs:
		theApp.m_Options.m_bDragMDITabs = pProp->GetValue().boolVal == VARIANT_TRUE;
		break;

	case idMDITabsContextMenu:
		theApp.m_Options.m_bMDITabsContextMenu = pProp->GetValue().boolVal == VARIANT_TRUE;
		break;

	case idMDITabsBorderSize:
		{
			int nBorder = pProp->GetValue ().iVal;
			theApp.m_Options.m_nMDITabsBorderSize = min (10, max (0, nBorder));
		}
		break;

	case idDisableMDIChildRedraw:
		theApp.m_Options.m_bDisableMDIChildRedraw = pProp->GetValue().boolVal == VARIANT_TRUE;
		break;

	case idFlatFrame:
		theApp.m_Options.m_bFlatFrame = pProp->GetValue().boolVal == VARIANT_TRUE;
		break;

	case idCustomTooltips:
		theApp.m_Options.m_bCustomTooltips = pProp->GetValue().boolVal == VARIANT_TRUE;
		break;
	}

	theApp.UpdateMDITabs (bResetMDIChild);
	return 0;
}

void CWorkspaceBar::SetPropState ()
{
	for (int i = 0; i < m_wndPropList.GetPropertyCount (); i++)
	{
		CMFCPropertyGridProperty* pProp = m_wndPropList.GetProperty (i);
		ASSERT_VALID (pProp);

		if ((int) pProp->GetData () != idShowMDITabs)
		{
			pProp->Enable (theApp.m_Options.m_nMDITabsType != CMDITabOptions::None);
		}
	}

	if (m_wndPropList.GetSafeHwnd () != NULL)
	{
		m_wndPropList.RedrawWindow ();
	}
}
