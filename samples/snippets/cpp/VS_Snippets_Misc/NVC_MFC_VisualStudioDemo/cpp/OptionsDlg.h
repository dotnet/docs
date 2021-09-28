// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

#include "OptionsPages.h"

/////////////////////////////////////////////////////////////////////////////
// COptionsDlg

class COptionsDlg : public CMFCPropertySheet
{
	DECLARE_DYNAMIC(COptionsDlg)

// Construction
public:
	COptionsDlg(LPCTSTR pszCaption, CWnd* pParentWnd = NULL, UINT iSelectPage = 0);

// Attributes
public:
	COptionsPage1  m_Page11;
	COptionsPage12 m_Page12;
	COptionsPage21 m_Page21;
	COptionsPage22 m_Page22;
	COptionsPage31 m_Page31;
	COptionsPage32 m_Page32;

// Implementation
public:
	virtual ~COptionsDlg();

protected:
	DECLARE_MESSAGE_MAP()
};

