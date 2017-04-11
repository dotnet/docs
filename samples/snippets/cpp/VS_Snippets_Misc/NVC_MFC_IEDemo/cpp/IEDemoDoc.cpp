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
#include "IEDemo.h"

#include "IEDemoDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CIEDemoDoc

IMPLEMENT_DYNCREATE(CIEDemoDoc, CDocument)

BEGIN_MESSAGE_MAP(CIEDemoDoc, CDocument)
	//{{AFX_MSG_MAP(CIEDemoDoc)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CIEDemoDoc construction/destruction

CIEDemoDoc::CIEDemoDoc()
{
	m_iHistoryOffset = 0;
	m_arHistory.SetSize (0, 1);
}

CIEDemoDoc::~CIEDemoDoc()
{
	for (int i = 0; i < m_arHistory.GetSize (); i ++)
	{
		ASSERT (m_arHistory [i] != NULL);
		delete m_arHistory [i];
	}
}

BOOL CIEDemoDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CIEDemoDoc serialization

void CIEDemoDoc::Serialize(CArchive& ar)
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
// CIEDemoDoc diagnostics

#ifdef _DEBUG
void CIEDemoDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CIEDemoDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CIEDemoDoc commands

CHistoryObj* CIEDemoDoc::AddURLToHistory (const CString& strTitle, const CString& strURL)
{
	ASSERT (m_arHistory.GetSize () <= HISTORY_LEN);

	for (int i = 0; i < m_arHistory.GetSize (); i ++)
	{
		CHistoryObj* pObj = m_arHistory [i];
		ASSERT (pObj != NULL);

		if (pObj && pObj->GetTitle () == strTitle && pObj->GetURL () == strURL)
		{
			return pObj;
		}
	}

	if (m_arHistory.GetSize () == HISTORY_LEN)
	{
		delete m_arHistory [0];
		m_arHistory.RemoveAt (0);
	}

	CHistoryObj* pObj = new CHistoryObj (strTitle, strURL, 
		FIRST_HISTORY_COMMAND + (UINT)m_arHistory.GetSize ());
	m_arHistory.InsertAt (0, pObj);

	m_iHistoryOffset = 0;
	return pObj;
}
//****************************************************************************************
void CIEDemoDoc::GetBackList (_T_HistotyList& lst) const
{
	lst.RemoveAll ();
	for (int i = m_iHistoryOffset + 1; i < m_arHistory.GetSize () ; i ++)
	{
		lst.AddTail (m_arHistory [i]);
	}
}
//****************************************************************************************
void CIEDemoDoc::GetFrwdList (_T_HistotyList& lst) const
{
	lst.RemoveAll ();
	for (int i = m_iHistoryOffset - 1; i >= 0; i --)
	{
		ASSERT (i < m_arHistory.GetSize ());
		lst.AddTail (m_arHistory [i]);
	}
}
//****************************************************************************************
CHistoryObj* CIEDemoDoc::Go (UINT uiCmd)
{
	for (int i = 0; i < m_arHistory.GetSize (); i ++)
	{
		CHistoryObj* pObj = m_arHistory [i];
		ASSERT (pObj != NULL);

		if (pObj && pObj->GetCommand () == uiCmd)
		{
			m_arHistory.RemoveAt (i);
			m_arHistory.Add (pObj);

			m_iHistoryOffset = 0;
			return pObj;
		}
	}

	return NULL;
}
