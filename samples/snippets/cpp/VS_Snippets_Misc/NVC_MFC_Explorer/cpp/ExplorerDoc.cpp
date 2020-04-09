// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "Explorer.h"

#include "ExplorerDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CExplorerDoc

IMPLEMENT_DYNCREATE(CExplorerDoc, CDocument)

BEGIN_MESSAGE_MAP(CExplorerDoc, CDocument)
	ON_COMMAND(ID_COMMAND_HISTORY, OnCommandHistory)
	ON_COMMAND(ID_GO_BACK, OnGoBack)
	ON_COMMAND(ID_GO_FORWARD, OnGoForward)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CExplorerDoc construction/destruction

CExplorerDoc::CExplorerDoc()
{
	// TODO: add one-time construction code here

}

CExplorerDoc::~CExplorerDoc()
{
}

BOOL CExplorerDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CExplorerDoc serialization

void CExplorerDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}

/////////////////////////////////////////////////////////////////////////////
// CExplorerDoc diagnostics

#ifdef _DEBUG
void CExplorerDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CExplorerDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CExplorerDoc commands

void CExplorerDoc::OnCommandHistory() 
{
	// TODO: Add your command handler code here
	
}

void CExplorerDoc::OnGoBack() 
{
	// TODO: Add your command handler code here
	
}

void CExplorerDoc::OnGoForward() 
{
	// TODO: Add your command handler code here
	
}
