        unsafe void M()
        {
            int[] nums = {0,1,2,3,4,5};
            fixed ( int* p = nums )
            {
                p[0] = p[1] = 1;
                for( int i=2; i<100; ++i ) p[i] = p[i-1] + p[i-2];
            }
        }