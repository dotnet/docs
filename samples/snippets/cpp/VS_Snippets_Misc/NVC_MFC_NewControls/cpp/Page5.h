// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CMyListCtrl : public CMFCListCtrl
{
	virtual COLORREF OnGetCellTextColor(int nRow, int nColum);
	virtual COLORREF OnGetCellBkColor(int nRow, int nColum);
	virtual HFONT OnGetCellFont(int nRow, int nColum, DWORD dwData = 0);

	virtual int OnCompareItems(LPARAM lParam1, LPARAM lParam2, int iColumn);

public:
	BOOL m_bColor;
	BOOL m_bModifyFont;
};

/////////////////////////////////////////////////////////////////////////////
// CPage5 dialog

class CPage5 : public CMFCPropertyPage
{
	friend class CMyListCtrl;

	DECLARE_DYNCREATE(CPage5)

// Construction
public:
	CPage5();
	~CPage5();

// Dialog Data
	enum { IDD = IDD_PAGE5 };
	CButton m_btnExpandAll;
	CStatic m_wndPropListLocation;
	CMyListCtrl m_wndList;
	BOOL m_bDescrArea;
	BOOL m_bDotNetLook;
	BOOL m_bHeader;
	BOOL m_bMarkSortedColumn;
	BOOL m_bColor;
	BOOL m_bModifyFont;
	BOOL m_bPropListCustomColors;
	BOOL m_bPropListCategorized;
	BOOL m_bShowDragContext;
	BOOL m_bMarkChanged;
	BOOL m_bHideFontProps;

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	virtual BOOL OnInitDialog();

	afx_msg void OnHeader();
	afx_msg void OnDotNetLook();
	afx_msg void OnDescriptionArea();
	afx_msg void OnMarkSortedColumn();
	afx_msg void OnColorRows();
	afx_msg void OnModifyFont();
	afx_msg void OnPropListCustomColors();
	afx_msg void OnProplistExpandAll();
	afx_msg void OnProplistCategorized();
	afx_msg void OnProplistCategorized2();
	afx_msg void OnResetValues();
	afx_msg void OnMarkChanged();
	afx_msg void OnHideFontProps();

	DECLARE_MESSAGE_MAP()
	// <snippet14>
	CMFCPropertyGridCtrl m_wndPropList;
	// </snippet14>
	CImageList m_imageList;

	CMFCPropertyGridProperty* pGroupFont;
};

