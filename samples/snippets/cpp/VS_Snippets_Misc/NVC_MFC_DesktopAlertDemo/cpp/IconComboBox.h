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
// CIconComboBox window

class CIconComboBox : public CComboBox
{
// Construction
public:
	CIconComboBox(CMFCToolBarImages& Icons);

// Attributes
protected:
	CMFCToolBarImages&	m_Icons;

// Operations
public:

// Overrides
	public:
	virtual int CompareItem(LPCOMPAREITEMSTRUCT lpCompareItemStruct);
	virtual void DrawItem(LPDRAWITEMSTRUCT lpDrawItemStruct);
	virtual void MeasureItem(LPMEASUREITEMSTRUCT lpMeasureItemStruct);

// Implementation
public:
	virtual ~CIconComboBox();

protected:
	DECLARE_MESSAGE_MAP()
};
