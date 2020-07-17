// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "NewControls.h"
#include "NewControlsPropSheet.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// NewControlsPropSheet

IMPLEMENT_DYNAMIC(NewControlsPropSheet, CMFCPropertySheet)

NewControlsPropSheet::NewControlsPropSheet(CWnd* pParentWnd)
:CMFCPropertySheet(IDS_CAPTION, pParentWnd)
{
	BOOL b32BitIcons = true;

	if (afxGlobalData.m_nBitsPerPixel == 16)
	{
		// 32-bit icons in 16 bpp display mode
		// are correctly displayed in WinXP only

		OSVERSIONINFO osvi;
		osvi.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);
		::GetVersionEx(&osvi);

		b32BitIcons = (osvi.dwPlatformId == VER_PLATFORM_WIN32_NT && (osvi.dwMajorVersion > 5 || (osvi.dwMajorVersion == 5 && osvi.dwMinorVersion >= 1)));
	}

	SetLook(CMFCPropertySheet::PropSheetLook_OutlookBar);
	SetIconsList(b32BitIcons ? IDB_ICONS32 : IDB_ICONS, 32);

	AddPage(&m_Page1);
	AddPage(&m_Page2);
	AddPage(&m_Page3);
	AddPage(&m_Page4);
	AddPage(&m_Page5);
	AddPage(&m_Page6);

	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

NewControlsPropSheet::~NewControlsPropSheet()
{
}

BEGIN_MESSAGE_MAP(NewControlsPropSheet, CMFCPropertySheet)
	ON_WM_QUERYDRAGICON()
	ON_WM_SYSCOMMAND()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// NewControlsPropSheet message handlers

BOOL NewControlsPropSheet::OnInitDialog()
{
	BOOL bResult = CMFCPropertySheet::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bValidString;
		CString strAboutMenu;
		bValidString = strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE); // Set big icon
	SetIcon(m_hIcon, FALSE); // Set small icon

	return bResult;
}

HCURSOR NewControlsPropSheet::OnQueryDragIcon()
{
	return(HCURSOR) m_hIcon;
}

void NewControlsPropSheet::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg aboutDlg;
		aboutDlg.DoModal();
	}
	else
	{
		CMFCPropertySheet::OnSysCommand(nID, lParam);
	}
}

