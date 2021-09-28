// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CMailView view

class CMailView : public CEditView
{
protected:
	CMailView();           // protected constructor used by dynamic creation
	DECLARE_DYNCREATE(CMailView)

// Attributes
public:
	int m_nPriority;

// Overrides
public:
	virtual void OnInitialUpdate();

// Implementation
protected:
	virtual ~CMailView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg void OnMailAttachment();
	afx_msg void OnMailCheckNames();
	afx_msg void OnMailCopyToFolder();
	afx_msg void OnMailDelete();
	afx_msg void OnMailFlag();
	afx_msg void OnMailFontsize();
	afx_msg void OnMailHightPriority();
	afx_msg void OnUpdateMailHightPriority(CCmdUI* pCmdUI);
	afx_msg void OnMailItem();
	afx_msg void OnMailLowPriority();
	afx_msg void OnUpdateMailLowPriority(CCmdUI* pCmdUI);
	afx_msg void OnMailMoveToFolder();
	afx_msg void OnMailOptions();
	afx_msg void OnMailProperties();
	afx_msg void OnMailSave();
	afx_msg void OnMailSaveAttachments();
	afx_msg void OnMailSaveStationery();
	afx_msg void OnMailSend();
	afx_msg void OnMailSignature();
	afx_msg void OnMailSpell();
	afx_msg void OnMailTo();
	afx_msg void OnMailCc();

	DECLARE_MESSAGE_MAP()
};
