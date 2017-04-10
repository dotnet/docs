//
// TaskPane.h : header file
//

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CTaskPane window

class CTaskPane : public CMFCTasksPane
{
// Construction
public:
	CTaskPane();

// Attributes
protected:
	int	m_nDocumentsGroup;
	CFont		m_Font;
	CTreeCtrl	m_wndTree;
	CEdit		m_wndEdit;

// Operations
public:
	void UpdateMRUFilesList ();
	void UpdateIcons ();

// Overrides
public:
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTaskPane)
	//}}AFX_VIRTUAL

protected:
	BOOL CreateTreeWindow();

// Implementation
public:
	virtual ~CTaskPane();

	// Generated message map functions
protected:
	//{{AFX_MSG(CTaskPane)
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};
