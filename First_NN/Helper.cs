using System;
using System.Collections.Generic;
using System.Text;

namespace First_NN
{
    internal static class Helper
    {
        public static double Sigmoid(double x)
        {
            if (x < -709)
            {
                return 0.0;
            }
            if (x > 709)
            {
                return 1.0;
            }
            return 1.0 / (1.0 + Math.Exp(-x));
        }
    }
}
