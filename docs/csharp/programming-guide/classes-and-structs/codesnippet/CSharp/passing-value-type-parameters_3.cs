            static void SwapByRef(ref int x, ref int y)
            {
                int temp = x;
                x = y;
                y = temp;
            }