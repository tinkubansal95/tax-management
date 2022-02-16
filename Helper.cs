﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilWise
{
    public static class Helper
    {
        const decimal TaxRate = 0.1m;

        public static decimal CurrencyRound(this decimal value)
        {
            return Math.Round(value, 2);
        }

        public static string Reverse(string str)
        {
            char[] strArray = str.ToCharArray();
            Array.Reverse(strArray);
            return new string(strArray);
        }
    }
}
