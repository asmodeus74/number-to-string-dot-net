using System;
using System.Collections.Generic;

namespace NumberToString
{
    public static class Helper
    {
        public static List<String> GetDigitParts(int number)
        {
            var numberAsString = number.ToString();
            if (numberAsString[0] == '-')
            {
                numberAsString = numberAsString.Substring(1);
            }
            var len = numberAsString.Length;
            var digitGroups = new List<String>();
            while (len > 0)
            {
                var start = len - 3;
                var take = 3;
                if (start < 0)
                {
                    take = 3 + start;
                    start = 0;
                }
                digitGroups.Add(numberAsString.Substring(start, take));
                len -= 3;
            }
            return digitGroups;
        }

        public static List<DigitGroup> GetDigitGroups(int number)
        {
            var parts = Helper.GetDigitParts(number);
            var digitGroups = new List<DigitGroup>();
            var nameIndex = 0;
            foreach (var part in parts)
            {
                digitGroups.Add(new DigitGroup(part, nameIndex));
                nameIndex++;
            }
            digitGroups.Reverse();
            return digitGroups;
        }
    }
}
