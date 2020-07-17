#pragma once

/////////////////////////////////////////////////////////////////////////////
// CAppLookDlg dialog

class CAppLookDlg : public CDialog
{
// Construction
public:
	CAppLookDlg(BOOL bStartup, CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CAppLookDlg)
	enum { IDD = IDD_APP_LOOK };
	CComboBox	m_wndStyle2007;
	CButton	m_wndOK;
	CButton	m_wndCancel;
	int		m_nAppLook;
	BOOL	m_bShowAtStartup;
	int		m_nStyle2007;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAppLookDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CAppLookDlg)
	virtual BOOL OnInitDialog();
	virtual void OnOK();
	afx_msg void OnApply();
	afx_msg void OnAppLook();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

	const BOOL	m_bStartup;

	void SetLook ();
};
