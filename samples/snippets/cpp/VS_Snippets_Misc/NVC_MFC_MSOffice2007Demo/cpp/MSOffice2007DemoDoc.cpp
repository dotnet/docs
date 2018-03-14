// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// http://msdn.microsoft.com/officeui.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

#include "stdafx.h"
#include "MSOffice2007Demo.h"

#include "MSOffice2007DemoDoc.h"
#include "CntrItem.h"
#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoDoc

IMPLEMENT_DYNCREATE(CMSOffice2007DemoDoc, CRichEditDoc)

BEGIN_MESSAGE_MAP(CMSOffice2007DemoDoc, CRichEditDoc)
	//{{AFX_MSG_MAP(CMSOffice2007DemoDoc)
	// Enable default OLE container implementation
	ON_UPDATE_COMMAND_UI(ID_OLE_EDIT_LINKS, CRichEditDoc::OnUpdateEditLinksMenu)
	ON_COMMAND(ID_OLE_EDIT_LINKS, CRichEditDoc::OnEditLinks)
	ON_UPDATE_COMMAND_UI_RANGE(ID_OLE_VERB_FIRST, ID_OLE_VERB_LAST, CRichEditDoc::OnUpdateObjectVerbMenu)
	ON_COMMAND(ID_FILE_CLOSE, OnClose)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoDoc construction/destruction

CMSOffice2007DemoDoc::CMSOffice2007DemoDoc()
{
}

CMSOffice2007DemoDoc::~CMSOffice2007DemoDoc()
{
}

BOOL CMSOffice2007DemoDoc::OnNewDocument()
{
	if (!CRichEditDoc::OnNewDocument())
		return FALSE;

	return TRUE;
}

void CMSOffice2007DemoDoc::SetPathName(LPCTSTR lpszPathName, BOOL bAddToMRU)
{
	CRichEditDoc::SetPathName(lpszPathName, bAddToMRU);
}

CRichEditCntrItem* CMSOffice2007DemoDoc::CreateClientItem(REOBJECT* preo) const
{
	// cast away constness of this
	return new CMSOffice2007DemoCntrItem(preo, (CMSOffice2007DemoDoc*) this);
}

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoDoc serialization

void CMSOffice2007DemoDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}

	// Calling the base class CRichEditDoc enables serialization
	//  of the container document's COleClientItem objects.
	// TODO: set CRichEditDoc::m_bRTF = FALSE if you are serializing as text
	CRichEditDoc::Serialize(ar);
}

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoDoc diagnostics

#ifdef _DEBUG
void CMSOffice2007DemoDoc::AssertValid() const
{
	CRichEditDoc::AssertValid();
}

void CMSOffice2007DemoDoc::Dump(CDumpContext& dc) const
{
	CRichEditDoc::Dump(dc);
}
#endif //_DEBUG

void CMSOffice2007DemoDoc::OnClose()
{
}
