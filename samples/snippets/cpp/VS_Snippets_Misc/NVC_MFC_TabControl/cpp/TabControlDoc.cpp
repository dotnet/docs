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
#include "TabControl.h"

#include "TabControlDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTabControlDoc

IMPLEMENT_DYNCREATE(CTabControlDoc, CDocument)

BEGIN_MESSAGE_MAP(CTabControlDoc, CDocument)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTabControlDoc construction/destruction

CTabControlDoc::CTabControlDoc()
{
	// TODO: add one-time construction code here

}

CTabControlDoc::~CTabControlDoc()
{
}

BOOL CTabControlDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CTabControlDoc serialization

void CTabControlDoc::Serialize(CArchive& ar)
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
// CTabControlDoc diagnostics

#ifdef _DEBUG
void CTabControlDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CTabControlDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CTabControlDoc commands
