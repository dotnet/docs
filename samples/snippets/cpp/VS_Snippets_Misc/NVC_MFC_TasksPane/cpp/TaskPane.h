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

class CTaskPane : public CMFCTasksPane
{
	friend class CTasksPaneView;

// Construction
public:
	CTaskPane();
	
// Attributes
	int	m_nUserColorGroup;
	int	m_nUserColorTask;

protected:
	int	m_nDocumentsGroup;

	CFont		m_Font;
	CTreeCtrl	m_wndTree;
	CEdit		m_wndEdit;

// Operations
public:
	void UpdateMRUFilesList ();
	void UpdateToolbar ();

// Overrides
public:

protected:
	BOOL CreateTreeControl();
	BOOL CreateEditControl();

// Implementation
public:
	virtual ~CTaskPane();

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);

	DECLARE_MESSAGE_MAP()
};

