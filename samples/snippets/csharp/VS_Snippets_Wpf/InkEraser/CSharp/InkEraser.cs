//<snippet1>
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;

using System.IO;

namespace InkEraserDemo
{

    // This control initializes with ink already on it and allows the
    // user to erase the ink with the stylus.
    public class InkEraser : Border
    {
        IncrementalStrokeHitTester eraseTester;

        //<Snippet5>
        InkPresenter presenter;

        //<Snippet8>
        // The base-64 encoded string that contains ink data 
        // in ink serialized format (ISF).
        string strokesString =
            @"AOoFAxBIEEVqGwIAWf9GahsCAFn/GRQyCACAEAIAAABCMwgAgA"
            + "wCAAAAQhWrqtNBq6rTQaVh0MSr+ivFHyEVVFVVVVV1OkBUVVVVVXU6QJ7"
            + "0SZ80DJrAVFVVVVV/pcAKU3yC/gEb+AX/k5Z8PwWBO5KktgJSUAAKjzyC"
            + "wBZYLEoCJLd+Cbti873JlTUvn158doCC/gKb+ApwAJslSywE2ALAAWPPI"
            + "FhKWBKWAKAmwJVglAKACiMjgv3d+8Xi+fHWM2WC0zcm89+NSoL+A5P4Dl"
            + "uNlhFIqpLKAAoaF4L+AhP4CFAWAWCggv4Dc/gNty2yy5SrlKAKIhyC/gI"
            + "b+Ai+JZc2XZOyb46vLQCC/gOL+A5YDNlWFjN3CwAKQFeC/gOr+A7VhUFZ"
            + "KCsS2WTc2SyhKuWVLR3ly2LAXx574ssUgv4Dm/gOcCwEEpUTYSixUsuWy"
            + "gVZ79AQsWGyWUAKLCiC/gQT+BA9SWbllDfGqy3Lcu+OmfH8EIL+BDv4EP"
            + "XLKSpY3lVFhZuVZvKACkFggv4F2/gXlKLFuCVKTcsqUlkoRKBmk8zfFll"
            + "S2ySlACwAgv4Ds/gO+WWWWLBLFllllSksAoSkWG1kSbFu5AoAAAo/YoL+"
            + "Biv4GJJU+P4qSalUBKWdkBYCbm+Nliyk1CVKgCxYNYqC/gQb+BBwO8ABY"
            + "olDz4gAEzaw2AVCUKAsWCooCiAegv4Hw/gfEJe8zUoSgLCC/gNT+A0xM7"
            + "Gdmdliay2VaAo0PoL+B7v4Hx5Yq3lc2xZsseeC3N8aDXjUpWW4UIL+A5P"
            + "4DnhYqAIWFkqpcrLZuJuWqSyxVAovNoL+CJP4IjnlkDvHeSbSVd9FqFlI"
            + "oWAAgv4Dk/gOVc7gbmdyZ1LajFFJmlRKsoAKVXmC/go7+CjdRvredypaK"
            + "myLC7ytZQqFiyWbikAEvfg2pSVKS7liSwWJNsrbi4CC/gQD+A/9M2ACxU"
            + "qKjcVuXKiosCWWKQSyhvKRUUWULCwEmyyu4gA=";

        //</Snippet8>

        public InkEraser()
        {
            presenter = new InkPresenter();
            this.Child = presenter;

            //// Create a StrokeCollection the string and add it to
            StrokeCollectionConverter converter =
                new StrokeCollectionConverter();

            if (converter.CanConvertFrom(typeof(string)))
            {
                StrokeCollection newStrokes =
                    converter.ConvertFrom(strokesString) as StrokeCollection;
                presenter.Strokes.Clear();
                presenter.Strokes.Add(newStrokes);
            }

        }
        //</Snippet5>

        //<Snippet6>
        
        //<Snippet4>
        // Prepare to collect stylus packets. Get the 
        // IncrementalHitTester from the InkPresenter's 
        // StrokeCollection and subscribe to its StrokeHitChanged event.
        protected override void OnStylusDown(StylusDownEventArgs e)
        {
            base.OnStylusDown(e);

            EllipseStylusShape eraserTip = new EllipseStylusShape(3, 3, 0);
            eraseTester = 
                presenter.Strokes.GetIncrementalStrokeHitTester(eraserTip);
            eraseTester.StrokeHit += new StrokeHitEventHandler(eraseTester_StrokeHit);
            eraseTester.AddPoints(e.GetStylusPoints(this));

        }
        //</Snippet4>

        //<Snippet9>
        // Collect the StylusPackets as the stylus moves.
        protected override void OnStylusMove(StylusEventArgs e)
        {
            if (eraseTester.IsValid)
            {
                eraseTester.AddPoints(e.GetStylusPoints(this));
            }
        }
        //</Snippet9>

        //<Snippet10>
        // Unsubscribe from the StrokeHitChanged event when the
        // user lifts the stylus.
        protected override void OnStylusUp(StylusEventArgs e)
        {

            eraseTester.AddPoints(e.GetStylusPoints(this));
            eraseTester.StrokeHit -= new
                StrokeHitEventHandler(eraseTester_StrokeHit);
            eraseTester.EndHitTesting();
        }
        //</Snippet10>

        
        //<Snippet2>
        // When the stylus intersects a stroke, erase that part of
        // the stroke.  When the stylus dissects a stoke, the 
        // Stroke.Erase method returns a StrokeCollection that contains
        // the two new strokes.
        void eraseTester_StrokeHit(object sender,
            StrokeHitEventArgs args)
        {
            StrokeCollection eraseResult =
                args.GetPointEraseResults();
            StrokeCollection strokesToReplace = new StrokeCollection();
            strokesToReplace.Add(args.HitStroke);
           
            // Replace the old stroke with the new one.
            if (eraseResult.Count > 0)
            {
                presenter.Strokes.Replace(strokesToReplace, eraseResult);
            }
            else
            {
                presenter.Strokes.Remove(strokesToReplace);
            }

            
        }
        //</Snippet2>

        //</Snippet6>
      
        //</snippet1>

        //<Snippet11>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (e.StylusDevice != null)
            {
                return;
            }

            EllipseStylusShape eraserTip = new EllipseStylusShape(3, 3, 0);
            eraseTester =
                presenter.Strokes.GetIncrementalStrokeHitTester(eraserTip);
            eraseTester.StrokeHit += new StrokeHitEventHandler(eraseTester_StrokeHit);
            eraseTester.AddPoint(e.GetPosition(this));

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            
            if (e.StylusDevice != null || eraseTester == null)
            {
                return;
            }

            if (eraseTester.IsValid)
            {
                eraseTester.AddPoint(e.GetPosition(this));
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
        
            if (e.StylusDevice != null)
            {
                return;
            }

            eraseTester.AddPoint(e.GetPosition(this));
            eraseTester.StrokeHit -= new
                StrokeHitEventHandler(eraseTester_StrokeHit);
            eraseTester.EndHitTesting();
        }
        //</Snippet11>

        public void ResetInk()
        {
            LoadStrokes();

        }

        //<Snippet3>
        // Accepts a string that contains ink data in ink 
        // serialized format (ISF) and converts it into a StrokeCollection.
        public void LoadStrokes()
        {
            StrokeCollectionConverter converter =
                new StrokeCollectionConverter();

            if (converter.CanConvertFrom(typeof(string)))
            {
                StrokeCollection newStrokes =
                    (StrokeCollection)converter.ConvertFrom(null, null, strokesString);
                presenter.Strokes.Clear();
                presenter.Strokes.Add(newStrokes);
            }
        }
        //</Snippet3>

//<Snippet7>
    }
}
//</Snippet7>
/////////////////////////////////////
////// Code I don't want in my sample class.

        //public string SaveStrokes()
        //{
        //    return presenter.Strokes.SaveBase64(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum);
        //}

