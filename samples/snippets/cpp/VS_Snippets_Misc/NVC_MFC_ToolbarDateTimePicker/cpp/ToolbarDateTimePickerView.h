// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#if !defined(AFX_TOOLBARDATETIMEPICKERVIEW_H__2921CCF1_7FF3_4E5E_A361_E8FF8F313192__INCLUDED_)
#define AFX_TOOLBARDATETIMEPICKERVIEW_H__2921CCF1_7FF3_4E5E_A361_E8FF8F313192__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CToolbarDateTimePickerView : public CView
{
protected: // create from serialization only
	CToolbarDateTimePickerView();
	DECLARE_DYNCREATE(CToolbarDateTimePickerView)

// Attributes
public:
	CToolbarDateTimePickerDoc* GetDocument();

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CToolbarDateTimePickerView)
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CToolbarDateTimePickerView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CToolbarDateTimePickerView)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	afx_msg void OnContextMenu(CWnd*, CPoint point);
	afx_msg void OnFilePrintPreview();
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in ToolbarDateTimePickerView.cpp
inline CToolbarDateTimePickerDoc* CToolbarDateTimePickerView::GetDocument()
   { return (CToolbarDateTimePickerDoc*)m_pDocument; }
#endif

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TOOLBARDATETIMEPICKERVIEW_H__2921CCF1_7FF3_4E5E_A361_E8FF8F313192__INCLUDED_)
