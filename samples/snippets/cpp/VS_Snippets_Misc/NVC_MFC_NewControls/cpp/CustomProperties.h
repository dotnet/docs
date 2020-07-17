// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CCheckBoxProp : public CMFCPropertyGridProperty
{
public:
	CCheckBoxProp(const CString& strName, BOOL bCheck, LPCTSTR lpszDescr = NULL, DWORD dwData = 0);

protected:
	virtual BOOL OnEdit(LPPOINT /*lptClick*/) { return FALSE; }
	virtual void OnDrawButton(CDC* /*pDC*/, CRect /*rectButton*/) {}
	virtual void OnDrawValue(CDC* /*pDC*/, CRect /*rect*/) {}
	virtual BOOL HasButton() const { return FALSE; }

	virtual BOOL PushChar(UINT nChar);
	virtual void OnDrawCheckBox(CDC * pDC, CRect rectCheck, BOOL bChecked);
	virtual void OnDrawName(CDC* pDC, CRect rect);
	virtual void OnClickName(CPoint point);
	virtual BOOL OnDblClk(CPoint point);

protected:
	CRect m_rectCheck;
};

class CPasswordProp : public CMFCPropertyGridProperty
{
public:
	CPasswordProp(const CString& strName, const CString& strPassword, LPCTSTR lpszDescr = NULL, DWORD dwData = 0);

protected:
	virtual CWnd* CreateInPlaceEdit(CRect rectEdit, BOOL& bDefaultFormat);
	virtual CString FormatProperty();
};

class CSliderProp : public CMFCPropertyGridProperty
{
public:
	CSliderProp(const CString& strName, long nValue, LPCTSTR lpszDescr = NULL, DWORD dwData = 0);

	virtual BOOL OnUpdateValue();

protected:
	virtual CWnd* CreateInPlaceEdit(CRect rectEdit, BOOL& bDefaultFormat);
	virtual BOOL OnSetCursor() const { return FALSE; /* Use default */ }
};

class CBoundedNumberPairProp : public CMFCPropertyGridProperty
{
public:
	CBoundedNumberPairProp(const CString& strGroupName, int nMinValue1, int nMaxValue1, int nMinValue2, int nMaxValue2, DWORD_PTR dwData = 0, BOOL bIsValueList = FALSE);

	virtual BOOL OnUpdateValue();

private:
	int m_nMinValue1;
	int m_nMaxValue1;
	int m_nMinValue2;
	int m_nMaxValue2;
};

class CBoundedNumberSubProp : public CMFCPropertyGridProperty
{
public:
	CBoundedNumberSubProp(const CString& strName, const COleVariant& varValue, int nMinValue, int nMaxValue, LPCTSTR lpszDescr = NULL);

	virtual BOOL OnUpdateValue();
private:
	int m_nMinValue;
	int m_nMaxValue;
};

/////////////////////////////////////////////////////////////////////////////
// CPropSliderCtrl window

class CPropSliderCtrl : public CSliderCtrl
{
// Construction
public:
	CPropSliderCtrl(CSliderProp* pProp, COLORREF clrBack);

// Attributes
protected:
	CBrush m_brBackground;
	COLORREF m_clrBack;
	CSliderProp* m_pProp;

// Implementation
public:
	virtual ~CPropSliderCtrl();

protected:
	//{{AFX_MSG(CPropSliderCtrl)
	afx_msg HBRUSH CtlColor(CDC* pDC, UINT nCtlColor);
	//}}AFX_MSG
	afx_msg void HScroll(UINT nSBCode, UINT nPos);

	DECLARE_MESSAGE_MAP()
};

class CIconListProp : public CMFCPropertyGridProperty
{
public:
	CIconListProp(const CString& strName, const CImageList& imageListIcons, int nSelectedIcon, CStringList* plstIconNames = NULL, LPCTSTR lpszDescr = NULL, DWORD dwData = 0);

protected:
	virtual CWnd* CreateInPlaceEdit(CRect rectEdit, BOOL& bDefaultFormat);
	virtual CComboBox* CreateCombo(CWnd* pWndParent, CRect rect);
	virtual void OnDrawValue(CDC* pDC, CRect rect);

	CMFCToolBarImages m_imageListIcons;
	CStringList m_lstIconNames;
};

/////////////////////////////////////////////////////////////////////////////
// CIconCombo window

class CIconCombo : public CComboBox
{
// Construction
public:
	CIconCombo(CMFCToolBarImages& imageListIcons, CStringList& lstIconNames);

// Attributes
protected:
	CMFCToolBarImages& m_imageListIcons;
	CStringList& m_lstIconNames;

// Implementation
public:
	virtual ~CIconCombo();

protected:
	//{{AFX_MSG(CIconCombo)
	afx_msg void OnDrawItem(int nIDCtl, LPDRAWITEMSTRUCT lpDrawItemStruct);
	afx_msg void OnMeasureItem(int nIDCtl, LPMEASUREITEMSTRUCT lpMeasureItemStruct);
	//}}AFX_MSG

	DECLARE_MESSAGE_MAP()
};

class CComboBoxExProp : public CMFCPropertyGridProperty
{
public:
	CComboBoxExProp(const CString& strName, const CString& strValue, LPCTSTR lpszDescr = NULL, DWORD dwData = 0, CImageList* pImageList = NULL);

	BOOL AddOption(LPCTSTR lpszOption, int nIcon = -1, int nIndent = 0);

protected:
	virtual CComboBox* CreateCombo(CWnd* pWndParent, CRect rect);
	virtual BOOL OnEdit(LPPOINT lptClick);

	CImageList* m_pImageList;
	CArray<int, int> m_lstIcons;
	CArray<int, int> m_lstIndents;
};

class COwnerDrawDescrProp : public CMFCPropertyGridProperty
{
public:
	COwnerDrawDescrProp(const CString& strName, const COleVariant& varValue);

protected:
	virtual void OnDrawDescription(CDC* pDC, CRect rect);
};

class CTwoButtonsProp : public CMFCPropertyGridProperty
{
public:
	CTwoButtonsProp(const CString& strName, const COleVariant& varValue);

protected:
	virtual BOOL HasButton() const { return TRUE; }
	virtual void AdjustButtonRect();
	virtual void OnClickButton(CPoint point);
	virtual void OnDrawButton(CDC* pDC, CRect rectButton);

	CImageList m_images;
};

class CCustomDlgProp : public CMFCPropertyGridProperty
{
public:
	CCustomDlgProp(const CString& strName, const COleVariant& varValue);

protected:
	virtual BOOL HasButton() const { return TRUE; }
	virtual void OnClickButton(CPoint point);
};


