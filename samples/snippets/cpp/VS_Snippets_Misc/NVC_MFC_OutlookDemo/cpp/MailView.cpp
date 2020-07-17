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
#include "MailView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMailView

IMPLEMENT_DYNCREATE(CMailView, CEditView)

CMailView::CMailView()
{
	m_nPriority = 1;
}

CMailView::~CMailView()
{
}

BEGIN_MESSAGE_MAP(CMailView, CEditView)
	ON_COMMAND(ID_MAIL_ATTACHMENT, OnMailAttachment)
	ON_COMMAND(ID_MAIL_CHECK_NAMES, OnMailCheckNames)
	ON_COMMAND(ID_MAIL_COPY_TO_FOLDER, OnMailCopyToFolder)
	ON_COMMAND(ID_MAIL_DELETE, OnMailDelete)
	ON_COMMAND(ID_MAIL_FLAG, OnMailFlag)
	ON_COMMAND(ID_MAIL_FONTSIZE, OnMailFontsize)
	ON_COMMAND(ID_MAIL_HIGHT_PRIORITY, OnMailHightPriority)
	ON_UPDATE_COMMAND_UI(ID_MAIL_HIGHT_PRIORITY, OnUpdateMailHightPriority)
	ON_COMMAND(ID_MAIL_ITEM, OnMailItem)
	ON_COMMAND(ID_MAIL_LOW_PRIORITY, OnMailLowPriority)
	ON_UPDATE_COMMAND_UI(ID_MAIL_LOW_PRIORITY, OnUpdateMailLowPriority)
	ON_COMMAND(ID_MAIL_MOVE_TO_FOLDER, OnMailMoveToFolder)
	ON_COMMAND(ID_MAIL_OPTIONS, OnMailOptions)
	ON_COMMAND(ID_MAIL_PROPERTIES, OnMailProperties)
	ON_COMMAND(ID_MAIL_SAVE, OnMailSave)
	ON_COMMAND(ID_MAIL_SAVE_ATTACHMENTS, OnMailSaveAttachments)
	ON_COMMAND(ID_MAIL_SAVE_STATIONERY, OnMailSaveStationery)
	ON_COMMAND(ID_MAIL_SEND, OnMailSend)
	ON_COMMAND(ID_MAIL_SIGNATURE, OnMailSignature)
	ON_COMMAND(ID_MAIL_SPELL, OnMailSpell)
	ON_COMMAND(IDC_MAIL_TO, OnMailTo)
	ON_COMMAND(IDC_MAIL_CC, OnMailCc)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMailView diagnostics

#ifdef _DEBUG
void CMailView::AssertValid() const
{
	CEditView::AssertValid();
}

void CMailView::Dump(CDumpContext& dc) const
{
	CEditView::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CMailView message handlers

void CMailView::OnMailTo()
{
}

void CMailView::OnMailCc()
{
}

void CMailView::OnMailAttachment()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailCheckNames()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailCopyToFolder()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailDelete()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailFlag()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailFontsize()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailHightPriority()
{
	m_nPriority = m_nPriority == 2 ? 1 : 2;
}

void CMailView::OnUpdateMailHightPriority(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_nPriority == 2);
}

void CMailView::OnMailItem()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailLowPriority()
{
	m_nPriority = m_nPriority == 0 ? 1 : 0;
}

void CMailView::OnUpdateMailLowPriority(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_nPriority == 0);
}

void CMailView::OnMailMoveToFolder()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailOptions()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailProperties()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailSave()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailSaveAttachments()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailSaveStationery()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailSend()
{
	GetParentFrame()->SendMessage(WM_CLOSE);
}

void CMailView::OnMailSignature()
{
	// TODO: Add your command handler code here
}

void CMailView::OnMailSpell()
{
	// TODO: Add your command handler code here
}

void CMailView::OnInitialUpdate()
{
	CEditView::OnInitialUpdate();
	GetEditCtrl().ModifyStyle(0, WS_BORDER);
}
