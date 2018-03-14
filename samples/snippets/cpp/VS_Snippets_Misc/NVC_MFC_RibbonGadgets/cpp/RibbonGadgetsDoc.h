#pragma once

class CRibbonGadgetsDoc : public CDocument
{
protected: // create from serialization only
	CRibbonGadgetsDoc();
	DECLARE_DYNCREATE(CRibbonGadgetsDoc)

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
	virtual ~CRibbonGadgetsDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	DECLARE_MESSAGE_MAP()

protected:
	BOOL m_bStartup;
};
