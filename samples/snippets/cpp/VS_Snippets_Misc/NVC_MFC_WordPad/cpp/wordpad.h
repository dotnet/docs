//
// wordpad.h : main header file for the WORDPAD application
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) 1992-1998 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols
#include "splash.h"
#include "options.h"
#include "afxtempl.h"

#define WPM_BARSTATE WM_USER

/////////////////////////////////////////////////////////////////////////////
// CWordPadApp:
// See wordpad.cpp for the implementation of this class
//

class CWordPadCommandLineInfo : public CCommandLineInfo
{
public:
	CWordPadCommandLineInfo() {m_bForceTextMode = FALSE;}
	BOOL m_bForceTextMode;
	virtual void ParseParam(const char* pszParam,BOOL bFlag,BOOL bLast);
};

class CWordPadApp : public CWinAppEx
{
public:
	CWordPadApp();
	~CWordPadApp();

	virtual void PreLoadState ();

//Attributes
	CWordPadCommandLineInfo cmdInfo;
	CDC m_dcScreen;
	LOGFONT m_lf;
	int m_nDefFont;
	static int m_nOpenMsg;
	static int m_nPrinterChangedMsg;
	CRect m_rectPageMargin;
	CRect m_rectInitialFrame;
	BOOL m_bMaximized;
	BOOL m_bPromptForType;
	BOOL m_bWin4;
	BOOL m_bHiColorIcons;

#ifndef _UNICODE
	BOOL m_bWin31;
#endif
	BOOL m_bForceTextMode;
	BOOL m_bWordSel;
	BOOL m_bForceOEM;
	int m_nFilterIndex;
	int m_nNewDocType;
	CDocOptions m_optionsText;
	CDocOptions m_optionsRTF;
	CDocOptions m_optionsWord; //wrap to ruler
	CDocOptions m_optionsWrite; //wrap to ruler
	CDocOptions m_optionsIP;    //wrap to ruler
	CDocOptions m_optionsNull;
	CList<HWND, HWND> m_listPrinterNotify;

	BOOL IsDocOpen(LPCTSTR lpszFileName);

// Get
	int GetUnits() {return m_nUnits;}
	int GetTPU() { return GetTPU(m_nUnits);}
	int GetTPU(int n) { return m_units[n].m_nTPU;}
	LPCTSTR GetAbbrev() { return m_units[m_nUnits].m_strAbbrev;}
	LPCTSTR GetAbbrev(int n) { return m_units[n].m_strAbbrev;}
	const CUnit& GetUnit() {return m_units[m_nUnits];}
	CDockState& GetDockState(int nDocType, BOOL bPrimary = TRUE);
	CDocOptions& GetDocOptions(int nDocType);

// Set
	void SetUnits(int n)
	{ ASSERT(n>=0 && n <m_nPrimaryNumUnits); m_nUnits = n; }

// Operations
	void RegisterFormats();
	static BOOL CALLBACK StaticEnumProc(HWND hWnd, LPARAM lParam);
	void UpdateRegistry();
	void NotifyPrinterChanged(BOOL bUpdatePrinterSelection = FALSE);
	BOOL PromptForFileName(CString& fileName, UINT nIDSTitle, DWORD dwFlags,
		BOOL bOpenFileDialog, int* pType = NULL);

	BOOL ParseMeasurement(TCHAR* buf, int& lVal);
	void PrintTwips(TCHAR* buf, int nValue, int nDecimal);
	void SaveOptions();
	void LoadOptions();
	void LoadAbbrevStrings();
	HGLOBAL CreateDevNames();

// Overrides
	BOOL IsIdleMessage(MSG* pMsg);
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CWordPadApp)
	public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();
	virtual BOOL OnDDECommand(LPTSTR lpszCommand);
	virtual void WinHelp(DWORD dwData, UINT nCmd = HELP_CONTEXT);
	virtual BOOL PreTranslateMessage(MSG* pMsg);
	//}}AFX_VIRTUAL

// Implementation
	COleTemplateServer m_server;
		// Server object for document creation

	//{{AFX_MSG(CWordPadApp)
	afx_msg void OnAppAbout();
	afx_msg void OnFileNew();
	afx_msg void OnFileOpen();
	afx_msg void OnViewAppLook();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
private:
	int m_nUnits;
	static const int m_nPrimaryNumUnits;
	static const int m_nNumUnits;
	static CUnit m_units[7];
};

/////////////////////////////////////////////////////////////////////////////

extern CWordPadApp theApp;
//inline CWordPadApp* GetWordPadApp() {return (CWordPadApp*)AfxGetApp();}
