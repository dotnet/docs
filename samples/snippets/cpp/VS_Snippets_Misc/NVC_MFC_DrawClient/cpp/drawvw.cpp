// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include <afxpriv.h>

#include "DrawClient.h"

#include "drawdoc.h"
#include "drawobj.h"
#include "cntritem.h"
#include "drawvw.h"

#include "drawobj.h"
#include "drawtool.h"
#include "mainfrm.h"

#include "LineWeightDlg.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

// private clipboard format(list of Draw objects)
CLIPFORMAT CDrawView::m_cfDraw = (CLIPFORMAT)
::RegisterClipboardFormat(_T("MFC Draw Sample"));
CLIPFORMAT CDrawView::m_cfObjectDescriptor = NULL;

/////////////////////////////////////////////////////////////////////////////
// CDrawView

IMPLEMENT_DYNCREATE(CDrawView, CScrollView)

BEGIN_MESSAGE_MAP(CDrawView, CScrollView)
	//{{AFX_MSG_MAP(CDrawView)
	ON_COMMAND(ID_OLE_INSERT_NEW, OnInsertObject)
	ON_COMMAND(ID_CANCEL_EDIT, OnCancelEdit)
	ON_WM_LBUTTONDOWN()
	ON_WM_LBUTTONUP()
	ON_WM_MOUSEMOVE()
	ON_WM_LBUTTONDBLCLK()
	ON_COMMAND(ID_DRAW_SELECT, OnDrawSelect)
	ON_COMMAND(ID_DRAW_ROUNDRECT, OnDrawRoundRect)
	ON_COMMAND(ID_DRAW_RECT, OnDrawRect)
	ON_COMMAND(ID_DRAW_LINE, OnDrawLine)
	ON_COMMAND(ID_DRAW_ELLIPSE, OnDrawEllipse)
	ON_UPDATE_COMMAND_UI(ID_DRAW_ELLIPSE, OnUpdateDrawEllipse)
	ON_UPDATE_COMMAND_UI(ID_DRAW_LINE, OnUpdateDrawLine)
	ON_UPDATE_COMMAND_UI(ID_DRAW_RECT, OnUpdateDrawRect)
	ON_UPDATE_COMMAND_UI(ID_DRAW_ROUNDRECT, OnUpdateDrawRoundRect)
	ON_UPDATE_COMMAND_UI(ID_DRAW_SELECT, OnUpdateDrawSelect)
	ON_UPDATE_COMMAND_UI(ID_OBJECT_MOVEBACK, OnUpdateSingleSelect)
	ON_COMMAND(ID_EDIT_SELECT_ALL, OnEditSelectAll)
	ON_COMMAND(ID_EDIT_CLEAR, OnEditClear)
	ON_UPDATE_COMMAND_UI(ID_EDIT_CLEAR, OnUpdateAnySelect)
	ON_COMMAND(ID_DRAW_POLYGON, OnDrawPolygon)
	ON_UPDATE_COMMAND_UI(ID_DRAW_POLYGON, OnUpdateDrawPolygon)
	ON_WM_SIZE()
	ON_COMMAND(ID_VIEW_GRID, OnViewGrid)
	ON_UPDATE_COMMAND_UI(ID_VIEW_GRID, OnUpdateViewGrid)
	ON_WM_ERASEBKGND()
	ON_COMMAND(ID_OBJECT_FILLCOLOR, OnObjectFillColor)
	ON_UPDATE_COMMAND_UI(ID_OBJECT_FILLCOLOR, OnUpdateObjectFillColor)
	ON_COMMAND(ID_OBJECT_NOFILL, OnObjectNoFill)
	ON_UPDATE_COMMAND_UI(ID_OBJECT_NOFILL, OnUpdateObjectNoFill)
	ON_COMMAND(ID_OBJECT_LINECOLOR, OnObjectLineColor)
	ON_UPDATE_COMMAND_UI(ID_OBJECT_LINECOLOR, OnUpdateObjectLineColor)
	ON_COMMAND(ID_OBJECT_NOLINE, OnObjectNoLine)
	ON_UPDATE_COMMAND_UI(ID_OBJECT_NOLINE, OnUpdateObjectNoLine)
	ON_COMMAND_RANGE(ID_OBJECT_LINEWEIGHT, ID_OBJECT_LINEWEIGHT_MORE, OnObjectLineWeight)
	ON_UPDATE_COMMAND_UI_RANGE(ID_OBJECT_LINEWEIGHT, ID_OBJECT_LINEWEIGHT_MORE, OnUpdateObjectLineWeight)
	ON_COMMAND(ID_OBJECT_PROPERTIES, OnObjectProperties)
	ON_UPDATE_COMMAND_UI(ID_OBJECT_PROPERTIES, OnUpdateObjectProperties)
	ON_COMMAND(ID_OBJECT_STYLES, OnObjectStyles)
	ON_UPDATE_COMMAND_UI(ID_OBJECT_STYLES, OnUpdateObjectStyles)
	ON_COMMAND(ID_OBJECT_MOVEBACK, OnObjectMoveBack)
	ON_COMMAND(ID_OBJECT_MOVEFORWARD, OnObjectMoveForward)
	ON_COMMAND(ID_OBJECT_MOVETOBACK, OnObjectMoveToBack)
	ON_COMMAND(ID_OBJECT_MOVETOFRONT, OnObjectMoveToFront)
	ON_COMMAND(ID_EDIT_COPY, OnEditCopy)
	ON_UPDATE_COMMAND_UI(ID_EDIT_COPY, OnUpdateEditCopy)
	ON_COMMAND(ID_EDIT_CUT, OnEditCut)
	ON_UPDATE_COMMAND_UI(ID_EDIT_CUT, OnUpdateEditCut)
	ON_COMMAND(ID_EDIT_PASTE, OnEditPaste)
	ON_UPDATE_COMMAND_UI(ID_EDIT_PASTE, OnUpdateEditPaste)
	ON_WM_SETFOCUS()
	ON_COMMAND(ID_VIEW_SHOWOBJECTS, OnViewShowObjects)
	ON_UPDATE_COMMAND_UI(ID_VIEW_SHOWOBJECTS, OnUpdateViewShowObjects)
	ON_WM_DESTROY()
	ON_UPDATE_COMMAND_UI(ID_EDIT_SELECT_ALL, OnUpdateEditSelectAll)
	ON_WM_CREATE()
	ON_UPDATE_COMMAND_UI(ID_OBJECT_MOVEFORWARD, OnUpdateSingleSelect)
	ON_UPDATE_COMMAND_UI(ID_OBJECT_MOVETOBACK, OnUpdateSingleSelect)
	ON_UPDATE_COMMAND_UI(ID_OBJECT_MOVETOFRONT, OnUpdateSingleSelect)
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, OnFilePrint)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDrawView construction/destruction

CDrawView::CDrawView()
{
	m_bGrid = TRUE;
	m_gridColor = RGB(0, 0, 128);
	m_bActive = FALSE;
	// new
	if ( m_cfObjectDescriptor == NULL )
		m_cfObjectDescriptor = (CLIPFORMAT)::RegisterClipboardFormat(_T("Object Descriptor") );
	m_prevDropEffect = DROPEFFECT_NONE;
	// end new
}

CDrawView::~CDrawView()
{
	ResetPreviewState();
}

BOOL CDrawView::PreCreateWindow(CREATESTRUCT& cs)
{
	ASSERT(cs.style & WS_CHILD);
	if (cs.lpszClass == NULL)
		cs.lpszClass = AfxRegisterWndClass(CS_DBLCLKS);
	return TRUE;
}

void CDrawView::OnActivateView(BOOL bActivate, CView* pActiveView, CView* pDeactiveView)
{
	CView::OnActivateView(bActivate, pActiveView, pDeactiveView);

	if (!bActivate && GetDocument()->CanDeactivateInplace())
	{
		COleClientItem* pActiveItem = GetDocument()->GetInPlaceActiveItem(this);
		if (pActiveItem != NULL && pActiveItem->GetItemState() == COleClientItem::activeUIState)
		{
			pActiveItem->Deactivate();
		}
	}

	// invalidate selections when active status changes
	if (m_bActive != bActivate)
	{
		if (bActivate)  // if becoming active update as if active
			m_bActive = bActivate;
		if (!m_selection.IsEmpty())
			OnUpdate(NULL, HINT_UPDATE_SELECTION, NULL);
		m_bActive = bActivate;
	}

	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);
	((CMainFrame*)AfxGetMainWnd())->UpdateContextTab(this);
}

/////////////////////////////////////////////////////////////////////////////
// CDrawView drawing

void CDrawView::InvalObj(CDrawObj* pObj)
{
	CRect rect = pObj->m_position;
	DocToClient(rect);
	if (m_bActive && IsSelected(pObj))
	{
		rect.left -= 4;
		rect.top -= 5;
		rect.right += 5;
		rect.bottom += 4;
	}
	rect.InflateRect(1, 1); // handles CDrawOleObj objects

	InvalidateRect(rect, FALSE);
}

void CDrawView::OnUpdate(CView* , LPARAM lHint, CObject* pHint)
{
	switch (lHint)
	{
	case HINT_UPDATE_WINDOW:    // redraw entire window
		Invalidate(FALSE);
		break;

	case HINT_UPDATE_DRAWOBJ:   // a single object has changed
		InvalObj((CDrawObj*)pHint);
		break;

	case HINT_UPDATE_SELECTION: // an entire selection has changed
		{
			CDrawObjList* pList = pHint != NULL ?
				(CDrawObjList*)pHint : &m_selection;
			POSITION pos = pList->GetHeadPosition();
			while (pos != NULL)
			{
				InvalObj(pList->GetNext(pos));
			}
			((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);
		}
		break;

	case HINT_DELETE_SELECTION: // an entire selection has been removed
		if (pHint != &m_selection)
		{
			CDrawObjList* pList = (CDrawObjList*)pHint;
			POSITION pos = pList->GetHeadPosition();
			while (pos != NULL)
			{
				CDrawObj* pObj = pList->GetNext(pos);
				InvalObj(pObj);
				Remove(pObj);   // remove it from this view's selection
			}
		}
		((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);
		break;

	case HINT_UPDATE_OLE_ITEMS:
		{
			CDrawDoc* pDoc = GetDocument();
			POSITION pos = pDoc->GetObjects()->GetHeadPosition();
			while (pos != NULL)
			{
				CDrawObj* pObj = pDoc->GetObjects()->GetNext(pos);
				if (pObj->IsKindOf(RUNTIME_CLASS(CDrawOleObj)))
					InvalObj(pObj);
			}
		}
		break;

	default:
		ASSERT(FALSE);
		break;
	}
}

void CDrawView::OnPrepareDC(CDC* pDC, CPrintInfo* pInfo)
{
	CScrollView::OnPrepareDC(pDC, pInfo);

	// mapping mode is MM_ANISOTROPIC
	// these extents setup a mode similar to MM_LOENGLISH
	// MM_LOENGLISH is in .01 physical inches
	// these extents provide .01 logical inches

	pDC->SetMapMode(MM_ANISOTROPIC);
	pDC->SetViewportExt(pDC->GetDeviceCaps(LOGPIXELSX), pDC->GetDeviceCaps(LOGPIXELSY));
	pDC->SetWindowExt(100, -100);

	// set the origin of the coordinate system to the center of the page
	CPoint ptOrg;
	ptOrg.x = GetDocument()->GetSize().cx / 2;
	ptOrg.y = GetDocument()->GetSize().cy / 2;

	// ptOrg is in logical coordinates
	pDC->OffsetWindowOrg(-ptOrg.x,ptOrg.y);
}

BOOL CDrawView::OnScrollBy(CSize sizeScroll, BOOL bDoScroll)
{
	// do the scroll
	if (!CScrollView::OnScrollBy(sizeScroll, bDoScroll))
		return FALSE;

	// update the position of any in-place active item
	if (bDoScroll)
	{
		UpdateActiveItem();
		UpdateWindow();
	}
	return TRUE;
}

void CDrawView::OnDraw(CDC* pDC)
{
	CDrawDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	CDC dc;
	CDC* pDrawDC = pDC;
	CBitmap bitmap;
	CBitmap* pOldBitmap = 0;

	// only paint the rect that needs repainting
	CRect client;
	pDC->GetClipBox(client);
	CRect rect = client;
	DocToClient(rect);

	if (!pDC->IsPrinting())
	{
		// draw to offscreen bitmap for fast looking repaints
		if (dc.CreateCompatibleDC(pDC))
		{
			if (bitmap.CreateCompatibleBitmap(pDC, rect.Width(), rect.Height()))
			{
				OnPrepareDC(&dc, NULL);
				pDrawDC = &dc;

				// offset origin more because bitmap is just piece of the whole drawing
				dc.OffsetViewportOrg(-rect.left, -rect.top);
				pOldBitmap = dc.SelectObject(&bitmap);
				dc.SetBrushOrg(rect.left % 8, rect.top % 8);

				// might as well clip to the same rectangle
				dc.IntersectClipRect(client);
			}
		}
	}

	// paint background
	CBrush brush;
	if (!brush.CreateSolidBrush(pDoc->GetPaperColor()))
		return;

	brush.UnrealizeObject();
	pDrawDC->FillRect(client, &brush);

	if (!pDC->IsPrinting() && m_bGrid)
		DrawGrid(pDrawDC);

	pDoc->Draw(pDrawDC, this);

	if (pDrawDC != pDC)
	{
		pDC->SetViewportOrg(0, 0);
		pDC->SetWindowOrg(0,0);
		pDC->SetMapMode(MM_TEXT);
		dc.SetViewportOrg(0, 0);
		dc.SetWindowOrg(0,0);
		dc.SetMapMode(MM_TEXT);
		pDC->BitBlt(rect.left, rect.top, rect.Width(), rect.Height(), &dc, 0, 0, SRCCOPY);
		dc.SelectObject(pOldBitmap);
	}
}

void CDrawView::Remove(CDrawObj* pObj)
{
	POSITION pos = m_selection.Find(pObj);
	if (pos != NULL)
	{
		m_selection.RemoveAt(pos);
		((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);
		((CMainFrame*)AfxGetMainWnd())->UpdateContextTab(this);
	}
}

void CDrawView::PasteNative(COleDataObject& dataObject)
{
	// get file refering to clipboard data
	CFile* pFile = dataObject.GetFileData(m_cfDraw);
	if (pFile == NULL)
		return;

	// connect the file to the archive
	CArchive ar(pFile, CArchive::load);
	TRY
	{
		ar.m_pDocument = GetDocument(); // set back-pointer in archive

		// read the selection
		m_selection.Serialize(ar);
	}
	CATCH_ALL(e)
	{
		ar.Close();
		delete pFile;
		THROW_LAST();
	}
	END_CATCH_ALL

		ar.Close();
	delete pFile;
}

void CDrawView::PasteEmbedded(COleDataObject& dataObject, CPoint point )
{
	BeginWaitCursor();

	// paste embedded
	CDrawOleObj* pObj = new CDrawOleObj(GetInitialPosition());
	ASSERT_VALID(pObj);

#pragma warning(suppress:6014)
	CDrawItem* pItem = new CDrawItem(GetDocument(), pObj);
	ASSERT_VALID(pItem);
	pObj->m_pClientItem = pItem;

	TRY
	{
		if (!pItem->CreateFromData(&dataObject) && !pItem->CreateStaticFromData(&dataObject))
		{
			AfxThrowMemoryException();      // any exception will do
		}

		// add the object to the document
		GetDocument()->Add(pObj);
		m_selection.AddTail(pObj);

		((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);
		((CMainFrame*)AfxGetMainWnd())->UpdateContextTab(this);

		ClientToDoc( point );
		pObj->MoveTo( CRect( point, pObj->m_extent ), this );

		// try to get initial presentation data
		pItem->UpdateLink();
		pItem->UpdateExtent();
	}
	CATCH_ALL(e)
	{
		// clean up item
		pItem->Delete();
		pObj->m_pClientItem = NULL;
		GetDocument()->Remove(pObj);
		pObj->Remove();

		AfxMessageBox(IDP_FAILED_TO_CREATE);
	}
	END_CATCH_ALL

		EndWaitCursor();
}

void CDrawView::DrawGrid(CDC* pDC)
{
	CDrawDoc* pDoc = GetDocument();

	COLORREF oldBkColor = pDC->SetBkColor(pDoc->GetPaperColor());

	CRect rect;
	rect.left = -pDoc->GetSize().cx / 2;
	rect.top = -pDoc->GetSize().cy / 2;
	rect.right = rect.left + pDoc->GetSize().cx;
	rect.bottom = rect.top + pDoc->GetSize().cy;

	// Center lines
	CPen penDash;
	penDash.CreatePen(PS_DASH, 0, m_gridColor);
	CPen* pOldPen = pDC->SelectObject(&penDash);

	pDC->MoveTo(0, rect.top);
	pDC->LineTo(0, rect.bottom);
	pDC->MoveTo(rect.left, 0);
	pDC->LineTo(rect.right, 0);

	// Major unit lines
	CPen penDot;
	penDot.CreatePen(PS_DOT, 0, m_gridColor);
	pDC->SelectObject(&penDot);

	for (int x = rect.left / 100 * 100; x < rect.right; x += 100)
	{
		if (x != 0)
		{
			pDC->MoveTo(x, rect.top);
			pDC->LineTo(x, rect.bottom);
		}
	}

	for (int y = rect.top / 100 * 100; y < rect.bottom; y += 100)
	{
		if (y != 0)
		{
			pDC->MoveTo(rect.left, y);
			pDC->LineTo(rect.right, y);
		}
	}

	// Outlines
	CPen penSolid;
	penSolid.CreatePen(PS_SOLID, 0, m_gridColor);
	pDC->SelectObject(&penSolid);
	pDC->MoveTo(rect.left, rect.top);
	pDC->LineTo(rect.right, rect.top);
	pDC->LineTo(rect.right, rect.bottom);
	pDC->LineTo(rect.left, rect.bottom);
	pDC->LineTo(rect.left, rect.top);

	pDC->SelectObject(pOldPen);
	pDC->SetBkColor(oldBkColor);
}

void CDrawView::OnInitialUpdate()
{
	CSize size = GetDocument()->GetSize();
	CClientDC dc(NULL);
	size.cx = MulDiv(size.cx, dc.GetDeviceCaps(LOGPIXELSX), 100);
	size.cy = MulDiv(size.cy, dc.GetDeviceCaps(LOGPIXELSY), 100);
	SetScrollSizes(MM_TEXT, size);
}

void CDrawView::SetPageSize(CSize size)
{
	CClientDC dc(NULL);
	size.cx = MulDiv(size.cx, dc.GetDeviceCaps(LOGPIXELSX), 100);
	size.cy = MulDiv(size.cy, dc.GetDeviceCaps(LOGPIXELSY), 100);
	SetScrollSizes(MM_TEXT, size);
	GetDocument()->UpdateAllViews(NULL, HINT_UPDATE_WINDOW, NULL);
}

/////////////////////////////////////////////////////////////////////////////
// CDrawView printing

BOOL CDrawView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CDrawView::OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	CScrollView::OnBeginPrinting(pDC,pInfo);

	// check page size -- user could have gone into print setup
	// from print dialog and changed paper or orientation
	GetDocument()->ComputePageSize();
}

void CDrawView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

/////////////////////////////////////////////////////////////////////////////
// OLE Client support and commands

BOOL CDrawView::IsSelected(const CObject* pDocItem) const
{
	CDrawObj* pDrawObj = (CDrawObj*)pDocItem;
	if (pDocItem->IsKindOf(RUNTIME_CLASS(CDrawItem)))
		pDrawObj = ((CDrawItem*)pDocItem)->m_pDrawObj;
	return m_selection.Find(pDrawObj) != NULL;
}

void CDrawView::OnInsertObject()
{
	// Invoke the standard Insert Object dialog box to obtain information
	//  for new CDrawItem object.
	COleInsertDialog dlg;
	if (dlg.DoModal() != IDOK)
		return;

	BeginWaitCursor();

	// First create the C++ object
	CDrawOleObj* pObj = new CDrawOleObj(GetInitialPosition());
	ASSERT_VALID(pObj);
	CDrawItem* pItem = new CDrawItem(GetDocument(), pObj);
	ASSERT_VALID(pItem);
	pObj->m_pClientItem = pItem;

	// Now create the OLE object/item
	TRY
	{
		if (!dlg.CreateItem(pObj->m_pClientItem))
			AfxThrowMemoryException();

		// add the object to the document
		GetDocument()->Add(pObj);

		// try to get initial presentation data
		pItem->UpdateLink();
		pItem->UpdateExtent();

		// if insert new object -- initially show the object
		if (dlg.GetSelectionType() == COleInsertDialog::createNewItem)
			pItem->DoVerb(OLEIVERB_SHOW, this);
	}
	CATCH_ALL(e)
	{
		// clean up item
		pItem->Delete();
		pObj->m_pClientItem = NULL;
		GetDocument()->Remove(pObj);
		pObj->Remove();

		AfxMessageBox(IDP_FAILED_TO_CREATE);
	}
	END_CATCH_ALL

		EndWaitCursor();
}

// The following command handler provides the standard keyboard
//  user interface to cancel an in-place editing session.
void CDrawView::OnCancelEdit()
{
	// deactivate any in-place active item on this view!
	COleClientItem* pActiveItem = GetDocument()->GetInPlaceActiveItem(this);
	if (pActiveItem != NULL)
	{
		// if we found one, deactivate it
		pActiveItem->Close();
	}
	ASSERT(GetDocument()->GetInPlaceActiveItem(this) == NULL);

	// escape also brings us back into select mode
	ReleaseCapture();

	CDrawTool* pTool = CDrawTool::FindTool(CDrawTool::c_drawShape);
	if (pTool != NULL)
	{
		pTool->OnCancel();
	}

	CDrawTool::c_drawShape = selection;
}

void CDrawView::OnSetFocus(CWnd* pOldWnd)
{
	COleClientItem* pActiveItem = GetDocument()->GetInPlaceActiveItem(this);
	if (pActiveItem != NULL && pActiveItem->GetItemState() == COleClientItem::activeUIState)
	{
		// need to set focus to this item if it is in the same view
		CWnd* pWnd = pActiveItem->GetInPlaceWindow();
		if (pWnd != NULL)
		{
			pWnd->SetFocus();
			return;
		}
	}

	CScrollView::OnSetFocus(pOldWnd);
}

CRect CDrawView::GetInitialPosition()
{
	CRect rect(10, 10, 10, 10);
	ClientToDoc(rect);
	return rect;
}

void CDrawView::ClientToDoc(CPoint& point)
{
	CClientDC dc(this);
	OnPrepareDC(&dc, NULL);
	dc.DPtoLP(&point);
}

void CDrawView::ClientToDoc(CRect& rect)
{
	CClientDC dc(this);
	OnPrepareDC(&dc, NULL);
	dc.DPtoLP(rect);
	ASSERT(rect.left <= rect.right);
	ASSERT(rect.bottom <= rect.top);
}

void CDrawView::DocToClient(CPoint& point)
{
	CClientDC dc(this);
	OnPrepareDC(&dc, NULL);
	dc.LPtoDP(&point);
}

void CDrawView::DocToClient(CRect& rect)
{
	CClientDC dc(this);
	OnPrepareDC(&dc, NULL);
	dc.LPtoDP(rect);
	rect.NormalizeRect();
}

void CDrawView::Select(CDrawObj* pObj, BOOL bAdd)
{
	if (!bAdd)
	{
		OnUpdate(NULL, HINT_UPDATE_SELECTION, NULL);
		m_selection.RemoveAll();
		((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);
	}

	if (pObj == NULL || IsSelected(pObj))
	{
		((CMainFrame*)AfxGetMainWnd())->UpdateContextTab(this);
		return;
	}

	m_selection.AddTail(pObj);
	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);
	InvalObj(pObj);

	((CMainFrame*)AfxGetMainWnd())->UpdateContextTab(this);
}

// rect is in device coordinates
void CDrawView::SelectWithinRect(CRect rect, BOOL bAdd)
{
	if (!bAdd)
		Select(NULL);

	ClientToDoc(rect);

	CDrawObjList* pObList = GetDocument()->GetObjects();
	POSITION posObj = pObList->GetHeadPosition();
	while (posObj != NULL)
	{
		CDrawObj* pObj = pObList->GetNext(posObj);
		if (pObj->Intersects(rect))
			Select(pObj, TRUE);
	}
}

void CDrawView::Deselect(CDrawObj* pObj)
{
	POSITION pos = m_selection.Find(pObj);
	if (pos != NULL)
	{
		InvalObj(pObj);
		m_selection.RemoveAt(pos);
		((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);
		((CMainFrame*)AfxGetMainWnd())->UpdateContextTab(this);
	}
}

void CDrawView::CloneSelection()
{
	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		pObj->Clone(pObj->m_pDocument);
		// copies object and adds it to the document
	}
}

void CDrawView::UpdateActiveItem()
{
	COleClientItem* pActiveItem = GetDocument()->GetInPlaceActiveItem(this);
	if (pActiveItem != NULL && pActiveItem->GetItemState() == COleClientItem::activeUIState)
	{
		// this will update the item rectangles by calling
		//  OnGetPosRect & OnGetClipRect.
		pActiveItem->SetItemRects();
	}
}

/////////////////////////////////////////////////////////////////////////////
// CDrawView message handlers

void CDrawView::OnLButtonDown(UINT nFlags, CPoint point)
{
	if (!m_bActive)
		return;
	CDrawTool* pTool = CDrawTool::FindTool(CDrawTool::c_drawShape);
	if (pTool != NULL)
	{
		pTool->OnLButtonDown(this, nFlags, point);
	}
}

void CDrawView::OnLButtonUp(UINT nFlags, CPoint point)
{
	if (!m_bActive)
		return;
	CDrawTool* pTool = CDrawTool::FindTool(CDrawTool::c_drawShape);
	if (pTool != NULL)
		pTool->OnLButtonUp(this, nFlags, point);
}

void CDrawView::OnMouseMove(UINT nFlags, CPoint point)
{
	if (!m_bActive)
		return;
	CDrawTool* pTool = CDrawTool::FindTool(CDrawTool::c_drawShape);
	if (pTool != NULL)
		pTool->OnMouseMove(this, nFlags, point);
}

void CDrawView::OnLButtonDblClk(UINT nFlags, CPoint point)
{
	if (!m_bActive)
		return;
	CDrawTool* pTool = CDrawTool::FindTool(CDrawTool::c_drawShape);
	if (pTool != NULL)
		pTool->OnLButtonDblClk(this, nFlags, point);
}

void CDrawView::OnDestroy()
{
	CScrollView::OnDestroy();

	// deactivate the inplace active item on this view
	COleClientItem* pActiveItem = GetDocument()->GetInPlaceActiveItem(this);
	if (pActiveItem != NULL && pActiveItem->GetActiveView() == this)
	{
		pActiveItem->Deactivate();
		ASSERT(GetDocument()->GetInPlaceActiveItem(this) == NULL);
	}
}

void CDrawView::OnDrawSelect()
{
	CDrawTool::c_drawShape = selection;
}

void CDrawView::OnDrawRoundRect()
{
	CDrawTool::c_drawShape = roundRect;
}

void CDrawView::OnDrawRect()
{
	CDrawTool::c_drawShape = rect;
}

void CDrawView::OnDrawLine()
{
	CDrawTool::c_drawShape = line;
}

void CDrawView::OnDrawEllipse()
{
	CDrawTool::c_drawShape = ellipse;
}

void CDrawView::OnDrawPolygon()
{
	CDrawTool::c_drawShape = poly;
}

void CDrawView::OnUpdateDrawEllipse(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio(CDrawTool::c_drawShape == ellipse);
}

void CDrawView::OnUpdateDrawLine(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio(CDrawTool::c_drawShape == line);
}

void CDrawView::OnUpdateDrawRect(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio(CDrawTool::c_drawShape == rect);
}

void CDrawView::OnUpdateDrawRoundRect(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio(CDrawTool::c_drawShape == roundRect);
}

void CDrawView::OnUpdateDrawSelect(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio(CDrawTool::c_drawShape == selection);
}

void CDrawView::OnUpdateSingleSelect(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(m_selection.GetCount() == 1);
}

void CDrawView::OnEditSelectAll()
{
	CDrawObjList* pObList = GetDocument()->GetObjects();
	POSITION pos = pObList->GetHeadPosition();
	while (pos != NULL)
		Select(pObList->GetNext(pos), TRUE);
}

void CDrawView::OnUpdateEditSelectAll(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(GetDocument()->GetObjects()->GetCount() != 0);
}

void CDrawView::OnEditClear()
{
	// update all the views before the selection goes away
	GetDocument()->UpdateAllViews(NULL, HINT_DELETE_SELECTION, &m_selection);
	OnUpdate(NULL, HINT_UPDATE_SELECTION, NULL);

	// now remove the selection from the document
	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		GetDocument()->Remove(pObj);
		pObj->Remove();
	}
	//Cleanup Tool members such as CPolyTool::m_pDrawObj, that should be NULL at this point.
	CDrawTool* pTool = CDrawTool::FindTool(CDrawTool::c_drawShape);
	if (pTool != NULL)
	{
		pTool->OnCancel();
	}
	m_selection.RemoveAll();
	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);
	((CMainFrame*)AfxGetMainWnd())->UpdateContextTab(this);
}

void CDrawView::OnUpdateAnySelect(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(!m_selection.IsEmpty());
}

void CDrawView::OnUpdateDrawPolygon(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio(CDrawTool::c_drawShape == poly);
}

void CDrawView::OnSize(UINT nType, int cx, int cy)
{
	CScrollView::OnSize(nType, cx, cy);
	UpdateActiveItem();
}

void CDrawView::OnViewGrid()
{
	m_bGrid = !m_bGrid;
	Invalidate(FALSE);
}

void CDrawView::OnUpdateViewGrid(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_bGrid);

}

BOOL CDrawView::OnEraseBkgnd(CDC*)
{
	return TRUE;
}

void CDrawView::OnUpdateSelection(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(!m_selection.IsEmpty());
}

void CDrawView::OnObjectFillColor()
{
	COLORREF color = ((CMainFrame*)AfxGetMainWnd())->GetColorFromColorButton(ID_OBJECT_FILLCOLOR);

	if (color == (COLORREF) -1)
	{
		return;
	}

	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		if (pObj->CanChangeFillColor())
		{
			pObj->EnableFill(TRUE);
			pObj->SetFillColor(color);
		}
	}

	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);

	Invalidate();

	ResetPreviewState();
}

void CDrawView::PreviewFillColor(COLORREF color)
{
	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);

		if (pObj->CanChangeFillColor())
		{
			pObj->EnableFill(TRUE);
			pObj->SetFillColor(color, TRUE /* Preview */);
		}
	}
}

void CDrawView::OnUpdateObjectFillColor(CCmdUI* pCmdUI)
{
	if (m_selection.GetCount() == 1)
	{
		pCmdUI->Enable(m_selection.GetHead()->CanChangeFillColor());
	}
	else
	{
		OnUpdateSelection(pCmdUI);
	}
}

void CDrawView::OnObjectNoFill()
{
	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		if (pObj->CanChangeFillColor())
		{
			pObj->EnableFill(FALSE);
		}
	}

	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);

	Invalidate();
}

void CDrawView::OnUpdateObjectNoFill(CCmdUI* pCmdUI)
{
	if (m_selection.GetCount() == 1)
	{
		pCmdUI->Enable(m_selection.GetHead()->CanChangeFillColor());
		pCmdUI->SetCheck(!m_selection.GetHead()->IsEnableFill());
	}
	else
	{
		OnUpdateSelection(pCmdUI);
	}
}

void CDrawView::OnObjectLineColor()
{
	COLORREF color = ((CMainFrame*)AfxGetMainWnd())->GetColorFromColorButton(ID_OBJECT_LINECOLOR);

	if (color == (COLORREF) -1)
	{
		return;
	}

	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		if (pObj->CanChangeLineColor())
		{
			pObj->EnableLine(TRUE);
			pObj->SetLineColor(color);
		}
	}

	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);

	Invalidate();

	ResetPreviewState();
}

void CDrawView::PreviewLineColor(COLORREF color)
{
	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		if (pObj->CanChangeLineColor())
		{
			pObj->EnableLine(TRUE);
			pObj->SetLineColor(color, TRUE /* Preview */);
		}
	}
}

void CDrawView::OnUpdateObjectLineColor(CCmdUI* pCmdUI)
{
	if (m_selection.GetCount() == 1)
	{
		pCmdUI->Enable(m_selection.GetHead()->CanChangeLineColor());
	}
	else
	{
		OnUpdateSelection(pCmdUI);
	}
}

void CDrawView::OnObjectNoLine()
{
	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		if (pObj->CanChangeLineColor())
		{
			pObj->EnableLine(FALSE);
		}
	}

	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);

	Invalidate();

	ResetPreviewState();
}

void CDrawView::OnUpdateObjectNoLine(CCmdUI* pCmdUI)
{
	if (m_selection.GetCount() == 1)
	{
		pCmdUI->Enable(m_selection.GetHead()->CanChangeLineColor());
		pCmdUI->SetCheck(!m_selection.GetHead()->IsEnableLine());
	}
	else
	{
		OnUpdateSelection(pCmdUI);
	}
}

void CDrawView::OnObjectLineWeight(UINT nID)
{
	int weight = -1;
	if (nID == ID_OBJECT_LINEWEIGHT)
	{
		weight = ((CMainFrame*)AfxGetMainWnd())->GetWeightFromLineWeight(ID_OBJECT_LINEWEIGHT);
	}
	else if (nID == ID_OBJECT_LINEWEIGHT_MORE)
	{
		CLineWeightDlg dlg(AfxGetMainWnd());

		if (m_selection.GetCount() == 1)
		{
			dlg.m_penSize = m_selection.GetHead()->IsEnableLine() ? m_selection.GetHead()->GetLineWeight() : 0;
		}

		if (dlg.DoModal() == IDOK)
		{
			weight = dlg.m_penSize;
		}
	}

	if (weight == -1)
	{
		return;
	}

	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		if (pObj->CanChangeLineWeight())
		{
			pObj->EnableLine(weight > 0);
			pObj->SetLineWeight(weight);
		}
	}

	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);

	Invalidate();

	ResetPreviewState();
}

void CDrawView::PreviewLineWeight(int weight)
{
	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		if (pObj->CanChangeLineWeight())
		{
			pObj->EnableLine(weight > 0);
			pObj->SetLineWeight(weight);
		}
	}
}

void CDrawView::OnUpdateObjectLineWeight(CCmdUI* pCmdUI)
{
	if (m_selection.GetCount() == 1)
	{
		pCmdUI->Enable(m_selection.GetHead()->CanChangeLineWeight());
	}
	else
	{
		OnUpdateSelection(pCmdUI);
	}
}

void CDrawView::OnObjectProperties()
{
	CDrawObj* pObj = m_selection.GetHead();
	if (pObj != NULL)
	{
		pObj->OnEditProperties();
	}
}

void CDrawView::OnUpdateObjectProperties(CCmdUI* pCmdUI)
{
	BOOL bEnable = m_selection.GetCount() == 1;
	if (bEnable)
	{
		bEnable = DYNAMIC_DOWNCAST(CDrawOleObj, m_selection.GetHead()) == NULL;
	}

	pCmdUI->Enable(bEnable);
}

void CDrawView::OnObjectStyles()
{
	CMainFrame::XStyle style;

	if (!((CMainFrame*)AfxGetMainWnd())->GetStyleFromStyles(style))
	{
		return;
	}

	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);

		if (pObj->CanChangeFillColor())
		{
			pObj->EnableFill(style.clrFill != (COLORREF)-1);
			if (style.clrFill != (COLORREF)-1)
			{
				pObj->SetFillColor(style.clrFill, TRUE);
			}
		}
		if (pObj->CanChangeLineColor())
		{
			pObj->EnableLine(style.clrLine != (COLORREF)-1);
			if (style.clrLine != (COLORREF)-1)
			{
				pObj->SetLineColor(style.clrLine, TRUE);
			}
		}
	}

	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);

	Invalidate();

	ResetPreviewState();
}

void CDrawView::PreviewStyle(COLORREF clrFill, COLORREF clrLine)
{
	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);

		if (pObj->CanChangeFillColor())
		{
			pObj->EnableFill(clrFill != (COLORREF)-1);
			if (clrFill != (COLORREF)-1)
			{
				pObj->SetFillColor(clrFill);
			}
		}
		if (pObj->CanChangeLineColor())
		{
			pObj->EnableLine(clrLine != (COLORREF)-1);
			if (clrLine != (COLORREF)-1)
			{
				pObj->SetLineColor(clrLine);
			}
		}
	}
}

void CDrawView::OnUpdateObjectStyles(CCmdUI* pCmdUI)
{
	if (m_selection.GetCount() == 1)
	{
		pCmdUI->Enable(m_selection.GetHead()->CanChangeFillColor());
	}
	else
	{
		OnUpdateSelection(pCmdUI);
	}
}

void CDrawView::OnObjectMoveBack()
{
	CDrawDoc* pDoc = GetDocument();
	CDrawObj* pObj = m_selection.GetHead();
	CDrawObjList* pObjects = pDoc->GetObjects();
	POSITION pos = pObjects->Find(pObj);
	ASSERT(pos != NULL);
	if (pos != pObjects->GetHeadPosition())
	{
		POSITION posPrev = pos;
		pObjects->GetPrev(posPrev);
		pObjects->RemoveAt(pos);
		pObjects->InsertBefore(posPrev, pObj);
		InvalObj(pObj);
	}
}

void CDrawView::OnObjectMoveForward()
{
	CDrawDoc* pDoc = GetDocument();
	CDrawObj* pObj = m_selection.GetHead();
	CDrawObjList* pObjects = pDoc->GetObjects();
	POSITION pos = pObjects->Find(pObj);
	ASSERT(pos != NULL);
	if (pos != pObjects->GetTailPosition())
	{
		POSITION posNext = pos;
		pObjects->GetNext(posNext);
		pObjects->RemoveAt(pos);
		pObjects->InsertAfter(posNext, pObj);
		InvalObj(pObj);
	}
}

void CDrawView::OnObjectMoveToBack()
{
	CDrawDoc* pDoc = GetDocument();
	CDrawObj* pObj = m_selection.GetHead();
	CDrawObjList* pObjects = pDoc->GetObjects();
	POSITION pos = pObjects->Find(pObj);
	ASSERT(pos != NULL);
	pObjects->RemoveAt(pos);
	pObjects->AddHead(pObj);
	InvalObj(pObj);
}

void CDrawView::OnObjectMoveToFront()
{
	CDrawDoc* pDoc = GetDocument();
	CDrawObj* pObj = m_selection.GetHead();
	CDrawObjList* pObjects = pDoc->GetObjects();
	POSITION pos = pObjects->Find(pObj);
	ASSERT(pos != NULL);
	pObjects->RemoveAt(pos);
	pObjects->AddTail(pObj);
	InvalObj(pObj);
}

void CDrawView::OnEditCopy()
{
	ASSERT_VALID(this);
	ASSERT(m_cfDraw != NULL);

	// Create a shared file and associate a CArchive with it
	CSharedFile file;
	CArchive ar(&file, CArchive::store);

	// Serialize selected objects to the archive
	m_selection.Serialize(ar);
	ar.Close();

	COleDataSource* pDataSource = NULL;
	TRY
	{
		pDataSource = new COleDataSource;
		// put on local format instead of or in addation to
		pDataSource->CacheGlobalData(m_cfDraw, file.Detach());

		// if only one item and it is a COleClientItem then also
		// paste in that format
		CDrawObj* pDrawObj = m_selection.GetHead();
		if (m_selection.GetCount() == 1 && pDrawObj->IsKindOf(RUNTIME_CLASS(CDrawOleObj)))
		{
			CDrawOleObj* pDrawOle = (CDrawOleObj*)pDrawObj;
			pDrawOle->m_pClientItem->GetClipboardData(pDataSource, FALSE);
		}

		pDataSource->SetClipboard();
	}
	CATCH_ALL(e)
	{
		delete pDataSource;
		THROW_LAST();
	}
	END_CATCH_ALL
}

void CDrawView::OnUpdateEditCopy(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(!m_selection.IsEmpty());
}

void CDrawView::OnEditCut()
{
	OnEditCopy();
	OnEditClear();
}

void CDrawView::OnUpdateEditCut(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(!m_selection.IsEmpty());
}

void CDrawView::OnEditPaste()
{
	COleDataObject dataObject;
	dataObject.AttachClipboard();

	// invalidate current selection since it will be deselected
	OnUpdate(NULL, HINT_UPDATE_SELECTION, NULL);
	m_selection.RemoveAll();
	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);

	if (dataObject.IsDataAvailable(m_cfDraw))
	{
		PasteNative(dataObject);

		// now add all items in m_selection to document
		POSITION pos = m_selection.GetHeadPosition();
		while (pos != NULL)
			GetDocument()->Add(m_selection.GetNext(pos));
	}
	else
		PasteEmbedded(dataObject, GetInitialPosition().TopLeft() );

	GetDocument()->SetModifiedFlag();

	// invalidate new pasted stuff
	GetDocument()->UpdateAllViews(NULL, HINT_UPDATE_SELECTION, &m_selection);

	((CMainFrame*)AfxGetMainWnd())->UpdateContextTab(this);
}

void CDrawView::OnUpdateEditPaste(CCmdUI* pCmdUI)
{
	// determine if private or standard OLE formats are on the clipboard
	COleDataObject dataObject;
	BOOL bEnable = dataObject.AttachClipboard() &&
		(dataObject.IsDataAvailable(m_cfDraw) || COleClientItem::CanCreateFromData(&dataObject));

	// enable command based on availability
	pCmdUI->Enable(bEnable);
}

void CDrawView::OnFilePrint()
{
	CScrollView::OnFilePrint();
	GetDocument()->ComputePageSize();
}

void CDrawView::OnViewShowObjects()
{
	CDrawOleObj::c_bShowItems = !CDrawOleObj::c_bShowItems;
	GetDocument()->UpdateAllViews(NULL, HINT_UPDATE_OLE_ITEMS, NULL);
}

void CDrawView::OnUpdateViewShowObjects(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(CDrawOleObj::c_bShowItems);
}

/////////////////////////////////////////////////////////////////////////////
// CDrawView diagnostics

#ifdef _DEBUG
void CDrawView::AssertValid() const
{
	CScrollView::AssertValid();
}

void CDrawView::Dump(CDumpContext& dc) const
{
	CScrollView::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// new
// support for drag/drop

int CDrawView::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CScrollView::OnCreate(lpCreateStruct) == -1)
		return -1;

	// register drop target
	if ( m_dropTarget.Register( this ) )
		return 0;
	else
		return -1;
}

BOOL CDrawView::GetObjectInfo(COleDataObject* pDataObject, CSize* pSize, CSize* pOffset)
{
	ENSURE(pSize != NULL);

	// get object descriptor data
	HGLOBAL hObjDesc = pDataObject->GetGlobalData(m_cfObjectDescriptor);
	if (hObjDesc == NULL)
	{
		if (pOffset != NULL)
			*pOffset = CSize(0, 0); // fill in defaults instead
		*pSize = CSize(0, 0);
		return FALSE;
	}
	ASSERT(hObjDesc != NULL);

	// otherwise, got CF_OBJECTDESCRIPTOR ok.  Lock it down and extract size.
	LPOBJECTDESCRIPTOR pObjDesc = (LPOBJECTDESCRIPTOR)GlobalLock(hObjDesc);
	ENSURE(pObjDesc != NULL);
	pSize->cx = (int)pObjDesc->sizel.cx;
	pSize->cy = (int)pObjDesc->sizel.cy;
	if (pOffset != NULL)
	{
		pOffset->cx = (int)pObjDesc->pointl.x;
		pOffset->cy = (int)pObjDesc->pointl.y;
	}
	GlobalUnlock(hObjDesc);
	GlobalFree(hObjDesc);

	// successfully retrieved pSize & pOffset info
	return TRUE;
}

DROPEFFECT CDrawView::OnDragEnter(COleDataObject* pDataObject, DWORD grfKeyState, CPoint point)
{
	ASSERT(m_prevDropEffect == DROPEFFECT_NONE);
	m_bDragDataAcceptable = FALSE;
	if (!COleClientItem::CanCreateFromData(pDataObject))
		return DROPEFFECT_NONE;

	m_bDragDataAcceptable = TRUE;
	GetObjectInfo(pDataObject, &m_dragSize, &m_dragOffset);
	CClientDC dc(NULL);
	dc.HIMETRICtoDP(&m_dragSize);
	dc.HIMETRICtoDP(&m_dragOffset);

	return OnDragOver(pDataObject, grfKeyState, point);
}

DROPEFFECT CDrawView::OnDragOver(COleDataObject*, DWORD grfKeyState, CPoint point)
{
	if (m_bDragDataAcceptable == FALSE)
		return DROPEFFECT_NONE;

	point -= m_dragOffset;  // adjust target rect by original cursor offset

	// check for point outside logical area -- i.e. in hatched region
	// GetTotalSize() returns the size passed to SetScrollSizes
	CRect rectScroll(CPoint(0, 0), GetTotalSize());

	CRect rectItem(point,m_dragSize);
	rectItem.OffsetRect(GetDeviceScrollPosition());

	DROPEFFECT de = DROPEFFECT_NONE;
	CRect rectTemp;
	if (rectTemp.IntersectRect(rectScroll, rectItem))
	{
		// check for force link
		if ((grfKeyState &(MK_CONTROL|MK_SHIFT)) == (MK_CONTROL|MK_SHIFT))
			de = DROPEFFECT_NONE; // DRAWCLI isn't a linking container
		// check for force copy
		else if ((grfKeyState & MK_CONTROL) == MK_CONTROL)
			de = DROPEFFECT_COPY;
		// check for force move
		else if ((grfKeyState & MK_ALT) == MK_ALT)
			de = DROPEFFECT_MOVE;
		// default -- recommended action is move
		else
			de = DROPEFFECT_MOVE;
	}

	if (point == m_dragPoint)
		return de;

	// otherwise, cursor has moved -- need to update the drag feedback
	CClientDC dc(this);
	if (m_prevDropEffect != DROPEFFECT_NONE)
	{
		// erase previous focus rect
		dc.DrawFocusRect(CRect(m_dragPoint, m_dragSize));
	}
	m_prevDropEffect = de;
	if (m_prevDropEffect != DROPEFFECT_NONE)
	{
		m_dragPoint = point;
		dc.DrawFocusRect(CRect(point, m_dragSize));
	}
	return de;
}

BOOL CDrawView::OnDrop(COleDataObject* pDataObject, DROPEFFECT /*dropEffect*/, CPoint point)
{
	ASSERT_VALID(this);

	// clean up focus rect
	OnDragLeave();

	// offset point as appropriate for dragging
	GetObjectInfo(pDataObject, &m_dragSize, &m_dragOffset);
	CClientDC dc(NULL);
	dc.HIMETRICtoDP(&m_dragSize);
	dc.HIMETRICtoDP(&m_dragOffset);
	point -= m_dragOffset;

	// invalidate current selection since it will be deselected
	OnUpdate(NULL, HINT_UPDATE_SELECTION, NULL);
	m_selection.RemoveAll();
	((CMainFrame*)AfxGetMainWnd())->UpdateUI(this);

	if (m_bDragDataAcceptable)
		PasteEmbedded(*pDataObject, point);

	// update the document and views
	GetDocument()->SetModifiedFlag();
	GetDocument()->UpdateAllViews(NULL, 0, NULL);      // including this view

	return TRUE;
}

void CDrawView::OnDragLeave()
{
	CClientDC dc(this);
	if (m_prevDropEffect != DROPEFFECT_NONE)
	{
		dc.DrawFocusRect(CRect(m_dragPoint,m_dragSize)); // erase previous focus rect
		m_prevDropEffect = DROPEFFECT_NONE;
	}
}

void CDrawView::OnContextMenu(CWnd* /*pWnd*/, CPoint point)
{
	// make sure window is active
	GetParentFrame()->ActivateFrame();

	CPoint local = point;
	ScreenToClient(&local);
	ClientToDoc(local);

	CDrawObj* pObj;
	pObj = GetDocument()->ObjectAt(local);
	if (pObj != NULL)
	{
		if (!IsSelected(pObj))
			Select( pObj, FALSE );          // reselect item if appropriate
		UpdateWindow();

		CMenu menu;
		if (menu.LoadMenu(ID_POPUP_MENU))
		{
			CMenu* pPopup = menu.GetSubMenu(0);
			ENSURE(pPopup != NULL);

			CMFCPopupMenu* pPopupMenu = new CMFCPopupMenu;
			pPopupMenu->SetAutoDestroy(FALSE);
			pPopupMenu->Create(this, point.x, point.y, pPopup->GetSafeHmenu());
		}
	}
}

void CDrawView::OnPrint(CDC* pDC, CPrintInfo* pInfo)
{
	if (pInfo->m_bPreview == FALSE)
		((CDrawDoc*)GetDocument())->m_pSummInfo->RecordPrintDate();
	OnDraw(pDC);
}

void CDrawView::OnFilePrintPreview()
{
	COleClientItem* pActiveItem = GetDocument()->GetInPlaceActiveItem(this);
	if (pActiveItem != NULL && pActiveItem->GetItemState() == COleClientItem::activeUIState)
	{
		pActiveItem->Deactivate();
	}

	AFXPrintPreview(this);
}

class CDrawObjFriend: public CDrawObj
{
	friend struct CDrawView::XPreviewStateItem;
};

void CDrawView::XPreviewStateItem::Store(const CDrawObj& rObj)
{
	const CDrawObjFriend* pMyObj = (CDrawObjFriend*)(&rObj);

	m_bPen   = pMyObj->m_bPen;
	memcpy(&m_logpen, &pMyObj->m_logpen, sizeof(LOGPEN));
	m_bBrush = pMyObj->m_bBrush;
	memcpy(&m_logbrush, &pMyObj->m_logbrush, sizeof(LOGBRUSH));
}

void CDrawView::XPreviewStateItem::Restore(CDrawObj& rObj) const
{
	CDrawObjFriend* pMyObj = (CDrawObjFriend*)(&rObj);

	pMyObj->m_bPen   = m_bPen;
	memcpy(&pMyObj->m_logpen, &m_logpen, sizeof(LOGPEN));
	pMyObj->m_bBrush = m_bBrush;
	memcpy(&pMyObj->m_logbrush, &m_logbrush, sizeof(LOGBRUSH));
}

void CDrawView::StorePreviewState()
{
	if (m_PreviewState.GetSize() > 0)
	{
		return;
	}

	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		if (pObj != NULL)
		{
			m_PreviewState.Add(new XPreviewStateItem(*pObj));
		}
	}
}

void CDrawView::RestorePreviewState(BOOL bReset)
{
	if (m_PreviewState.GetSize() == 0)
	{
		return;
	}

	int index = 0;

	POSITION pos = m_selection.GetHeadPosition();
	while (pos != NULL)
	{
		CDrawObj* pObj = m_selection.GetNext(pos);
		if (pObj != NULL)
		{
			m_PreviewState[index]->Restore(*pObj);
		}

		index++;
	}

	if (bReset)
	{
		ResetPreviewState();
	}

	Invalidate();
}

void CDrawView::ResetPreviewState()
{
	if (m_PreviewState.GetSize() == 0)
	{
		return;
	}

	for (int i = 0; i < m_PreviewState.GetSize(); i++)
	{
		delete m_PreviewState[i];
	}

	m_PreviewState.RemoveAll();
}

