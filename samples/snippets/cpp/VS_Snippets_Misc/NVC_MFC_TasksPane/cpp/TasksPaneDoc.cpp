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
#include "TasksPane.h"

#include "TasksPaneDoc.h"
#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTasksPaneDoc

IMPLEMENT_DYNCREATE(CTasksPaneDoc, CDocument)

BEGIN_MESSAGE_MAP(CTasksPaneDoc, CDocument)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTasksPaneDoc construction/destruction

CTasksPaneDoc::CTasksPaneDoc()
{
	// TODO: add one-time construction code here

}

CTasksPaneDoc::~CTasksPaneDoc()
{
}

BOOL CTasksPaneDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}

void CTasksPaneDoc::SetPathName(LPCTSTR lpszPathName, BOOL bAddToMRU) 
{
	CDocument::SetPathName(lpszPathName, bAddToMRU);

	((CMainFrame*) AfxGetMainWnd ())->UpdateMRUFilesList ();
}



/////////////////////////////////////////////////////////////////////////////
// CTasksPaneDoc serialization

void CTasksPaneDoc::Serialize(CArchive& ar)
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
// CTasksPaneDoc diagnostics

#ifdef _DEBUG
void CTasksPaneDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CTasksPaneDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CTasksPaneDoc commands
