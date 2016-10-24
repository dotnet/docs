            // This try-finally statement only calls Dispose in the finally block.
            Font font1 = new Font("Arial", 10.0f);
            try
            {
                byte charset = font1.GdiCharSet;
            }
            finally
            {
                if (font1 != null)
                {
                    ((IDisposable)font1).Dispose();
                }
            }


            // You can do the same thing with a using statement.
            using (Font font2 = new Font("Arial", 10.0f))
            {
                byte charset = font2.GdiCharSet;
            }