// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

#define FIRST_HISTORY_COMMAND	0x1000
#define HISTORY_LEN	10

#include "HistoryObj.h"

typedef CList<CHistoryObj*, CHistoryObj*> _T_HistotyList;

class CIEDemoDoc : public CDocument
{
protected: // create from serialization only
	CIEDemoDoc();
	DECLARE_DYNCREATE(CIEDemoDoc)

// Attributes
public:
	CArray<CHistoryObj*, CHistoryObj*>	m_arHistory;
	int	m_iHistoryOffset;

// Operations
public:
	void GetBackList (_T_HistotyList& lst) const;
	void GetFrwdList (_T_HistotyList& lst) const;

	BOOL IsBackAvailable () const
	{
		return m_iHistoryOffset < m_arHistory.GetSize () - 1;
	}

	BOOL IsFrwdAvailable ()
	{
		return m_iHistoryOffset > 0;
	}

	CHistoryObj* GoBack ()
	{
		if (m_iHistoryOffset >= m_arHistory.GetSize ())
		{
			ASSERT (FALSE);
			return NULL;
		}

		return m_arHistory [++ m_iHistoryOffset];
	}

	CHistoryObj* GoForward ()
	{
		if (m_iHistoryOffset < 1)
		{
			ASSERT (FALSE);
			return NULL;
		}

		return m_arHistory [--m_iHistoryOffset];
	}

	CHistoryObj* Go (UINT uiCmd);
	CHistoryObj* AddURLToHistory (const CString& strTitle, const CString& strURL);

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CIEDemoDoc)
	public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CIEDemoDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CIEDemoDoc)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};
