            {
              Font font1 = new Font("Arial", 10.0f);
              try
              {
                byte charset = font1.GdiCharSet;
              }
              finally
              {
                if (font1 != null)
                  ((IDisposable)font1).Dispose();
              }
            }