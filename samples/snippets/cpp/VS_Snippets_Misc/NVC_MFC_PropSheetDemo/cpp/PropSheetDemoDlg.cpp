#include "stdafx.h"
#include "PropSheetDemo.h"
#include "PropSheetDemoDlg.h"
#include "MyPropertySheet.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define HEADER_HEIGHT	30

/////////////////////////////////////////////////////////////////////////////
// CPropSheetDemoDlg dialog

CPropSheetDemoDlg::CPropSheetDemoDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CPropSheetDemoDlg::IDD, pParent)
{
	m_bHeader = FALSE;

	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CPropSheetDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Check(pDX, IDC_HEADER, m_bHeader);
}

BEGIN_MESSAGE_MAP(CPropSheetDemoDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_PROP_SHEET1, OnPropSheet1)
	ON_BN_CLICKED(IDC_PROP_SHEET2, OnPropSheet2)
	ON_BN_CLICKED(IDC_PROP_SHEET3, OnPropSheet3)
	ON_BN_CLICKED(IDC_PROP_SHEET4, OnPropSheet4)
	ON_BN_CLICKED(IDC_PROP_SHEET5, OnPropSheet5)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPropSheetDemoDlg message handlers

BOOL CPropSheetDemoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

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
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CPropSheetDemoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CPropSheetDemoDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CPropSheetDemoDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CPropSheetDemoDlg::OnPropSheet1() 
{
	UpdateData ();

	CMyPropertySheet propSheet (CMFCPropertySheet::PropSheetLook_Tabs);

	propSheet.EnablePageHeader (m_bHeader ? HEADER_HEIGHT : 0);
	propSheet.DoModal();
}

void CPropSheetDemoDlg::OnPropSheet2() 
{
	UpdateData ();

	CMyPropertySheet propSheet (CMFCPropertySheet::PropSheetLook_OutlookBar,
		IDB_ICONS_LARGE, 32);

	propSheet.EnablePageHeader (m_bHeader ? HEADER_HEIGHT : 0);
	propSheet.DoModal();
}

void CPropSheetDemoDlg::OnPropSheet3() 
{
	UpdateData ();

	CMyPropertySheet propSheet (CMFCPropertySheet::PropSheetLook_Tree,
		IDB_TREE_ICONS, 16);

	propSheet.EnablePageHeader (m_bHeader ? HEADER_HEIGHT : 0);
	propSheet.DoModal();
}

void CPropSheetDemoDlg::OnPropSheet4() 
{
	UpdateData ();

	CMyPropertySheet propSheet (CMFCPropertySheet::PropSheetLook_OneNoteTabs,
		IDB_ICONS_SMALL, 16);
	propSheet.GetTab ().EnableAutoColor ();

	propSheet.EnablePageHeader (m_bHeader ? HEADER_HEIGHT : 0);
	propSheet.DoModal();
}

void CPropSheetDemoDlg::OnPropSheet5() 
{
	UpdateData ();

	CMyPropertySheet propSheet (CMFCPropertySheet::PropSheetLook_List);

	propSheet.EnablePageHeader (m_bHeader ? HEADER_HEIGHT : 0);
	propSheet.DoModal();
}

