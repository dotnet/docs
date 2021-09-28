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
#include "Page2.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CPage2 property page

IMPLEMENT_DYNCREATE(CPage2, CMFCPropertyPage)

CPage2::CPage2() : CMFCPropertyPage(CPage2::IDD)
{
	m_strRGB = _T("255, 0, 255");
	m_strRGBColorBar = _T("0, 0, 0");
	m_strRGBColorBar2 = _T("0, 0, 255");
	m_strRGBColorDialog = _T("255, 0, 255");
	m_strRGBColorPalette = _T("0, 255, 0");
	m_Color = RGB(255, 0, 255);
}

CPage2::~CPage2()
{
}

void CPage2::DoDataExchange(CDataExchange* pDX)
{
	CMFCPropertyPage::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LUM, m_wndLum);
	DDX_Control(pDX, IDC_COLOR_PALETTE, m_wndColorPalette);
	DDX_Control(pDX, IDC_COLORBAR2, m_wndColorBarFrame2);
	DDX_Control(pDX, IDC_COLORBAR, m_wndColorBarFrame);
	DDX_Control(pDX, IDC_COLOR_PICKER, m_ColorPicker);
	DDX_Text(pDX, IDC_RGB, m_strRGB);
	DDX_Text(pDX, IDC_RGB_COLOR_BAR, m_strRGBColorBar);
	DDX_Text(pDX, IDC_RGB_COLOR_BAR2, m_strRGBColorBar2);
	DDX_Text(pDX, IDC_RGB_DLG, m_strRGBColorDialog);
	DDX_Text(pDX, IDC_RGB_COLOR_PALETTE, m_strRGBColorPalette);
}

BEGIN_MESSAGE_MAP(CPage2, CMFCPropertyPage)
	ON_BN_CLICKED(IDC_COLOR_DLG, OnColorDlg)
	ON_BN_CLICKED(IDC_COLOR_PICKER, OnColorPicker)
	ON_BN_CLICKED(IDC_COLOR_PALETTE, OnColorPalette)
	ON_BN_CLICKED(IDC_LUM, OnLum)
	ON_COMMAND(IDC_COLORBAR, OnColorBar)
	ON_COMMAND(IDC_COLORBAR2, OnColorBar2)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPage2 message handlers

BOOL CPage2::OnInitDialog()
{
	CMFCPropertyPage::OnInitDialog();

	// Create color picker:
	m_ColorPicker.EnableAutomaticButton(_T("Automatic"), RGB(255, 0, 255));
	m_ColorPicker.EnableOtherButton(_T("Other"));
	m_ColorPicker.SetColor((COLORREF)-1);
	m_ColorPicker.SetColumnsNumber(10);

	// Create regular color bar:
	CRect rectColorBar;
	m_wndColorBarFrame.GetClientRect(&rectColorBar);
	m_wndColorBarFrame.MapWindowPoints(this, &rectColorBar);

	// <snippet2>
	// set the margins
	m_wndColorBar.SetHorzMargin(0);
	m_wndColorBar.SetVertMargin(0);
	// enable the display of a dialog box that 
	// lets the user select more colors
	m_wndColorBar.EnableOtherButton(_T("Other..."));
	// create a color bar control window
	m_wndColorBar.CreateControl(this, rectColorBar, IDC_COLORBAR, 5 /* columns */);
	// set the currently selected color
	m_wndColorBar.SetColor(RGB(255, 0, 0));
	// </snippet2>

	// Create regular color bar with the custom palette:
	m_wndColorBarFrame2.GetClientRect(&rectColorBar);
	m_wndColorBarFrame2.MapWindowPoints(this, &rectColorBar);

	// Create the palette
#define NUM_COLOURS 64
	struct
	{
		LOGPALETTE    LogPalette;
		PALETTEENTRY  PalEntry[NUM_COLOURS];
	}pal;

	LOGPALETTE* pLogPalette = (LOGPALETTE*) &pal;
	pLogPalette->palVersion    = 0x300;
	pLogPalette->palNumEntries = (WORD) NUM_COLOURS;

	COLORREF colorStart = RGB(0, 0, 255);
	COLORREF colorFinish = RGB(255, 255, 255);

	int nShift = 6;
	for (int i = 0; i < NUM_COLOURS; i++)
	{
		BYTE bR = (BYTE)((GetRValue(colorStart) *(NUM_COLOURS - i) + GetRValue(colorFinish) * i) >> nShift);
		BYTE bG = (BYTE)((GetGValue(colorStart) *(NUM_COLOURS - i) + GetGValue(colorFinish) * i) >> nShift);
		BYTE bB = (BYTE)((GetBValue(colorStart) *(NUM_COLOURS - i) + GetBValue(colorFinish) * i) >> nShift);

		pLogPalette->palPalEntry[i].peRed   = bR;
		pLogPalette->palPalEntry[i].peGreen = bG;
		pLogPalette->palPalEntry[i].peBlue  = bB;
		pLogPalette->palPalEntry[i].peFlags = 0;
	}

	m_palColorPicker.CreatePalette(pLogPalette);
	m_wndColorBar2.SetHorzMargin(0);
	m_wndColorBar2.SetVertMargin(0);

	m_wndColorBar2.CreateControl(this, rectColorBar, IDC_COLORBAR2, -1 /* columns */, &m_palColorPicker);
	m_wndColorBar2.SetColor(colorStart);

	// Create system palette:
	CClientDC dc(this);

	int nColors = 256; // Use 256 first entries
	UINT nSize = sizeof(LOGPALETTE) +(sizeof(PALETTEENTRY) * nColors);
	LOGPALETTE *pLP = (LOGPALETTE *) new BYTE[nSize];

	pLP->palVersion = 0x300;
	pLP->palNumEntries = (USHORT) nColors;

	::GetSystemPaletteEntries(dc.GetSafeHdc(), 0, nColors, pLP->palPalEntry);

	m_palSys.CreatePalette(pLP);

	delete[] pLP;

	m_wndColorPalette.SetType(CMFCColorPickerCtrl::PICKER);
	m_wndColorPalette.SetPalette(&m_palSys);
	m_wndColorPalette.SetColor(RGB(0, 255, 0));

	// <snippet5>
	// CPalette m_palSys
	// set the type of the color picker control
	m_wndLum.SetType(CMFCColorPickerCtrl::LUMINANCE);
	m_wndLum.SetPalette(&m_palSys);
	// set the color, hue, luminance and saturation of the color picker control
	m_wndLum.SetColor(RGB(0, 255, 0));
	m_wndLum.SetHue(0.5);
	m_wndLum.SetLuminance(2.5);
	m_wndLum.SetLuminanceBarWidth(10);
	m_wndLum.SetSaturation(0.5);
	// </snippet5>

	UpdateData(FALSE);
	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}
void CPage2::OnColorDlg()
{
	// <snippet3>
	// COLORREF m_Color
	CMFCColorDialog dlg(m_Color, 0, this);
	dlg.SetCurrentColor(RGB(0,255,0));
	dlg.SetNewColor(RGB(0,0,255));
	// set the red, green, and blue components of a selected
	// color on the two property pages of the color dialog
	dlg.SetPageOne(255,0,0);
	dlg.SetPageTwo(0,255,0);
    // </snippet3>

	if (dlg.DoModal() == IDOK)
	{
		m_Color = dlg.GetColor();

		m_strRGBColorDialog.Format(_T("%d,%d,%d"), GetRValue(m_Color), GetGValue(m_Color), GetBValue(m_Color));

		UpdateData(FALSE);
	}
	
}

void CPage2::OnColorPicker()
{
	COLORREF color = m_ColorPicker.GetColor();
	if (color == -1)
	{
		color = m_ColorPicker.GetAutomaticColor();
	}

	m_strRGB.Format(_T("%d,%d,%d"), GetRValue(color), GetGValue(color), GetBValue(color));

	UpdateData(FALSE);
}

void CPage2::OnColorBar()
{
	COLORREF color = m_wndColorBar.GetColor();

	m_strRGBColorBar.Format(_T("%d,%d,%d"), GetRValue(color), GetGValue(color), GetBValue(color));

	UpdateData(FALSE);
}

void CPage2::OnColorBar2()
{
	COLORREF color = m_wndColorBar2.GetColor();

	m_strRGBColorBar2.Format(_T("%d,%d,%d"), GetRValue(color), GetGValue(color), GetBValue(color));

	UpdateData(FALSE);
}

void CPage2::OnColorPalette()
{
	COLORREF color = m_wndColorPalette.GetColor();

	m_strRGBColorPalette.Format(_T("%d,%d,%d"), GetRValue(color), GetGValue(color), GetBValue(color));

	m_wndLum.SetColor(color);
	UpdateData(FALSE);
}

void CPage2::OnLum()
{
	COLORREF color = m_wndLum.GetColor();

	m_strRGBColorPalette.Format(_T("%d,%d,%d"), GetRValue(color), GetGValue(color), GetBValue(color));

	m_wndColorPalette.SetLuminance(m_wndLum.GetLuminance());
	UpdateData(FALSE);
}

