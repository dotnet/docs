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

#include "OutlookDemoDoc.h"
#include "MailFrame.h"
#include "MailView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// COutlookDemoDoc

IMPLEMENT_DYNCREATE(COutlookDemoDoc, CDocument)

BEGIN_MESSAGE_MAP(COutlookDemoDoc, CDocument)
	ON_COMMAND(ID_NEW_APPOINTMENT, OnNewAppointment)
	ON_COMMAND(ID_NEW_CONTRACT, OnNewContract)
	ON_COMMAND(ID_NEW_DISTRIBUTION_LIST, OnNewDistributionList)
	ON_COMMAND(ID_NEW_FAX, OnNewFax)
	ON_COMMAND(ID_NEW_FOLDER, OnNewFolder)
	ON_COMMAND(ID_NEW_JOURNAL_ENTRY, OnNewJournalEntry)
	ON_COMMAND(ID_NEW_MAIL, OnNewMail)
	ON_COMMAND(ID_NEW_MEETING, OnNewMeeting)
	ON_COMMAND(ID_NEW_NOTE, OnNewNote)
	ON_COMMAND(ID_NEW_POST_FOLDER, OnNewPostFolder)
	ON_COMMAND(ID_NEW_SHORTCUT, OnNewShortcut)
	ON_COMMAND(ID_NEW_TASK, OnNewTask)
	ON_COMMAND(ID_NEW_TASK_REQUEST, OnNewTaskRequest)
	ON_COMMAND(ID_SEND_RECEIVE, OnSendReceive)
	ON_COMMAND(ID_ADDRESS_BOOK, OnAddressBook)
	ON_COMMAND(ID_FIND_CONTACT, OnFindContact)
	ON_COMMAND(ID_WEB_ADDRESS, OnWebAddress)
	ON_COMMAND(ID_WEB_BACK, OnWebBack)
	ON_COMMAND(ID_WEB_FIND, OnWebFind)
	ON_COMMAND(ID_WEB_REFRESH, OnWebRefresh)
	ON_COMMAND(ID_WEB_START, OnWebStart)
	ON_COMMAND(ID_VIEW_UP, OnViewUp)
	ON_COMMAND(ID_VIEW_BACK, OnViewBack)
	ON_COMMAND(ID_RULES_WIZARD, OnRulesWizard)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COutlookDemoDoc construction/destruction

COutlookDemoDoc::COutlookDemoDoc()
{
	// TODO: add one-time construction code here

}

COutlookDemoDoc::~COutlookDemoDoc()
{
}

BOOL COutlookDemoDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	//(SDI documents will reuse this document)

	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// COutlookDemoDoc serialization

void COutlookDemoDoc::Serialize(CArchive& ar)
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
// COutlookDemoDoc diagnostics

#ifdef _DEBUG
void COutlookDemoDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void COutlookDemoDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// COutlookDemoDoc commands

void COutlookDemoDoc::OnNewAppointment()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewContract()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewDistributionList()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewFax()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewFolder()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewJournalEntry()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewMeeting()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewNote()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewPostFolder()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewShortcut()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewTask()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewTaskRequest()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnSendReceive()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnAddressBook()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnFindContact()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnWebAddress()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnWebBack()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnWebFind()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnWebRefresh()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnWebStart()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnViewUp()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnViewBack()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnRulesWizard()
{
	// TODO: Add your command handler code here

}

void COutlookDemoDoc::OnNewMail()
{
	theApp.SaveState();

	CMailFrame* pMailFrame = new CMailFrame;

	CCreateContext context;

	context.m_pCurrentDoc = this;
	context.m_pCurrentFrame = NULL;
	context.m_pNewDocTemplate = NULL;
	context.m_pLastView = NULL;
	context.m_pNewViewClass = RUNTIME_CLASS(CMailView);

	pMailFrame->LoadFrame(IDR_MAILFRAME, WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, NULL, &context);

	pMailFrame->ShowWindow(SW_SHOW);
}
