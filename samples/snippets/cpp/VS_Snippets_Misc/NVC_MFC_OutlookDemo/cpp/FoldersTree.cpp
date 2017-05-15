// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "OutlookDemo.h"
#include "FoldersTree.h"
#include "WorkspaceObj.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CFoldersTree

CFoldersTree::CFoldersTree(const CObList& lstWorkspaces, CImageList& images) : m_lstWorkspaces(lstWorkspaces), m_images(images)
{
}

CFoldersTree::~CFoldersTree()
{
}

BEGIN_MESSAGE_MAP(CFoldersTree, CTreeCtrl)
	ON_WM_CREATE()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CFoldersTree message handlers

BOOL CFoldersTree::PreCreateWindow(CREATESTRUCT& cs)
{
	cs.style |= WS_CHILD | WS_VISIBLE | WS_HSCROLL | WS_VSCROLL | TVS_HASLINES | TVS_HASBUTTONS | TVS_DISABLEDRAGDROP | TVS_LINESATROOT | TVS_SHOWSELALWAYS;
	return CTreeCtrl::PreCreateWindow(cs);
}

int CFoldersTree::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CTreeCtrl::OnCreate(lpCreateStruct) == -1)
		return -1;

	SetImageList(&m_images, TVSIL_NORMAL);

	// Fill folders tree:
	HTREEITEM htreeRoot = NULL;

	for (POSITION pos = m_lstWorkspaces.GetHeadPosition(); pos != NULL;)
	{
		CWorkspaceObj* pWS = (CWorkspaceObj*) m_lstWorkspaces.GetNext(pos);
		ASSERT_VALID(pWS);

		HTREEITEM hItem = InsertItem(pWS->m_strName, pWS->m_iIconIndex, pWS->m_iIconIndex);
		SetItemData(hItem, (DWORD_PTR) pWS);

		m_Items.SetAt(pWS, hItem);

		if (htreeRoot == NULL)
		{
			htreeRoot = hItem;
		}
	}

	if (htreeRoot)
	{
		Expand(htreeRoot, TVE_EXPAND);
	}

	return 0;
}

BOOL CFoldersTree::SelectWorkspace(CWorkspaceObj* pWS)
{
	ASSERT_VALID(pWS);

	HTREEITEM hItem;
	if (!m_Items.Lookup(pWS, hItem))
	{
		ASSERT(FALSE);
		return FALSE;
	}

	SelectItem(hItem);
	EnsureVisible(hItem);
	return TRUE;
}
