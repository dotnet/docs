// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

/////////////////////////////////////////////////////////////////////////////
// CSplitFrame frame with splitter

#ifndef __AFXEXT_H__
#include <afxext.h>
#endif

class CSplitFrame : public CMDIChildWndEx
{
	DECLARE_DYNCREATE(CSplitFrame)

protected:
	CSplitFrame();          // protected constructor used by dynamic creation

// Attributes
protected:
	CSplitterWndEx    m_wndSplitter;
public:

// Implementation
public:
	virtual ~CSplitFrame();
	virtual BOOL OnCreateClient(LPCREATESTRUCT lpcs, CCreateContext* pContext);

	//{{AFX_MSG(CSplitFrame)
	afx_msg void OnFilePrint();
	afx_msg void OnFilePrintPreview();
	afx_msg void OnUpdateFilePrintPreview(CCmdUI* pCmdUI);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

