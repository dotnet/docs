private:
    void ConstructFromResourceSaveAsGif(PaintEventArgs^ e)
    {
        // Construct a bitmap from the button image resource.
        Bitmap^ bmp1 = gcnew Bitmap(Button::typeid, "Button.bmp");
        String^ savePath =  
            Environment::GetEnvironmentVariable("TEMP") + "\\Button.bmp";

        try
        {
            // Save the image as a GIF.
            bmp1->Save(savePath, System::Drawing::Imaging::ImageFormat::Gif);
        }
        catch (IOException^)
        {
            // Carry on regardless
        }

        // Construct a new image from the GIF file.
        Bitmap^ bmp2 = nullptr;
        if (File::Exists(savePath))
        {
            bmp2 = gcnew Bitmap(savePath);
        }

        // Draw the two images.
        e->Graphics->DrawImage(bmp1, Point(10, 10));

        // If bmp1 did not save to disk, bmp2 may be null
        if (bmp2 != nullptr)
        {
            e->Graphics->DrawImage(bmp2, Point(10, 40));
        }

        // Dispose of the image files.
        delete bmp1;
        if (bmp2 != nullptr)
        {
            delete bmp2;
        }
    }