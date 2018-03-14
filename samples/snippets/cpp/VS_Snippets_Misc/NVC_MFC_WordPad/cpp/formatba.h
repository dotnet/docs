//
// formatba.h : header file
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) 1992-1998 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#ifndef __FORMATBA_H__
#define __FORMATBA_H__

/////////////////////////////////////////////////////////////////////////////
// CFormatBar dialog
class CFormatBar : public CMFCToolBar
{
	DECLARE_SERIAL(CFormatBar)

// Construction
public:
	CFormatBar();

// Operations
public:
	virtual void CFormatBar::OnUpdateCmdUI(CFrameWnd* pTarget, BOOL bDisableIfNoHndler);

	CMFCColorMenuButton* CreateColorButton ();
	CMFCToolBarFontComboBox* CreateFontComboButton ();
	CMFCToolBarMenuButton* CreateBorderTypeButton ();

// Attributes
public:
	CSize m_szBaseUnits;

protected:
	// <snippet5>
	CPalette	m_palColorPicker;	// Palette for color picker
	int			m_nNumColours;
    // </snippet5>

// Implementation
protected:
	virtual void OnReset ();

	// Generated message map functions
	//{{AFX_MSG(CFormatBar)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#endif

/////////////////////////////////////////////////////////////////////////////
