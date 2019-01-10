using System;
using System.Text;

namespace NumberToString
{
    public class NumberToString
    {
        private int _number;
        public NumberToString(int number)
        {
            this._number = number;
        }

        public override string ToString()
        {
            var digitGroups = Helper.GetDigitGroups(this._number);
            var negative = this._number < 0;
            var groupIndex = digitGroups.Count;
            var numberAsString = new StringBuilder();
            foreach (var group in digitGroups)
            {
                groupIndex--;
                var word = group.ToString();
                if (numberAsString.Length != 0 && !String.IsNullOrEmpty(word))
                {
                    if (groupIndex == 0 && Int32.Parse(group.Digits) < 100)
                    {
                        numberAsString.Append(" and ");
                    }
                    else
                    {
                        numberAsString.Append(", ");
                    }
                }
                numberAsString.Append(word);
            }
            return negative 
                ? "negative " + numberAsString.ToString() 
                : numberAsString.ToString();
        }
    }
}