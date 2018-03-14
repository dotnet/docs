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

#include "stdafx.h"
#include "MSOffice2007Demo.h"
#include "keys.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

MSOfficeDemoKey keys [] =
{
	//-------------
	// Tab buttons:
	//-------------

	{    ID_APP_ABOUT, _T("a")    },
	{    ID_SET_STYLE, _T("t")    },

	//-----------
	// Main menu:
	//-----------

	{    ID_FILE_PRINT, _T("p&w")    },

	//-------------
	// "Home" keys:
	//-------------

	// 1. Clipboard:
	{    ID_EDIT_PASTE, _T("v")    },
	{    ID_EDIT_COPY, _T("c")    },
	{    ID_EDIT_CUT, _T("x")    },
	{    ID_EDIT_COPYFORMAT, _T("fp")    },
	{    ID_WRITE_CLIPBOARD, _T("fo")    },

	// 2. Font:
	{    ID_FONT_FONT, _T("ff")    },
	{    ID_FONT_FONTSIZE, _T("fs")    },

	{    ID_FONT_GROWFONT, _T("fg")    },
	{    ID_FONT_SHRINK, _T("fk")    },

	{    ID_FONT_CLEARFORMAT, _T("e")    },

	{    ID_FONT_BOLD, _T("1")    },
	{    ID_FONT_ITALIC, _T("2")    },
	{    ID_FONT_UNDERLINE, _T("3")    },
	{    ID_FONT_STRIKETHROUGH, _T("4")    },
	{    ID_FONT_SUBSCRIPT, _T("5")    },
	{    ID_FONT_SUPERSCRIPT, _T("6")    },
	{    ID_FONT_CHANGECASE, _T("7")    },

	{    ID_FONT_TEXTHIGHLIGHT, _T("i")    },
	{    ID_FONT_COLOR, _T("fc")    },

	{    ID_WRITE_FONT, _T("fn")    },

	// 3. Paragraph:
	{    ID_PARA_BULLETS, _T("u")    },
	{    ID_PARA_NUMBERING, _T("n")    },
	{    ID_PARA_MULTILEVEL, _T("m")    },

	{    ID_PARA_DECREASEINDENT, _T("ao")    },
	{    ID_PARA_INCREASEINDENT, _T("ai")    },

	{    ID_PARA_SORT, _T("so")    },

	{    ID_PARA_ENDLINEMARK, _T("8")    },

	{    ID_PARA_ALIGNLEFT, _T("al")    },
	{    ID_PARA_CENTER, _T("ac")    },
	{    ID_PARA_ALIGNRIGHT, _T("ar")    },
	{    ID_PARA_JUSTIFY, _T("aj")    },

	{    ID_PARA_LINESPACING, _T("k")    },

	{    ID_PARA_SHADING, _T("h")    },

	{    ID_PARA_BORDER, _T("b")    },

	{    ID_WRITE_PARAGRAPH, _T("pg")    },

	// 4. Styles:
	{    ID_WRITE_QUICKSTYLES, _T("l")    },
	{    ID_WRITE_CHANGESTYLES, _T("g")    },
	{    ID_WRITE_STYLE, _T("fy")    },

	// 5. Editing:
	{    ID_EDIT_FIND, _T("fd")    },
	{    ID_EDIT_REPLACE, _T("r")    },
	{    ID_WRITE_SELECT, _T("sl")    },

	//---------------
	// "Insert" keys:
	//---------------

	// 1. Pages:
	{    ID_INSERT_COVERPAGE,		_T("v")		},
	{    ID_INSERT_BLACKPAGE,		_T("np")	},
	{    ID_INSERT_PAGEBREAK,		_T("b")		},
	{    ID_INSERT_PAGEBREAK,		_T("b")		},


	// 2. Table:
	{    ID_INSERT_TABLE,			_T("t")		},

	// 3. Illustrations:
	{    ID_INSERT_PICTURE,			_T("p")		},
	{    ID_INSERT_CLIPART,			_T("f")		},
	{    ID_INSERT_SHAPES,			_T("sh")	},
	{    ID_INSERT_SMARTART,		_T("m")		},
	{    ID_INSERT_CHART,			_T("c")		},

	// 4. Links:
	{    ID_INSERT_HYPERLINK,		_T("i")		},
	{    ID_INSERT_BOOKMARK,		_T("k")		},
	{    ID_INSERT_REFERENCE,		_T("rf")	},

	// 4. Header & Footer:
	{    ID_INSERT_HEADER,			_T("h")		},
	{    ID_INSERT_FOOTER,			_T("o")		},
	{    ID_INSERT_PAGENUMBER,		_T("nu")	},

	// 5. Text:
	{    ID_INSERT_TEXTBOX,			_T("x")		},
	{    ID_INSERT_QUICKPARTS,		_T("q")		},
	{    ID_INSERT_WORDART,			_T("w")		},
	{    ID_INSERT_DROPCAP,			_T("rc")	},
	{    ID_INSERT_SIGNATURELINE,	_T("g")		},
	{    ID_INSERT_DATETIME,		_T("d")		},
	{    ID_INSERT_OBJECT,			_T("j")		},

	// 6. Symbols:
	{    ID_INSERT_EQUATION,		_T("e")		},
	{    ID_INSERT_SYMBOL,			_T("u")		},

	{    0, NULL    },
};
