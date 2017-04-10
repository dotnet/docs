// MFCRibbonAppDoc.h : interface of the CMFCRibbonAppDoc class
//


#pragma once


class CMFCRibbonAppDoc : public CDocument
{
protected: // create from serialization only
	CMFCRibbonAppDoc();
	DECLARE_DYNCREATE(CMFCRibbonAppDoc)

// Attributes
public:

// Operations
public:

// Overrides
public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);

// Implementation
public:
	virtual ~CMFCRibbonAppDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};


