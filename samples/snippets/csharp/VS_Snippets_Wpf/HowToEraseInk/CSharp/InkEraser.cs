//<Snippet1>
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;

// This control initializes with ink already on it and allows the
// user to erase the ink with the tablet pen or mouse.
public class InkEraser : Label
{
    IncrementalStrokeHitTester eraseTester;

    InkPresenter presenter;

    string strokesString =
        @"ALwHAxdIEETLgIgERYQBGwIAJAFGhAEbAgAkAQUBOBkgMgkA9P8CAekiOkUzCQD4n"
        + "wIBWiA6RTgIAP4DAAAAgH8RAACAPx8JEQAAAAAAAPA/CiUHh/A6N4HR0AivFX8Vs"
        + "IfsiuyLSaIeDSLwabiHm0GgUDi+KZkACjsQh/A9t4IC5VJpfLhaIxyxXIh7Dncnh"
        + "+6e7qODwoERlPAw8EpGoJAgh61IKjCYXBYDA4DAIHF67KIHAAojB4fwMteBn+RKB"
        + "lziaIfwWTeCwePqbM8WgIeeQCDQOFRvcIAKNA+H8B8XgQHkUbjQTTnGuaZns3l4h"
        + "/DWt4a0YKBBOA94D6HRCAiGnp5CS8LExMLB1tOgYIAKUBOH8KnXhU7lMold+tcbi"
        + "kChkqu2EtPYxp9bmYCH8HDHg4ZhMIwRyMHH+4Jt8nleX8c0/D/AkYwxJGiHkkQgM"
        + "Ch9CqcFhMDQCBwWAwuR2eAACmgdh/EpF4lA6XMUfhMXgMHgVDxBFpRKpZII5EINA"
        + "OA64M+J4Lw1CIoAh/B2x4PS4bQodAopEI5IJBki4waEx2Qy+dy+ayHgleEmmHH8c"
        + "e3MZOCGw5TWd3CwsHAwMCgRAEAgElKwOHZKBApaGIfxezeL0uN02N8IzwaGEpNIJ"
        + "ZxHnELyOj0GfyuU6FgmhplIgIfwYgeDHeaI1vjOtZgcHgHAYb9hUCgEFgsPm1xnM"
        + "ZkYhsnYJgZeZh4uAgCgnSBIOJv4OAgwCmkgh/GrR41X4dGoRJL9EKra5HKY7IZ3C"
        + "4fj/M06olSoU8kkehUbh8jkMdCH8IJXhAXhMCk8JuNlmNyh0YiEumUwn2wMRxyHw"
        + "2TzWmzeb02OzGKxMITwIhnrjzbb44zRhGEKRhCM4zrr6sQKXRWH8kuXkmPj0DiXC"
        + "gcJbC9HZZgkKgUG4bLh3YrwJHAYw2CAh/CiN4Tq7DOZr4BB/AFtdOWW5P2h1Wkzv"
        + "l4+YwqXf8d5fZ7ih51QKbB4LQrLAYDBIDABA4BO4nAICApvIIfy4BeXA2DRSrQlL"
        + "oHHsYQ/KMXlsvl8rn8Xkcdg+G9NVaUWimUDYk9Ah/BoF4M0YBCqZPYqk8dwLf7hD"
        + "YNBJFLKBNqZTqNubWshl9VoM1reFYZYQEBGUsDAwKEjYuDQKBgICBgCAgIOAg4nI"
        + "8OACloSh/BFl4Gf/IOt6FXfF8F4ToPCZzlPwP4+B+DHmQO847rfDeCcG8eKh/EZV"
        + "4i9eZt8A9nUF8VzxaUe5grl7YrPaHfpRKJNx4yHmUuj1vicwmMBEAjUVgKB61A=";
    
    public InkEraser()
    {
        presenter = new InkPresenter();
        this.Content = presenter;

        // Create a StrokeCollection the string and add it to
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


    protected override void OnStylusDown(StylusDownEventArgs e)
    {
        base.OnStylusDown(e);
        StylusPointCollection points = e.GetStylusPoints(this);

        InitializeEraserHitTester(points);

    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);

        if (e.StylusDevice != null)
        {
            return;
        }

        Point pt = e.GetPosition(this);

        StylusPointCollection collectedPoints = new StylusPointCollection(new Point[] { pt });

        InitializeEraserHitTester(collectedPoints);
    }

    // Prepare to collect stylus packets. Get the 
    // IncrementalHitTester from the InkPresenter's 
    // StrokeCollection and subscribe to its StrokeHitChanged event.
    private void InitializeEraserHitTester(StylusPointCollection points)
    {
        EllipseStylusShape eraserTip = new EllipseStylusShape(3, 3, 0);
        eraseTester =
            presenter.Strokes.GetIncrementalStrokeHitTester(eraserTip);
        eraseTester.StrokeHit += new StrokeHitEventHandler(eraseTester_StrokeHit);
        eraseTester.AddPoints(points);
    }

    protected override void OnStylusMove(StylusEventArgs e)
    {
        StylusPointCollection points = e.GetStylusPoints(this);

        AddPointsToEraserHitTester(points);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        if (e.StylusDevice != null)
        {
            return;
        }

        if (e.LeftButton == MouseButtonState.Released)
        {
            return;
        }

        Point pt = e.GetPosition(this);

        StylusPointCollection collectedPoints = new StylusPointCollection(new Point[] { pt });

        AddPointsToEraserHitTester(collectedPoints);
    }

    // Collect the StylusPackets as the stylus moves.
    private void AddPointsToEraserHitTester(StylusPointCollection points)
    {
        if (eraseTester.IsValid)
        {
            eraseTester.AddPoints(points);
        }
    }

    // Unsubscribe from the StrokeHitChanged event when the
    // user lifts the stylus.
    protected override void OnStylusUp(StylusEventArgs e)
    {
        StylusPointCollection points = e.GetStylusPoints(this);

        StopEraseHitTesting(points);
    }

    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonUp(e);

        if (e.StylusDevice != null)
        {
            return;
        }

        Point pt = e.GetPosition(this);

        StylusPointCollection collectedPoints = new StylusPointCollection(new Point[] { pt });

        StopEraseHitTesting(collectedPoints);
    }

    private void StopEraseHitTesting(StylusPointCollection points)
    {
        eraseTester.AddPoints(points);
        eraseTester.StrokeHit -= new
            StrokeHitEventHandler(eraseTester_StrokeHit);
        eraseTester.EndHitTesting();
    }


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
}
//</Snippet1>
