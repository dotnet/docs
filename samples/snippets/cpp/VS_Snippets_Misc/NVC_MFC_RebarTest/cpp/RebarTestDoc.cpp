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
#include "RebarTest.h"

#include "RebarTestDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CRebarTestDoc

IMPLEMENT_DYNCREATE(CRebarTestDoc, CDocument)

BEGIN_MESSAGE_MAP(CRebarTestDoc, CDocument)
END_MESSAGE_MAP()


// CRebarTestDoc construction/destruction

CRebarTestDoc::CRebarTestDoc()
{
	// TODO: add one-time construction code here

}

CRebarTestDoc::~CRebarTestDoc()
{
}

BOOL CRebarTestDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}




// CRebarTestDoc serialization

void CRebarTestDoc::Serialize(CArchive& ar)
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


// CRebarTestDoc diagnostics

#ifdef _DEBUG
void CRebarTestDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CRebarTestDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CRebarTestDoc commands
