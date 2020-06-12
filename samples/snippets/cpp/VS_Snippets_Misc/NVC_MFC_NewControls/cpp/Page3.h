// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CCustomEditListBox : public CVSListBox
{
	virtual void OnBrowse()
	{
		int nSel = GetSelItem();

		MessageBox(_T("Browse item..."));

		if (nSel == GetCount()) // New item
		{
			nSel = AddItem(_T("New text"));
			SelectItem(nSel);
		}
		else
		{
			SetItemText(nSel, _T("Updated text"));
		}
	}
};

class CMyBrowseEdit : public CMFCEditBrowseCtrl
{
	virtual void OnBrowse()
	{
		MessageBox(_T("Browse item..."));
		SetWindowText(_T("New value!"));
	}
};

/////////////////////////////////////////////////////////////////////////////
// CPage3 dialog

class CPage3 : public CMFCPropertyPage
{
	DECLARE_DYNCREATE(CPage3)

// Construction
public:
	CPage3();
	~CPage3();

// Dialog Data
	enum { IDD = IDD_PAGE3 };
	CMyBrowseEdit m_wndCustomEdit;

	// <snippet6>
	CMFCEditBrowseCtrl m_wndFolderEdit;
	CMFCEditBrowseCtrl m_wndFileEdit;
	// </snippet6>

	// <snippet34>
	CMFCFontComboBox m_wndFont;
	// </snippet34>

	CStatic m_wndImageArea;
	CMFCButton m_btnImageEdit;
	// <snippet9>
	CMFCLinkCtrl m_btnLink;
	// </snippet9>
	CCustomEditListBox m_wndEditListBox;
	BOOL m_bTrueType;
	BOOL m_bRaster;
	BOOL m_bDeviceFont;
	BOOL m_bDrawUsingFont;

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	afx_msg void OnEditImage();
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg void OnFontType();
	afx_msg void OnDrawUsingFont();

	DECLARE_MESSAGE_MAP()

	CRect m_rectImage;
	CBitmap m_bmpImage;
};
