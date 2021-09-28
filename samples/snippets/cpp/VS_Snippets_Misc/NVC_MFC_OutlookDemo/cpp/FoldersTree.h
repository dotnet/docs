// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CWorkspaceObj;

/////////////////////////////////////////////////////////////////////////////
// CFoldersTree window

class CFoldersTree : public CTreeCtrl
{
// Construction
public:
	CFoldersTree(const CObList& lstWorkspaces, CImageList& images);

// Attributes
protected:
	CTreeCtrl m_wndFolders;
	const CObList& m_lstWorkspaces;
	CImageList& m_images;

	CMap<CWorkspaceObj*, CWorkspaceObj*, HTREEITEM, HTREEITEM> m_Items;

// Operations
public:
	BOOL SelectWorkspace(CWorkspaceObj* pWS);

// Overrides
protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

// Implementation
public:
	virtual ~CFoldersTree();

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);

	DECLARE_MESSAGE_MAP()
};
