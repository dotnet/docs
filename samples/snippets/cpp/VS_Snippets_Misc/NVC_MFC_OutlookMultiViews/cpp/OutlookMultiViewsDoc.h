#pragma once

class COutlookMultiViewsDoc : public CDocument
{
protected: // create from serialization only
	COutlookMultiViewsDoc();
	DECLARE_DYNCREATE(COutlookMultiViewsDoc)

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
	virtual ~COutlookMultiViewsDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	DECLARE_MESSAGE_MAP()
};
