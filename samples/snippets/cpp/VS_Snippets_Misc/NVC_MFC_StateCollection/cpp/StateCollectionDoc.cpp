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
#include "StateCollection.h"

#include "StateCollectionDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CStateCollectionDoc

IMPLEMENT_DYNCREATE(CStateCollectionDoc, CDocument)

BEGIN_MESSAGE_MAP(CStateCollectionDoc, CDocument)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CStateCollectionDoc construction/destruction

CStateCollectionDoc::CStateCollectionDoc()
{
	// TODO: add one-time construction code here

}

CStateCollectionDoc::~CStateCollectionDoc()
{
}

BOOL CStateCollectionDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CStateCollectionDoc serialization

void CStateCollectionDoc::Serialize(CArchive& ar)
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
// CStateCollectionDoc diagnostics

#ifdef _DEBUG
void CStateCollectionDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CStateCollectionDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CStateCollectionDoc commands
