// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// http://msdn.microsoft.com/officeui.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

#pragma once

class CMSOffice2007DemoDoc;
class CMSOffice2007DemoView;

class CMSOffice2007DemoCntrItem : public CRichEditCntrItem
{
	DECLARE_SERIAL(CMSOffice2007DemoCntrItem)

// Constructors
public:
	CMSOffice2007DemoCntrItem(REOBJECT* preo = NULL, CMSOffice2007DemoDoc* pContainer = NULL);
	// Note: pContainer is allowed to be NULL to enable IMPLEMENT_SERIALIZE.
	//  IMPLEMENT_SERIALIZE requires the class have a constructor with
	//  zero arguments.  Normally, OLE items are constructed with a
	//  non-NULL document pointer.

// Attributes
public:
	CMSOffice2007DemoDoc* GetDocument() { return(CMSOffice2007DemoDoc*)CRichEditCntrItem::GetDocument(); }
	CMSOffice2007DemoView* GetActiveView() { return(CMSOffice2007DemoView*)CRichEditCntrItem::GetActiveView(); }

protected:
	virtual BOOL OnShowPanes(CFrameWnd* pFrameWnd, BOOL bShow);

// Implementation
public:
	~CMSOffice2007DemoCntrItem();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

	UINT m_uiCategoryID;
};

