// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CPropertiesToolBar : public CMFCToolBar
{
public:	
	virtual void OnUpdateCmdUI(CFrameWnd* /*pTarget*/, BOOL bDisableIfNoHndler)	
	{		
		CMFCToolBar::OnUpdateCmdUI ((CFrameWnd*) GetOwner (), bDisableIfNoHndler);
	}

	virtual BOOL AllowShowOnList () const		{	return FALSE;	}
};

class CPropertiesViewBar : public CDockablePane  
{
public:
	CPropertiesViewBar(void);

	void AdjustLayout ();

// Attributes
public:
	void SetVSDotNetLook (BOOL bSet)
	{
		m_wndPropList.SetVSDotNetLook (bSet);
		m_wndPropList.SetGroupNameFullWidth (bSet);
	}

	CMFCPropertyGridCtrl* GetPropList () {return &m_wndPropList;}		

protected:
	CPropertiesToolBar	m_wndToolBar;
	CMFCPropertyGridCtrl		m_wndPropList;

// Attributes
protected:

// Implementation
public:
	virtual ~CPropertiesViewBar();

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnSetFocus(CWnd* pOldWnd);
	afx_msg void OnPropListTreeMode ();
	afx_msg void OnPropListAlphabetMode ();
	afx_msg void OnUpdatePropListTreeMode (CCmdUI* pCmdUI);
	afx_msg void OnUpdatePropListAlphabetMode (CCmdUI* pCmdUI);

	DECLARE_MESSAGE_MAP()
};

