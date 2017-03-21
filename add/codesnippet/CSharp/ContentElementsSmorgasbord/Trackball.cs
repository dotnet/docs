//---------------------------------------------------------------------------
// <copyright file="Trackball.cs" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//---------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;


namespace DemoDev
{
    public class FastZoom
    {
        public FastZoom()
        {
        }
        //NOTE currently has funky behavior in the MouseMove
        //but doesn't matter because I am not showing that
        public void Attach(FrameworkContentElement element)
        {
            element.MouseMove += this.MouseMoveHandler;
            element.MouseRightButtonDown += this.MouseDownHandler;
            element.MouseRightButtonUp += this.MouseUpHandler;
        }

        public void Detach(FrameworkContentElement element)
        {
            element.MouseMove -= this.MouseMoveHandler;
            element.MouseRightButtonDown -= this.MouseDownHandler;
            element.MouseRightButtonUp -= this.MouseUpHandler;
        }
        private void MouseMoveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ContentElement el = (ContentElement)sender;
            if (!el.IsEnabled) return;
            e.Handled = true;

            if (el.IsMouseCaptured)
            {
                Vector delta = _point - e.MouseDevice.GetPosition(el);
                Block b = el as Block;
                if (b != null)
                {
                    origFontSize = b.FontSize;
                    double factor = delta.X / 1000;
                    while (b.FontSize + factor >= origFontSize && b.FontSize + factor < 200)
                    {
                        b.FontSize += factor;
                    }
                }
            }
        }
//<SnippetUIElementMouseCapture>
        private void MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            ContentElement el = (ContentElement)sender;
            if (!el.IsEnabled) return;
            e.Handled = true;
            el.CaptureMouse();
            _point = e.MouseDevice.GetPosition(el); 
        }

        private void MouseUpHandler(object sender, MouseButtonEventArgs e)
        {
            ContentElement el = (ContentElement)sender;
            if (!el.IsEnabled) return;
            e.Handled = true;
            el.ReleaseMouseCapture();
        }
//</SnippetUIElementMouseCapture>
        Point _point;
        double origFontSize;
    }
}

