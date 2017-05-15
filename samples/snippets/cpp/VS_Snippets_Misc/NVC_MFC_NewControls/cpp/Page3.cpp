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
#include "Page3.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CPage3 property page

IMPLEMENT_DYNCREATE(CPage3, CMFCPropertyPage)

CPage3::CPage3() : CMFCPropertyPage(CPage3::IDD)
{
	m_bTrueType = TRUE;
	m_bRaster = TRUE;
	m_bDeviceFont = TRUE;
	m_bDrawUsingFont = FALSE;
}

CPage3::~CPage3()
{
}

void CPage3::DoDataExchange(CDataExchange* pDX)
{
	CMFCPropertyPage::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CUSTOM_EDIT, m_wndCustomEdit);
	DDX_Control(pDX, IDC_FOLDER_EDIT, m_wndFolderEdit);
	DDX_Control(pDX, IDC_FILE_EDIT, m_wndFileEdit);
	DDX_Control(pDX, IDC_FONT, m_wndFont);
	DDX_Control(pDX, IDC_IMAGE_AREA, m_wndImageArea);
	DDX_Control(pDX, IDC_EDIT_IMAGE, m_btnImageEdit);
	DDX_Control(pDX, IDC_BUTTON_URL, m_btnLink);
	DDX_Control(pDX, IDC_EDIT_LIST, m_wndEditListBox);
	DDX_Check(pDX, IDC_TRUETYPE, m_bTrueType);
	DDX_Check(pDX, IDC_RASTER, m_bRaster);
	DDX_Check(pDX, IDC_DEVICE, m_bDeviceFont);
	DDX_Check(pDX, IDC_DRAW_USING_FONT, m_bDrawUsingFont);
}

BEGIN_MESSAGE_MAP(CPage3, CMFCPropertyPage)
	ON_BN_CLICKED(IDC_EDIT_IMAGE, OnEditImage)
	ON_WM_PAINT()
	ON_BN_CLICKED(IDC_RASTER, OnFontType)
	ON_BN_CLICKED(IDC_TRUETYPE, OnFontType)
	ON_BN_CLICKED(IDC_DEVICE, OnFontType)
	ON_BN_CLICKED(IDC_DRAW_USING_FONT, OnDrawUsingFont)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPage3 message handlers

BOOL CPage3::OnInitDialog()
{
	CMFCPropertyPage::OnInitDialog();

	m_wndEditListBox.SetStandardButtons();
	m_wndEditListBox.EnableBrowseButton();

	m_wndEditListBox.AddItem(_T("Item 1"));
	m_wndEditListBox.AddItem(_T("Item 2"));
	m_wndEditListBox.AddItem(_T("Item 3"));

	// <snippet10>
	m_btnLink.SetURL(_T("http://www.microsoft.com"));
	m_btnLink.SetTooltip(_T("Visit Microsoft site"));
	// resize the button to contain the button text or bitmap
	m_btnLink.SizeToContent();
	// </snippet10>

	m_btnImageEdit.m_nFlatStyle = CMFCButton::BUTTONSTYLE_SEMIFLAT;
	m_btnImageEdit.SetImage(IDB_IMAGE);
	m_btnImageEdit.SizeToContent();
	m_btnImageEdit.SetTextHotColor(RGB(0, 0, 255));

	m_bmpImage.LoadBitmap(IDB_TEST_BITMAP);

	BITMAP bmp;
	m_bmpImage.GetBitmap(&bmp);

	m_wndImageArea.GetClientRect(m_rectImage);
	m_wndImageArea.MapWindowPoints(this, m_rectImage);

	m_rectImage.right = m_rectImage.left + bmp.bmWidth;
	m_rectImage.bottom = m_rectImage.top + bmp.bmHeight;

	// <snippet35>
	m_wndFont.SelectFont(_T("Arial"));
	// </snippet35>

	// <snippet7>
	// enable the browse button and put the control in file browse mode
	m_wndFolderEdit.EnableFolderBrowseButton();
	// enable the browse button and put the control in the folder browse mode
	m_wndFileEdit.EnableFileBrowseButton();
    // </snippet7>

	m_wndCustomEdit.EnableBrowseButton();

	UpdateData(FALSE);

	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}

void CPage3::OnPaint()
{
	CPaintDC dc(this); // device context for painting

	CRect rectFrame = m_rectImage;

	rectFrame.InflateRect(1, 1);
	dc.Draw3dRect(rectFrame, GetSysColor(COLOR_3DLIGHT), GetSysColor(COLOR_3DSHADOW));
	rectFrame.InflateRect(1, 1);
	dc.Draw3dRect(rectFrame, GetSysColor(COLOR_3DHILIGHT), GetSysColor(COLOR_3DDKSHADOW));

	dc.DrawState(m_rectImage.TopLeft(), m_rectImage.Size(), &m_bmpImage, 0);
}

void CPage3::OnEditImage()
{
	// <snippet8>
	// CBitmap m_bmpImage
	HBITMAP hBmpCopy = (HBITMAP) ::CopyImage(m_bmpImage.GetSafeHandle(), IMAGE_BITMAP, 0, 0, 0);
	// </snippet8>
	ASSERT(hBmpCopy != NULL);

	if (hBmpCopy)
	{
		// <snippet40>
		// this points to Page3 class which extends the CMFCPropertyPage class
		CMFCImageEditorDialog dlg(CBitmap::FromHandle(hBmpCopy), this);
		// </snippet40>

		if (dlg.DoModal() == IDOK)
		{
			m_bmpImage.DeleteObject();
			m_bmpImage.Attach(hBmpCopy);

			InvalidateRect(m_rectImage);
			UpdateWindow();
		}
		else
		{
			::DeleteObject(hBmpCopy);
		}
	}
}

void CPage3::OnFontType()
{
	UpdateData();

	// <snippet36>
	// specify the font type
	// BOOL m_bTrueType: true font type
	// BOOL m_bRaster: raster font type
	// BOOL m_bDeviceFont: device font type
	int nFontType = 0;

	if (m_bTrueType)
	{
		nFontType |= TRUETYPE_FONTTYPE;
	}

	if (m_bRaster)
	{
		nFontType |= RASTER_FONTTYPE;
	}

	if (m_bDeviceFont)
	{
		nFontType |= DEVICE_FONTTYPE;
	}

	CWaitCursor wait;
	m_wndFont.Setup(nFontType);
	// </snippet36>
}

void CPage3::OnDrawUsingFont()
{
	UpdateData();
	CMFCFontComboBox::m_bDrawUsingFont = m_bDrawUsingFont;
	m_wndFont.RedrawWindow();
}
