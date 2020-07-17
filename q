[33mcommit 07db00f5c32fdda3de96c04fd5ec5c447496a71a[m[33m ([m[1;36mHEAD -> [m[1;32mperf-diag[m[33m)[m
Author: David Pine <david.pine@microsoft.com>
Date:   Fri Jul 17 07:47:32 2020 -0500

    Pre-commit hook, applied automatic markdownlint CLI fixes

[33mcommit b6626f9839dce9c6b791b52bab5ff208d63bf1f7[m[33m ([m[1;31morigin/perf-diag[m[33m)[m
Author: David Pine <david.pine@microsoft.com>
Date:   Fri Jul 17 07:46:23 2020 -0500

    Light edits

[33mcommit 5055c21581c5e9f648127e7daed085749d0398bc[m
Author: David Pine <david.pine@microsoft.com>
Date:   Fri Jul 17 07:38:04 2020 -0500

    Minor tweak

[33mcommit 9e1c54bb031d5ec99ebaf1adce9710b9475e79b5[m
Author: David Pine <david.pine@microsoft.com>
Date:   Thu Jul 16 09:33:26 2020 -0500

    Pre-commit hook, applied automatic markdownlint CLI fixes

[33mcommit eb8097ff2b03bc84b951054ae70d3f88c482f8ec[m
Author: David Pine <david.pine@microsoft.com>
Date:   Thu Jul 16 09:24:32 2020 -0500

    Attempting pre-commit test

[33mcommit ed419d7eae60f55a57a57d6427e9a5a3607f92d8[m
Author: David Pine <david.pine@microsoft.com>
Date:   Thu Jul 16 09:11:44 2020 -0500

    Fix markdownlint issues

[33mcommit 01524e8131e66838aeb829819b5686a14c22a761[m
Author: David Pine <david.pine@microsoft.com>
Date:   Thu Jul 16 08:34:30 2020 -0500

    Acrolinx

[33mcommit 6d7665f6b22cdfd6962163fc7aea37b507a245cc[m
Author: David Pine <david.pine@microsoft.com>
Date:   Thu Jul 16 08:31:08 2020 -0500

    Initial port from sdnackea branch

[33mcommit ab79f3da0984c4f5b3e27ab5fca6010b667b056a[m[33m ([m[1;31mupstream/master[m[33m, [m[1;32mmaster[m[33m)[m
Author: Next Turn <45985406+NextTurn@users.noreply.github.com>
Date:   Thu Jul 16 14:41:27 2020 +0800

    Remove empty .resx, Part 4 (#19426)
    
    * Remove empty .resx, Part 4
    
    * Update path to Microsoft.Ink.dll
    
    * Add back WPF imports
    
    * Use auto properties
    
    * Fix build warnings
    
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(221,32): warning BC40004: variable 'BackgroundProperty' conflicts with variable 'BackgroundProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(222,32): warning BC40004: variable 'BorderBrushProperty' conflicts with variable 'BorderBrushProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(223,32): warning BC40004: variable 'BorderThicknessProperty' conflicts with variable 'BorderThicknessProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(224,32): warning BC40004: variable 'FontFamilyProperty' conflicts with variable 'FontFamilyProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(225,32): warning BC40004: variable 'FontSizeProperty' conflicts with variable 'FontSizeProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(226,32): warning BC40004: variable 'FontStretchProperty' conflicts with variable 'FontStretchProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(227,32): warning BC40004: variable 'FontStyleProperty' conflicts with variable 'FontStyleProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(228,32): warning BC40004: variable 'FontWeightProperty' conflicts with variable 'FontWeightProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(229,32): warning BC40004: variable 'ForegroundProperty' conflicts with variable 'ForegroundProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(230,32): warning BC40004: variable 'HorizontalContentAlignmentProperty' conflicts with variable 'HorizontalContentAlignmentProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(231,32): warning BC40004: variable 'PaddingProperty' conflicts with variable 'PaddingProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(235,32): warning BC40004: variable 'VerticalContentAlignmentProperty' conflicts with variable 'VerticalContentAlignmentProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(237,25): warning BC40003: property 'Background' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'.
    [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(239,25): warning BC40003: property 'BorderBrush' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(241,25): warning BC40003: property 'BorderThickness' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(243,25): warning BC40003: property 'FontFamily' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'.
    [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(245,25): warning BC40003: property 'FontSize' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(247,25): warning BC40003: property 'FontStretch' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(249,25): warning BC40003: property 'FontStyle' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(251,25): warning BC40003: property 'FontWeight' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'.
    [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(253,25): warning BC40003: property 'Foreground' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'.
    [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(255,25): warning BC40003: property 'HorizontalContentAlignment' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(257,25): warning BC40003: property 'Padding' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(265,25): warning BC40003: property 'VerticalContentAlignment' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\Window1.xaml(14,23): warning BC40004: WithEvents variable 'MouseLeave' conflicts with event 'MouseLeave' in the base class 'UIElement' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\Window1.xaml(15,23): warning BC40004: WithEvents variable 'MouseEnter' conflicts with event 'MouseEnter' in the base class 'UIElement' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2_z3g42gjw_wpftmp.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(221,32): warning BC40004: variable 'BackgroundProperty' conflicts with variable 'BackgroundProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(222,32): warning BC40004: variable 'BorderBrushProperty' conflicts with variable 'BorderBrushProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(223,32): warning BC40004: variable 'BorderThicknessProperty' conflicts with variable 'BorderThicknessProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(224,32): warning BC40004: variable 'FontFamilyProperty' conflicts with variable 'FontFamilyProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(225,32): warning BC40004: variable 'FontSizeProperty' conflicts with variable 'FontSizeProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(226,32): warning BC40004: variable 'FontStretchProperty' conflicts with variable 'FontStretchProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(227,32): warning BC40004: variable 'FontStyleProperty' conflicts with variable 'FontStyleProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(228,32): warning BC40004: variable 'FontWeightProperty' conflicts with variable 'FontWeightProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(229,32): warning BC40004: variable 'ForegroundProperty' conflicts with variable 'ForegroundProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(230,32): warning BC40004: variable 'HorizontalContentAlignmentProperty' conflicts with variable 'HorizontalContentAlignmentProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(231,32): warning BC40004: variable 'PaddingProperty' conflicts with variable 'PaddingProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(235,32): warning BC40004: variable 'VerticalContentAlignmentProperty' conflicts with variable 'VerticalContentAlignmentProperty' in the base class 'Control' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(237,25): warning BC40003: property 'Background' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'.
    [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(239,25): warning BC40003: property 'BorderBrush' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(241,25): warning BC40003: property 'BorderThickness' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(243,25): warning BC40003: property 'FontFamily' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'.
    [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(245,25): warning BC40003: property 'FontSize' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(247,25): warning BC40003: property 'FontStretch' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(249,25): warning BC40003: property 'FontStyle' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(251,25): warning BC40003: property 'FontWeight' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'.
    [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(253,25): warning BC40003: property 'Foreground' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'.
    [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(255,25): warning BC40003: property 'Ho\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\NumericUpDown.vb(265,25): warning BC40003: property 'VerticalContentAlignment' shadows an overloadable member declared in the base class 'Control'.  If you want to overload the base method, this method must be declared 'Overloads'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\Window1.xaml(14,23): warning BC40004: WithEvents variable 'MouseLeave' conflicts with event 'MouseLeave' in the base class 'UIElement' and should be declared 'Shadows'. [docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\vsmcustomcontrolvb2.vbproj]
    docs\samples\snippets\visualbasic\VS_Snippets_Wpf\vsmcustomcontrol\visualbasic\Window1.xaml(15,23): warning BC40004: WithEvents variable 'MouseEnter' conflicts with event 'MouseEnter