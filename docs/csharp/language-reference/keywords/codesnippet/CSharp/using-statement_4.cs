            Font font2 = new Font("Arial", 10.0f);
            using (font2) // not recommended
            {
                // use font2
            }
            // font2 is still in scope
            // but the method call throws an exception
            float f = font2.GetHeight(); 

