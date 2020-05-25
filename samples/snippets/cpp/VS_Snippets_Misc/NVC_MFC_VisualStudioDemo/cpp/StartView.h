// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CStartView view

class CStartView : public CView
{
protected:
	CStartView();           // protected constructor used by dynamic creation
	DECLARE_DYNCREATE(CStartView)

// Attributes
public:
	// <snippet32>
	CMFCToolBarImages m_Image;
	// </snippet32>

// Overrides
public:
	virtual void OnInitialUpdate();

protected:
	virtual void OnDraw(CDC* pDC);

// Implementation
protected:
	virtual ~CStartView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

	afx_msg BOOL OnEraseBkgnd(CDC* pDC);
	afx_msg void OnDisableUpdate(CCmdUI* pCmdUI);
	DECLARE_MESSAGE_MAP()
};
