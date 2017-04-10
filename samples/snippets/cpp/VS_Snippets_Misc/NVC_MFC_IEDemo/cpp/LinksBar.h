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

/////////////////////////////////////////////////////////////////////////////
// CLinksBar window

class CLinksBar : public CMFCToolBar
{
	DECLARE_SERIAL(CLinksBar)

// Construction
public:
	CLinksBar();

// Attributes
public:

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CLinksBar)
	//}}AFX_VIRTUAL

	virtual BOOL OnSendCommand (const CMFCToolBarButton* pButton);
	virtual BOOL CanBeRestored () const
	{
		return TRUE;
	}
	virtual BOOL RestoreOriginalstate ();

	virtual BOOL AllowChangeTextLabels () const
	{
		return FALSE;
	}

// Implementation
public:
	virtual ~CLinksBar();

	// Generated message map functions
protected:
	//{{AFX_MSG(CLinksBar)
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};
