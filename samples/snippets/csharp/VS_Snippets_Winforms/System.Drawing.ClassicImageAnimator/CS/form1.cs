

// Snippet for: M:System.Drawing.ImageAnimator.Animate(System.Drawing.Image,System.EventHandler)
// <snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

public class animateImage : Form 
{
                     
    //Create a Bitmpap Object.
    Bitmap animatedImage = new Bitmap("SampleAnimation.gif");
    bool currentlyAnimating = false;
                     
    //This method begins the animation.
    public void AnimateImage() 
    {
        if (!currentlyAnimating) 
        {
                     
            //Begin the animation only once.
            ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
            currentlyAnimating = true;
        }
    }

    private void OnFrameChanged(object o, EventArgs e) 
    {
                     
        //Force a call to the Paint event handler.
        this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e) 
    {
                     
        //Begin the animation.
        AnimateImage();
                     
        //Get the next frame ready for rendering.
        ImageAnimator.UpdateFrames();
                     
        //Draw the next frame in the animation.
        e.Graphics.DrawImage(this.animatedImage, new Point(0, 0));
    }

    public static void Main() 
    {
        Application.Run(new animateImage());
    }
}
// </snippet1>
