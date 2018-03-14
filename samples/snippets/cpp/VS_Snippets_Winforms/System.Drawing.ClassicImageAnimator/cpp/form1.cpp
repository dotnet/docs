

// Snippet for: M:System.Drawing.ImageAnimator.
//     Animate(System.Drawing.Image,System.EventHandler)
// <snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class AnimateImageForm : public Form 
{

    // Create a Bitmap Object.
private:
    Bitmap^ animatedImage;
private:
    bool currentlyAnimating;

public:
    AnimateImageForm()
    {
        try
        {
            animatedImage = gcnew Bitmap("SampleAnimation.gif");
        }
        catch (ArgumentException^)
        {
            MessageBox::Show("Could not read the image file " +
                "\"SampleAnimation.gif\",\n" +
                "or it is not a valid image file.");
        }
    }

    // This method begins the animation.
public:
    void AnimateImage() 
    {
        // Begin the animation only once.
        // Make sure to animate only if animatedImage was
        // successfully initialised.
        if (!currentlyAnimating && animatedImage != nullptr)
        {
            ImageAnimator::Animate(animatedImage,
                gcnew EventHandler(this, &AnimateImageForm::OnFrameChanged));
            currentlyAnimating = true;
        }
    }

private:
    void OnFrameChanged(Object^ , EventArgs^ ) 
    {
        // Force a call to the Paint event handler.
        this->Invalidate();
    }

protected:
    virtual void OnPaint(PaintEventArgs^ e) override
    {
        // Begin the animation.
        AnimateImage();

        // Get the next frame ready for rendering.
        ImageAnimator::UpdateFrames();

        if (animatedImage != nullptr)
        {
            // Draw the next frame in the animation.
            e->Graphics->DrawImage(this->animatedImage,
                Point(0, 0));
        }
    }
};

[STAThread]
int main()
{
    Application::Run(gcnew AnimateImageForm());
}
// </snippet1>
