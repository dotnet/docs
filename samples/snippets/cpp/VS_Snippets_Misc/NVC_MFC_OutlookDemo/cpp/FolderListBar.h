// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

#include "FoldersTree.h"

class CWorkspaceObj;

/////////////////////////////////////////////////////////////////////////////
// CFolderListBar window

class CFolderListBar : public CDockablePane
{
// Construction
public:
	CFolderListBar(const CObList& lstWorkspaces, CImageList& images);

// Attributes
protected:
	CFoldersTree m_wndFolders;
	BOOL m_bNotifyFrame;

// Operations
public:
	BOOL SelectWorkspace(CWorkspaceObj* pWS);
	virtual BOOL CanAcceptPane(const CBasePane* /*pBar*/) const
	{
		return FALSE;
	}
	virtual BOOL DoesAllowDynInsertBefore() const
	{
		return FALSE;
	}

// Overrides
protected:
	virtual void OnEraseWorkArea(CDC* pDC, CRect rectWorkArea);

// Implementation
public:
	virtual ~CFolderListBar();

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnSelectTree(NMHDR* pNMHDR, LRESULT* pResult);

	DECLARE_MESSAGE_MAP()
};


