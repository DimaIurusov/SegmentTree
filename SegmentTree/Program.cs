using System;
using System.Collections.Generic;

namespace SegmentTree
{
    

    class Program
    {
        static void Fill(in int[] data, int lenght)
        {
            Random rnd = new Random();
            for (int i = 0; i < lenght; i++)
                data[i] = rnd.Next(0, 10);
        }

        static void Show(int[] data)
        {
            for(int i = 0; i < data.Length; i++)
                Console.Write($"mas[{i}] = {data[i]}\n");
            Console.WriteLine();
        }

        static int STMaxVal(int lBound, int rBound)
        {
            return 0;
        }
        static void Main()
        {
            int[] mas = new int[10];
            Fill(mas, 10);
            Show(mas);

            SectionTree<int> st = new SectionTree<int>(mas, 10);

            st.UpdateValue(2, 10);
            Unit res = st.CalculateSumm(0, 9);
            Console.WriteLine((int)res.Value);

            Func<int, int, int> ForMaxValue = STMaxVal;


            Console.ReadLine();
        }
    }
}
