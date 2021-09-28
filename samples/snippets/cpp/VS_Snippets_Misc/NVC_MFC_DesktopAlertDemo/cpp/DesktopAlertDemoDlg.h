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

#include "IconComboBox.h"

/////////////////////////////////////////////////////////////////////////////
// CDesktopAlertDemoDlg dialog

class CDesktopAlertDemoDlg : public CDialogEx
{
// Construction
public:
	CDesktopAlertDemoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	// <snippet2>
	enum { IDD = IDD_ALERT_DIALOG };
	CSliderCtrl	m_wndAutoCloseTime;
	CEdit	m_wndText;
	CEdit	m_wndLink;
	CStatic	m_wndLabel3;
	CStatic	m_wndLabel2;
	CStatic	m_wndLabel1;
	CIconComboBox	m_wndIcons;
	CSliderCtrl	m_wndTransparency;
	CSliderCtrl	m_wndANimationSpeed;
	int		m_nVisualMngr;
	int		m_nAnimation;
	int		m_nAnimationSpeed;
	CString	m_strAnimSpeed;
	int		m_nTransparency;
	CString	m_strTransparency;
	BOOL	m_bSmallCaption;
	int		m_nPopupSource;
	int		m_nIcon;
	CString	m_strLink;
	CString	m_strText;
	int		m_nAutoCloseTime;
	CString	m_strAutoClose;
	BOOL	m_bAutoClose;
	// </snippet2>

	// ClassWizard generated virtual function overrides
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

// Implementation
protected:
	HICON				m_hIcon;
	CMenu				m_menuPopup;
	CPoint				m_ptPopup;
	CMFCToolBarImages	m_Icons;
	CMFCToolBarImages	m_IconsSmall;

	virtual BOOL OnInitDialog();

	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnShow();
	afx_msg void OnSelchangeVisualMngr();
	afx_msg void OnSelchangeAnimation();
	afx_msg void OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar);
	afx_msg void OnSmallCaption();
	afx_msg void OnPopupSource();
	afx_msg void OnAutoClose();
	afx_msg LRESULT OnClosePopup(WPARAM,LPARAM);

	DECLARE_MESSAGE_MAP()

	void EnableControls (BOOL bEnable = TRUE);
	void EnableSourceControls ();
};
