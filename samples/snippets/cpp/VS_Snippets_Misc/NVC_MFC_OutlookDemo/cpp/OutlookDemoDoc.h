// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class COutlookDemoDoc : public CDocument
{
protected: // create from serialization only
	COutlookDemoDoc();
	DECLARE_DYNCREATE(COutlookDemoDoc)

// Overrides
public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);

// Implementation
public:
	virtual ~COutlookDemoDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg void OnNewAppointment();
	afx_msg void OnNewContract();
	afx_msg void OnNewDistributionList();
	afx_msg void OnNewFax();
	afx_msg void OnNewFolder();
	afx_msg void OnNewJournalEntry();
	afx_msg void OnNewMail();
	afx_msg void OnNewMeeting();
	afx_msg void OnNewNote();
	afx_msg void OnNewPostFolder();
	afx_msg void OnNewShortcut();
	afx_msg void OnNewTask();
	afx_msg void OnNewTaskRequest();
	afx_msg void OnSendReceive();
	afx_msg void OnAddressBook();
	afx_msg void OnFindContact();
	afx_msg void OnWebAddress();
	afx_msg void OnWebBack();
	afx_msg void OnWebFind();
	afx_msg void OnWebRefresh();
	afx_msg void OnWebStart();
	afx_msg void OnViewUp();
	afx_msg void OnViewBack();
	afx_msg void OnRulesWizard();

	DECLARE_MESSAGE_MAP()
};
