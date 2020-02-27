#pragma once

/////////////////////////////////////////////////////////////////////////////
// CPropSheetDemoDlg dialog

class CPropSheetDemoDlg : public CDialogEx
{
// Construction
public:
	CPropSheetDemoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_PROPSHEETDEMO_DIALOG };
	BOOL	m_bHeader;

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

// Implementation
protected:
	HICON m_hIcon;

	virtual BOOL OnInitDialog();

	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnPropSheet1();
	afx_msg void OnPropSheet2();
	afx_msg void OnPropSheet3();
	afx_msg void OnPropSheet4();
	afx_msg void OnPropSheet5();

	DECLARE_MESSAGE_MAP()
};

