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

class CWorkspaceBar : public CDockablePane
{
public:
	CWorkspaceBar();

// Attributes
protected:
	CMFCTabCtrl	m_wndTabs;

	CTreeCtrl	m_wndTree1;
	CTreeCtrl	m_wndTree2;

// Operations
public:

// Overrides

// Implementation
public:
	virtual ~CWorkspaceBar();

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSize(UINT nType, int cx, int cy);

	DECLARE_MESSAGE_MAP()
};
