using System;
using System.Text;

namespace NumberToString
{
    public class DigitGroup
    {
        private string _digits;
        private int _nameIndex = 0;

        public DigitGroup(string digits, int nameIndex)
        {
            this._digits = digits;
            this._nameIndex = nameIndex;
        }

        public string Digits
        {
            get
            {
                return _digits;
            }
        }

        private string SecondDigitToWord(int digit)
        {
            return Words.SecondDigitWords[digit];
        }

        private string FirstDigitToWord(int digit)
        {
            return Words.FirstDigitWords[digit];
        }

        private string TenToTwentyToWord(int num)
        {
            return Words.TenToTwentyWords[num - 10];
        }

        public string FormatDigit(int index, int digitIndex)
        {
            var digit = Int32.Parse(this._digits[digitIndex].ToString());
            if (digit == 0)
            {
                return String.Empty;
            }
            switch (index)
            {
                case 3:
                    return FirstDigitToWord(digit) + " hundred";
                case 2:
                    return digit == 1
                      ? TenToTwentyToWord(Int32.Parse(this._digits.Substring(this._digits.Length - 2, 2)))
                      : SecondDigitToWord(digit);
                case 1:
                    return FirstDigitToWord(digit);
            }
            return String.Empty;
        }

        private string _ToString()
        {
            var digitsAsString = new StringBuilder();
            if (this._digits.Length == 0)
            {
                return String.Empty;
            }
            var tenths = 0;
            if (Int32.Parse(this._digits) == 100)
            {
                return "hundred";
            }
            var word = new StringBuilder();
            for (var i = this._digits.Length; i > 0; i--)
            {
                switch (i)
                {
                    case 3:
                        digitsAsString.Append(FormatDigit(3, 0));
                        break;
                    case 2:
                        word.Append(FormatDigit(2, this._digits.Length - i));
                        if (digitsAsString.Length != 0 && word.Length != 0)
                        {
                            digitsAsString.Append(" and ");
                        }
                        digitsAsString.Append(word);
                        tenths = Int32.Parse(this._digits[this._digits.Length - i].ToString());
                        if (tenths == 1)
                        {
                            return digitsAsString.ToString();
                        }
                        break;
                    case 1:
                        word = new StringBuilder(this.FormatDigit(1, this._digits.Length - 1));
                        if (digitsAsString.Length != 0)
                        {
                            var crumb = tenths == 0 ? " and " : " ";
                            digitsAsString.Append(crumb);
                        }
                        digitsAsString.Append(word);
                        break;
                }
            }
            return digitsAsString.ToString();
        }

        public override string ToString()
        {
            if (Int32.Parse(this._digits) == 0)
            {
                return this._nameIndex > 0 ? "" : "zero";
            }
            var digitsAsString = new StringBuilder();
            digitsAsString.Append(_ToString());
            if (this._nameIndex > 0)
            {
                digitsAsString.Append(" ").Append(Words.NumberNames[this._nameIndex]);
            }
            return digitsAsString.ToString();
        }
    }
}
