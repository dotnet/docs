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
#include "Page1.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

const size_t MAX_TIP_TEXT_LENGTH = 1024;

/////////////////////////////////////////////////////////////////////////////
// CPage1 property page

IMPLEMENT_DYNCREATE(CPage1, CMFCPropertyPage)

CPage1::CPage1() : CMFCPropertyPage(CPage1::IDD)
{
	m_bXPButtons = TRUE;
	m_bCheck = TRUE;
	m_strToolTip = _T("ToolTip");
	m_iImage = 2;
	m_iBorderStyle = 0;
	m_iCursor = 0;
	m_bMenuStayPressed = FALSE;
	m_bRightArrow = FALSE;
	m_nImageLocation = 0;
	m_bMenuDefaultClick = FALSE;
}

CPage1::~CPage1()
{
}

void CPage1::DoDataExchange(CDataExchange* pDX)
{
	CMFCPropertyPage::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_BUTTON_MULTLINE, m_btnMultiLine);
	DDX_Control(pDX, IDC_BORDER, m_wndBorder);
	DDX_Control(pDX, IDC_BORDER_LABEL, m_wndBorderLabel);
	DDX_Control(pDX, IDC_CHECK_BUTTON, m_btnCheck);
	DDX_Control(pDX, IDC_XP_BUTTONS, m_wndXPButtons);
	DDX_Check(pDX, IDC_XP_BUTTONS, m_bXPButtons);
	DDX_Check(pDX, IDC_CHECK_BUTTON, m_bCheck);
	DDX_Control(pDX, IDC_BUTTON, m_Button);
	DDX_Text(pDX, IDC_TOOLTIP, m_strToolTip);
	DDX_Control(pDX, IDC_TOOLTIP, m_wndToolTip);
	DDX_CBIndex(pDX, IDC_IMAGE, m_iImage);
	DDX_CBIndex(pDX, IDC_BORDER, m_iBorderStyle);
	DDX_CBIndex(pDX, IDC_CURSOR, m_iCursor);
	DDX_Control(pDX, IDC_BUTTON_MENU, m_btnMenu);
	DDX_Check(pDX, IDC_PRESSED_ON_MENU, m_bMenuStayPressed);
	DDX_Check(pDX, IDC_RIGHT_ARROW, m_bRightArrow);
	DDX_CBIndex(pDX, IDC_IMAGE_LOCATION, m_nImageLocation);
	DDX_Check(pDX, IDC_MENU_DEFAULT_CLICK, m_bMenuDefaultClick);

	DDX_Control(pDX, IDC_RADIO1, m_btnRadio1);
	DDX_Control(pDX, IDC_RADIO2, m_btnRadio2);
	DDX_Control(pDX, IDC_RADIO3, m_btnRadio3);
	DDX_Control(pDX, IDC_RADIO4, m_btnRadio4);
}

BEGIN_MESSAGE_MAP(CPage1, CMFCPropertyPage)
	ON_BN_CLICKED(IDC_XP_BUTTONS, OnXpButtons)
	ON_BN_CLICKED(IDC_SET_TOOLTIP, OnSetTooltip)
	ON_CBN_SELCHANGE(IDC_CURSOR, OnSetCursor)
	ON_BN_CLICKED(IDC_BUTTON, OnButton)
	ON_BN_CLICKED(IDC_RIGHT_ARROW, OnRightArrow)
	ON_BN_CLICKED(IDC_BUTTON_MENU, OnButtonMenu)
	ON_BN_CLICKED(IDC_PRESSED_ON_MENU, OnPressedOnMenu)
	ON_COMMAND(ID_DIALOG_ABOUT, OnDialogAbout)
	ON_UPDATE_COMMAND_UI(ID_ITEM_2, OnUpdateItem2)
	ON_CBN_SELCHANGE(IDC_IMAGE, OnResetButton)
	ON_CBN_SELCHANGE(IDC_BORDER, OnResetButton)
	ON_CBN_SELCHANGE(IDC_IMAGE, OnResetButton)
	ON_CBN_SELCHANGE(IDC_BORDER, OnResetButton)
	ON_CBN_SELCHANGE(IDC_IMAGE_LOCATION, OnResetButton)
	ON_BN_CLICKED(IDC_MENU_DEFAULT_CLICK, OnMenuDefaultClick)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPage1 message handlers

void CPage1::OnXpButtons()
{
	UpdateData();

	CMFCButton::EnableWindowsTheming(m_bXPButtons);

	m_wndBorder.EnableWindow(!m_bXPButtons);
	m_wndBorderLabel.EnableWindow(!m_bXPButtons);

	RedrawWindow();
}

BOOL CPage1::OnInitDialog()
{
	CMFCPropertyPage::OnInitDialog();

	if (!CMFCVisualManagerWindows::IsWinXPThemeAvailable())
	{
		m_bXPButtons = FALSE;
		m_wndXPButtons.EnableWindow(FALSE);
	}
	else
	{
		m_wndBorder.EnableWindow(FALSE);
		m_wndBorderLabel.EnableWindow(FALSE);
	}

	m_Button.m_bTransparent = TRUE;

	OnResetButton();
	OnSetCursor();
	OnSetTooltip();

	m_menu.LoadMenu(IDR_MENU1);
	// <snippet39>
	// CMenu m_menu
	m_btnMenu.m_hMenu = m_menu.GetSubMenu(0)->GetSafeHmenu();
	m_btnMenu.SizeToContent();
	// set to FALSE so that the framework calls CContextMenuManager::TrackPopupMenu
	// to display its menu
	m_btnMenu.m_bOSMenu = FALSE;
	// </snippet39>

	m_wndToolTip.SetLimitText(MAX_TIP_TEXT_LENGTH);

	m_btnCheck.SetImage(IDB_CHECKNO32);
	m_btnCheck.SetCheckedImage(IDB_CHECK32);
	m_btnCheck.SizeToContent();
	m_btnCheck.m_nFlatStyle = CMFCButton::BUTTONSTYLE_SEMIFLAT;

	m_btnRadio1.m_nFlatStyle = CMFCButton::BUTTONSTYLE_SEMIFLAT;
	m_btnRadio2.m_nFlatStyle = CMFCButton::BUTTONSTYLE_SEMIFLAT;
	m_btnRadio3.m_nFlatStyle = CMFCButton::BUTTONSTYLE_SEMIFLAT;
	m_btnRadio4.m_nFlatStyle = CMFCButton::BUTTONSTYLE_SEMIFLAT;

	m_btnRadio1.SetImage(IDB_RADIO_OFF32);
	m_btnRadio2.SetImage(IDB_RADIO_OFF32);
	m_btnRadio3.SetImage(IDB_RADIO_OFF32);
	m_btnRadio4.SetImage(IDB_RADIO_OFF32);

	m_btnRadio1.SetCheckedImage(IDB_RADIO_ON32);
	m_btnRadio2.SetCheckedImage(IDB_RADIO_ON32);
	m_btnRadio3.SetCheckedImage(IDB_RADIO_ON32);
	m_btnRadio4.SetCheckedImage(IDB_RADIO_ON32);

	m_btnRadio1.SizeToContent();
	m_btnRadio2.SizeToContent();
	m_btnRadio3.SizeToContent();
	m_btnRadio4.SizeToContent();

	m_btnRadio1.SetCheck(TRUE);

	m_btnMultiLine.SizeToContent();

	CMFCToolBar::AddToolBarForImageCollection(IDR_TOOLBAR_MENU_IMAGES);

	UpdateData(FALSE);

	return TRUE;  // return TRUE unless you set the focus to a control
}


void CPage1::OnResetButton()
{
	UpdateData();

	// <snippet29>
	//int m_iBorderStyle
	switch (m_iBorderStyle)
	{
	case 0:
		m_Button.m_nFlatStyle = CMFCButton::BUTTONSTYLE_FLAT;
		break;

	case 1:
		m_Button.m_nFlatStyle = CMFCButton::BUTTONSTYLE_SEMIFLAT;
		break;

	case 2:
		m_Button.m_nFlatStyle = CMFCButton::BUTTONSTYLE_3D;
	}
	// </snippet29>

	// <snippet31>
	// int m_iImage
	// IDB_BTN1_32, IDB_BTN1_HOT_32, IDB_BTN1, IDB_BTN1_HOT are int macros that are #define.
	if (m_iImage == 1) 
	{
		m_Button.SetImage((HBITMAP) NULL);
	}
	else
	{
		m_Button.SetImage(IDB_BTN1_32, IDB_BTN1_HOT_32);
	}
	// </snippet31>

	// <snippet32>
	// int m_iImage
	if (m_iImage == 0)
	{
		m_Button.SetWindowText(_T(""));
	}
	else
	{
		m_Button.SetWindowText(_T("Button"));
	}
	// </snippet32>

	switch (m_nImageLocation)
	{
	case 0:
		m_Button.m_bRightImage = FALSE;
		m_Button.m_bTopImage = FALSE;
		break;

	case 1:
		m_Button.m_bRightImage = TRUE;
		m_Button.m_bTopImage = FALSE;
		break;

	case 2:
		m_Button.m_bRightImage = FALSE;
		m_Button.m_bTopImage = TRUE;
		break;
	}

	// <snippet33>
	// Resize the button.
	m_Button.SizeToContent();
	m_Button.EnableFullTextTooltip(true);
	// Use the application menu font at the button text font.
	m_Button.EnableMenuFont();
	// Use the current Windows theme to draw the button borders.
	m_Button.EnableWindowsTheming(true);
	// Set the button to auto-repeat mode.
	m_Button.SetAutorepeatMode();
	// Set the background color for the button text.
	m_Button.SetFaceColor(RGB(255,0,0),true);
	m_Button.SetTextColor(RGB(0,0,255));
	// Set the tooltip of the button.
	m_Button.SetTooltip(_T("this is a button!"));
	// </snippet33>
}

// <snippet30>
// int m_iCursor
void CPage1::OnSetCursor()
{
	UpdateData();

	switch (m_iCursor)
	{
	case 0:
		m_Button.SetMouseCursor(NULL);
		break;

	case 1:
		m_Button.SetMouseCursorHand();
		break;

	case 2:
		m_Button.SetMouseCursor(AfxGetApp()->LoadCursor(IDC_CURSOR));
		break;
	}
}
// </snippet30>

void CPage1::OnButton()
{
	MessageBox(_T("Button Clicked!"));
}

void CPage1::OnSetTooltip()
{
	UpdateData();
	m_Button.SetTooltip(m_strToolTip);
}

void CPage1::OnPressedOnMenu()
{
	UpdateData();
	m_btnMenu.m_bStayPressed = m_bMenuStayPressed;
}

void CPage1::OnRightArrow()
{
	UpdateData();
	m_btnMenu.m_bRightArrow = m_bRightArrow;
	m_btnMenu.Invalidate();
}

void CPage1::OnButtonMenu()
{
	CString strItem;

	switch (m_btnMenu.m_nMenuResult)
	{
	case ID_ITEM_1:
		strItem = _T("Item 1");
		break;

	case ID_ITEM_2:
		strItem = _T("Item 2");
		break;

	case ID_ITEM_3:
		strItem = _T("Item 3");
		break;

	case ID_ITEM_4:
		strItem = _T("Item 4");
		break;

	default:
		if (!m_bMenuDefaultClick)
		{
			return;
		}

		strItem = _T("Default Menu Button Action");
		break;
	}

	MessageBox(strItem);
}

void CPage1::OnDialogAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}

void CPage1::OnUpdateItem2(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck();
}

void CPage1::OnMenuDefaultClick()
{
	UpdateData();

	m_btnMenu.m_bDefaultClick = m_bMenuDefaultClick;
	m_btnMenu.RedrawWindow();
}


