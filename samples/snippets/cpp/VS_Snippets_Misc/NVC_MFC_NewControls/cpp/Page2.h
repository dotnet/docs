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
// CPage2 dialog

class CPage2 : public CMFCPropertyPage
{
	DECLARE_DYNCREATE(CPage2)

// Construction
public:
	CPage2();
	~CPage2();

// Dialog Data
	enum { IDD = IDD_PAGE2 };

	// <snippet4>
	CMFCColorPickerCtrl m_wndLum;
	// </snippet4>

	CMFCColorPickerCtrl m_wndColorPalette;
	CStatic m_wndColorBarFrame2;
	CStatic m_wndColorBarFrame;
	CMFCColorButton m_ColorPicker;
	CString m_strRGB;
	CString m_strRGBColorBar;
	CString m_strRGBColorBar2;
	CString m_strRGBColorDialog;
	CString m_strRGBColorPalette;

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	virtual BOOL OnInitDialog();

	afx_msg void OnColorDlg();
	afx_msg void OnColorPicker();
	afx_msg void OnColorPalette();
	afx_msg void OnLum();
	afx_msg void OnColorBar();
	afx_msg void OnColorBar2();

	DECLARE_MESSAGE_MAP()

	COLORREF m_Color;

	// <snippet1>
	CMFCColorBar m_wndColorBar;
	// </snippet1>

	CMFCColorBar m_wndColorBar2;

	CPalette m_palColorPicker;
	CPalette m_palSys;
};

