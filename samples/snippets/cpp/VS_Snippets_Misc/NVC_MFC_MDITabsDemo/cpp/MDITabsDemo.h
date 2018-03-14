// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

class CMDITabOptions
{
public:
	CMDITabOptions();

	enum MDITabsType
	{
		None,
		MDITabsStandard,
		MDITabbedGroups
	};


	MDITabsType			m_nMDITabsType;
	BOOL				m_bTabsOnTop;
	BOOL				m_bActiveTabCloseButton;
	CMFCTabCtrl::Style	m_nTabsStyle;
	BOOL				m_bTabsAutoColor;
	BOOL				m_bMDITabsIcons;
	BOOL				m_bMDITabsDocMenu;
	BOOL				m_bDragMDITabs;
	BOOL				m_bMDITabsContextMenu;
	int					m_nMDITabsBorderSize;
	BOOL				m_bDisableMDIChildRedraw;
	BOOL				m_bFlatFrame;
	BOOL				m_bCustomTooltips;

	void Load ();
	void Save ();

	BOOL IsMDITabsDisabled () const {return m_nMDITabsType == CMDITabOptions::None;}
};

/////////////////////////////////////////////////////////////////////////////
// CMDITabsDemoApp:
// See MDITabsDemo.cpp for the implementation of this class
//

class CMDITabsDemoApp : public CWinAppEx
{
public:
	CMDITabsDemoApp();

	virtual void PreLoadState ();
	
	void UpdateMDITabs (BOOL bResetMDIChild);

	CMDITabOptions	m_Options;

// Overrides
	public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	afx_msg void OnAppAbout();

	DECLARE_MESSAGE_MAP()
};


extern CMDITabsDemoApp theApp;
