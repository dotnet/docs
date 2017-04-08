// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CUndoBar;

/////////////////////////////////////////////////////////////////////////////
// CUndoListBox window

class CUndoListBox : public CListBox
{
// Construction
public:
	CUndoListBox(CUndoBar& bar);

// Attributes
protected:
	CUndoBar& m_Bar;

// Implementation
public:
	virtual ~CUndoListBox();

protected:
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
	afx_msg void OnLButtonUp(UINT nFlags, CPoint point);

	DECLARE_MESSAGE_MAP()
};
