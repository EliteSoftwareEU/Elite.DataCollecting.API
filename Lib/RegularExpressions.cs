using System;
using System.Text.RegularExpressions;

namespace Elite.DataCollecting.API.Lib
{
    public static class RegularExpressions
    {
        public static Regex AllExceptDotAndAZ()
        {
            return new Regex("[^a-zA-Z\\.]");
        }
     
        public static Regex MoreThanOneSpace()
        {
            return new Regex(" +");
        }
    }
}
