// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// http://msdn.microsoft.com/officeui.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

#pragma once

class CMSOffice2007DemoCntrItem;
struct CCharFormat;

class CMSOffice2007DemoView : public CRichEditView
{
protected: // create from serialization only
	CMSOffice2007DemoView();
	DECLARE_DYNCREATE(CMSOffice2007DemoView)

// Attributes
public:
	CMSOffice2007DemoDoc* GetDocument();
	static BOOL m_bForceReloadBmps;

// Overrides
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual void OnInitialUpdate(); // called first time after construct
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);

	virtual void SyncFont();

// Implementation
public:
	virtual ~CMSOffice2007DemoView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	//{{AFX_MSG(CMSOffice2007DemoView)
	afx_msg void OnDestroy();
	afx_msg void OnLButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnFontDialog();
	afx_msg void OnParagraphDialog();
	afx_msg void OnStyleDialog();
	afx_msg void OnPagesetupDialog();
	afx_msg void OnRButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnContextMenu(CWnd* pWnd, CPoint point);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnPrepareDC(CDC* pDC, CPrintInfo* pInfo);
	afx_msg void OnEditUndo();
	afx_msg void OnUpdateEditFind(CCmdUI* pCmdUI);
	afx_msg void OnUpdateEditReplace(CCmdUI* pCmdUI);
	afx_msg void OnPagelayoutIndentLeft();
	afx_msg void OnPagelayoutIndentRight();
	afx_msg void OnFilePrintPreview();
	afx_msg void OnFontColor();
	afx_msg void OnFontname();
	afx_msg void OnFontsize();
	afx_msg void OnEditChange();
	afx_msg void OnInsertPicture();
	afx_msg void OnInsertChart();
	afx_msg void OnInsertTable();
	afx_msg void OnSelChange(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnUpdatePrintLayout(CCmdUI* pCmdUI);
	afx_msg void OnIndentLeft();
	afx_msg void OnIndentRight();
	afx_msg void OnSpaceAfter();
	afx_msg void OnSpaceBefore();
	afx_msg void OnViewRuler();
	afx_msg void OnViewGridLines();
	afx_msg void OnViewProps();
	afx_msg void OnViewDocMap();
	afx_msg void OnUpdateViewRuler(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewGridLines(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewProps(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewDocMap(CCmdUI* pCmdUI);
	afx_msg void OnUpdateViewThumb(CCmdUI* pCmdUI);
	afx_msg void OnInsertBulletFromPalette();
	afx_msg void OnInsertNumberFromPalette();
	afx_msg void OnInsertMultilevelFromPalette();
	afx_msg void OnCharStrikeThrough();
	afx_msg void OnUpdateCharStrikeThrough(CCmdUI* pCmdUI);
	afx_msg void OnInsertTableGallery();
	afx_msg void OnInsertShape();
	afx_msg void OnQuickStyle();
	afx_msg void OnPageLayoutTheme();
	//}}AFX_MSG

	DECLARE_MESSAGE_MAP()

	BOOL ShowContextMenu(CPoint pt);
	void GetDefaultFont(CCharFormat& cf);
	BOOL InsertBitmap(UINT uiBmpResID);

	void InitFloaty(CMFCRibbonMiniToolBar* pFloaty);

protected:
	BOOL m_bIsEndOfPrint;
	BOOL m_bViewRuler;
	BOOL m_bViewGridLines;
	BOOL m_bViewProps;
	BOOL m_bViewDocMap;
	BOOL m_bViewThumb;
};

#ifndef _DEBUG  // debug version in MSOffice2007DemoView.cpp
inline CMSOffice2007DemoDoc* CMSOffice2007DemoView::GetDocument() { return(CMSOffice2007DemoDoc*)m_pDocument; }
#endif

