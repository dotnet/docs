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

/////////////////////////////////////////////////////////////////////////////
// CCustomSliderCtrl window

class CSliderButton;

class CCustomSliderCtrl : public CSliderCtrl
{
// Construction
public:
	CCustomSliderCtrl(CSliderButton& btnSlider);

// Attributes
public:
	CSliderButton& m_btnSlider;

// Operations
public:
// Overrides

// Implementation
public:
	virtual ~CCustomSliderCtrl();

protected:
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
	afx_msg void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
	afx_msg void OnLButtonUp(UINT nFlags, CPoint point);

	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////
class CSliderButton : public CMFCToolBarButton  
{
	DECLARE_SERIAL(CSliderButton)

public:
	CSliderButton();
	CSliderButton (UINT uiId,
			int iImage = -1,
			DWORD dwStyle = 0,
			int iWidth = 0);

	virtual ~CSliderButton();

	void SetRange (int iMin, int iMax);
	void SetValue (int iValue, BOOL bNotify = TRUE);

	static int GetPos (UINT uiCmd);

// Overrides:
	virtual void Serialize(CArchive& ar);
	virtual void CopyFrom (const CMFCToolBarButton& src);
	virtual SIZE OnCalculateSize (CDC* pDC, const CSize& sizeDefault, BOOL bHorz);
	virtual void OnShow (BOOL bShow);
	virtual void OnChangeParentWnd (CWnd* pWndParent);
	virtual void OnMove ();
	virtual void OnSize (int iSize);
	virtual HWND GetHwnd ()
	{	
		return m_wndSlider.GetSafeHwnd ();
	}

	virtual BOOL CanBeStretched () const
	{	
		return TRUE;	
	}

	virtual BOOL HaveHotBorder () const
	{
		return FALSE;
	}

	virtual void OnDraw (CDC* /*pDC*/, const CRect& /*rect*/, CMFCToolBarImages* /*pImages*/,
						BOOL /*bHorz*/ = TRUE, BOOL /*bCustomizeMode*/ = FALSE,
						BOOL /*bHighlight*/ = FALSE,
						BOOL /*bDrawBorder*/ = TRUE,
						BOOL /*bGrayDisabledButtons*/ = TRUE) {}
// Attributes:
public:
	CCustomSliderCtrl	m_wndSlider;
	int				m_iWidth;
	DWORD			m_dwStyle;
	int				m_nMin;
	int				m_nMax;
	int				m_nValue;
};
