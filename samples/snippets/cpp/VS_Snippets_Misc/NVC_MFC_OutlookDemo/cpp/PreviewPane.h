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
// CPreviewPane view

class CPreviewPane : public CView
{
protected:
	CPreviewPane();           // protected constructor used by dynamic creation
	DECLARE_DYNCREATE(CPreviewPane)

// Overrides
protected:
	virtual void OnDraw(CDC* pDC);      // overridden to draw this view

// Implementation
protected:
	virtual ~CPreviewPane();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg BOOL OnEraseBkgnd(CDC* pDC);

	DECLARE_MESSAGE_MAP()
};
