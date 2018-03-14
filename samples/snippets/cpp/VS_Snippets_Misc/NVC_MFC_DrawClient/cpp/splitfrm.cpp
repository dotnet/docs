// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "DrawClient.h"
#include "splitfrm.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CSplitFrame

IMPLEMENT_DYNCREATE(CSplitFrame, CMDIChildWndEx)

CSplitFrame::CSplitFrame()
{
}

CSplitFrame::~CSplitFrame()
{
}

BOOL CSplitFrame::OnCreateClient(LPCREATESTRUCT /*lpcs*/, CCreateContext* pContext)
{
	return m_wndSplitter.Create(this, 2, 2, CSize(10, 10), pContext);
}

BEGIN_MESSAGE_MAP(CSplitFrame, CMDIChildWndEx)
	//{{AFX_MSG_MAP(CSplitFrame)
	ON_COMMAND(ID_FILE_PRINT, OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
	ON_UPDATE_COMMAND_UI(ID_FILE_PRINT_PREVIEW, OnUpdateFilePrintPreview)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

void CSplitFrame::OnFilePrint ()
{
	if (m_dockManager.IsPrintPreviewValid ())
	{
		PostMessage (WM_COMMAND, AFX_ID_PREVIEW_PRINT);
	}
}

void CSplitFrame::OnFilePrintPreview()
{
	if (m_dockManager.IsPrintPreviewValid ())
	{
		PostMessage (WM_COMMAND, AFX_ID_PREVIEW_CLOSE);      // Force Print Preview Close
	}
}

void CSplitFrame::OnUpdateFilePrintPreview(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_dockManager.IsPrintPreviewValid ());
}

