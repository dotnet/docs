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
#include "StatusBarDemo.h"

#include "StatusBarDemoDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CStatusBarDemoDoc

IMPLEMENT_DYNCREATE(CStatusBarDemoDoc, CDocument)

BEGIN_MESSAGE_MAP(CStatusBarDemoDoc, CDocument)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CStatusBarDemoDoc construction/destruction

CStatusBarDemoDoc::CStatusBarDemoDoc()
{
	// TODO: add one-time construction code here

}

CStatusBarDemoDoc::~CStatusBarDemoDoc()
{
}

BOOL CStatusBarDemoDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CStatusBarDemoDoc serialization

void CStatusBarDemoDoc::Serialize(CArchive& ar)
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
// CStatusBarDemoDoc diagnostics

#ifdef _DEBUG
void CStatusBarDemoDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CStatusBarDemoDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CStatusBarDemoDoc commands
