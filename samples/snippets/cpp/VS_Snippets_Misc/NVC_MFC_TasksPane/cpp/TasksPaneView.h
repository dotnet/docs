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

#include "TaskPane.h"

class CTasksPaneView : public CFormView
{
protected: // create from serialization only
	CTasksPaneView();
	DECLARE_DYNCREATE(CTasksPaneView)

public:
	enum { IDD = IDD_TASKSPANE_FORM };
	CMFCColorButton	m_ColorTaskTextHot;
	CMFCColorButton	m_ColorTaskText;
	CMFCColorButton	m_ColorGroupTextHot;
	CMFCColorButton	m_ColorGroupText;

	CSpinButtonCtrl m_VMargin;
	CSpinButtonCtrl m_HMargin;
	CSpinButtonCtrl m_GroupSpacing;
	CSpinButtonCtrl m_TaskSpacing;
	CSpinButtonCtrl m_CaptionHeight;
	CSpinButtonCtrl m_TaskOffset;
	CSpinButtonCtrl m_IconOffset;

	int		m_nVisualManager;

	BOOL	m_bWrapTasks;
	BOOL	m_bWrapLabels;
	BOOL	m_bNavToolbar;
	BOOL	m_bMenuButtons;
	BOOL	m_bHicolorImages;
	BOOL	m_bCollapseGroups;
	BOOL	m_bCustomizeMargins;
	BOOL	m_bScrollButtons;
	BOOL	m_bAnimation;
	BOOL	m_bCaptionIcon;

	// <snippet1>
	int		m_nVMargin;
	int		m_nHMargin;
	int		m_nGroupSpacing;
	int		m_nTaskSpacing;
	int		m_nCaptionHeight;
	int		m_nTaskOffset;
	int		m_nIconOffset;
	// </snippet1>

// Attributes
public:
	CTasksPaneDoc* GetDocument();
	CTaskPane* GetTasksPane();

// Operations
public:

// Overrides
	public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual void OnInitialUpdate(); // called first time after construct
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnPrint(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CTasksPaneView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg void OnVisualManager();
	afx_msg void OnWraptasks();
	afx_msg void OnWraplabels();
	afx_msg void OnNavtoolbar();
	afx_msg void OnHistbuttons();
	afx_msg void OnHicolorimages();
	afx_msg void OnDestroy();
	afx_msg void OnScrollbuttons();
	afx_msg void OnAnimation();
	afx_msg void OnCollapsegroups();
	afx_msg void OnMargins();
	afx_msg void OnColorGrouptext();
	afx_msg void OnColorGrouptexthot();
	afx_msg void OnColorTasktext();
	afx_msg void OnColorTasktexthot();
	afx_msg void OnChangeMargins();
	afx_msg void OnCaptionicon();
	afx_msg void OnContextMenu(CWnd*, CPoint point);
	afx_msg void OnFilePrintPreview();

	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in TasksPaneView.cpp
inline CTasksPaneDoc* CTasksPaneView::GetDocument()
   { return (CTasksPaneDoc*)m_pDocument; }
#endif
