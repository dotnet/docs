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
// CPage1 dialog

class CPage1 : public CMFCPropertyPage
{
	DECLARE_DYNCREATE(CPage1)

// Construction
public:
	CPage1();
	~CPage1();

// Dialog Data
	enum { IDD = IDD_PAGE1 };
	CMFCButton m_btnMultiLine;
	CComboBox m_wndBorder;
	CStatic m_wndBorderLabel;
	CMFCButton m_btnCheck;
	CButton m_wndXPButtons;
	BOOL m_bXPButtons;
	BOOL m_bCheck;

	// <snippet28>
	CMFCButton m_Button;
	// </snippet28>
	CString m_strToolTip;
	CEdit m_wndToolTip;
	int m_iFrameRate;
	int m_iImage;
	int m_iBorderStyle;
	int m_iCursor;
	// <snippet38>
	CMFCMenuButton m_btnMenu;
	// </snippet38>
	BOOL m_bMenuStayPressed;
	BOOL m_bRightArrow;
	int m_nImageLocation;
	BOOL m_bMenuDefaultClick;
	

	CMFCButton m_btnRadio1;
	CMFCButton m_btnRadio2;
	CMFCButton m_btnRadio3;
	CMFCButton m_btnRadio4;

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	virtual BOOL OnInitDialog();

	afx_msg void OnXpButtons();
	afx_msg void OnSetTooltip();
	afx_msg void OnSetCursor();
	afx_msg void OnButton();
	afx_msg void OnRightArrow();
	afx_msg void OnButtonMenu();
	afx_msg void OnPressedOnMenu();
	afx_msg void OnDialogAbout();
	afx_msg void OnUpdateItem2(CCmdUI* pCmdUI);
	afx_msg void OnResetButton();
	afx_msg void OnMenuDefaultClick();

	DECLARE_MESSAGE_MAP()

	CMenu m_menu;
};

