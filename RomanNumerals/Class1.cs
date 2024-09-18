using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public class RomanNumber
    {
        private int _value;
        public int ArabicValue 
        {
            set
            {
                if (value <= 0 || value > 3999) 
                    throw new Exception("Incorrect arabic numeral.");
                else 
                    _value = value;
                
            }
            get => _value;
        }

        public RomanNumber(string RomanValue)
        {
            if (!IsRoman(RomanValue))
            {
                throw new Exception("Incorrect roman numeral.");
            }
            else
            {
                this.ArabicValue = RomToAr(RomanValue);
            }
        }
        public RomanNumber(int ArabicValue)
        {
            this.ArabicValue = ArabicValue;
        }
        
        public static int decode(char a)
        {
            if (a == 'I') { return 1; }
            if (a == 'V') { return 5; }
            if (a == 'X') { return 10; }
            if (a == 'L') { return 50; }
            if (a == 'C') { return 100; }
            if (a == 'D') { return 500; }
            if (a == 'M') { return 1000; }
            else { return 0; }
        }

        public int RomToAr(string s)
        {
            int result = 0;
            for (int j = 0; j < s.Length; j++)
            {
                if (j + 1 < s.Length)
                {
                    if (decode(s[j]) < decode(s[j + 1]))
                    {
                        result += decode(s[j + 1]) - decode(s[j]);
                        j++;
                        continue;
                    }
                }


                result = result + decode(s[j]);

            }
            return result;
        }
        public static implicit operator RomanNumber(int value) 
        {
            return new RomanNumber(value);
        }
        public static implicit operator RomanNumber(string value)
        {
            return new RomanNumber(value);
        }
        public static RomanNumber operator +(RomanNumber num1, RomanNumber num2)
        {
            var ArSum = num1.ArabicValue + num2.ArabicValue;
            return ArSum;
        }
        public static RomanNumber operator -(RomanNumber num1, RomanNumber num2)
        {
            var ArDiff = num1.ArabicValue - num2.ArabicValue;
            if (num1.ArabicValue-num2.ArabicValue <= 0)
            {
                throw new Exception("Result cannot be represented in Roman numerals.");
            }
            return ArDiff;
        }

        public static RomanNumber operator *(RomanNumber num1, RomanNumber num2)
        {
            var ArProduct = num1.ArabicValue * num2.ArabicValue;
            return ArProduct;
        }

        public static RomanNumber operator /(RomanNumber num1, RomanNumber num2)
        {
            var ArQuotient = 0;
            if (num2.ArabicValue != 0)
            {
                ArQuotient = num1.ArabicValue / num2.ArabicValue;
                return ArQuotient;
            }
            return ArQuotient;
        }
        public static bool operator ==(RomanNumber c1, RomanNumber c2) => c1.ArabicValue == c2.ArabicValue;
        public static bool operator !=(RomanNumber c1, RomanNumber c2) => !((int)c1.ArabicValue == (int)c2.ArabicValue);
        public override string ToString()
        {
            int ar = this.ArabicValue;
            string[] romanNumerals = { "M", "D", "C", "L", "X", "V", "I" };
            int[] values = { 1000, 500, 100, 50, 10, 5, 1 };
            
            var result = "";
            for (var i = 0; i < values.Length; i++)
            {
                while (ar >= values[i])
                {
                    if (Convert.ToString(ar)[0] == '4')
                    {
                        result += romanNumerals[i];
                        ar += values[i];
                        i--;
                    }
                    else if (Convert.ToString(ar)[0] == '9')
                    {
                        result += romanNumerals[i + 1];
                        ar += values[i+1];
                        i--;
                    }
                    else
                    {
                        result += romanNumerals[i];
                        ar -= values[i];
                    }
                }
            }
            return result;
        }

        private static bool IsRoman(string romanValue)
        {
            var validPattern = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            return System.Text.RegularExpressions.Regex.IsMatch(romanValue, validPattern);
        }
    }
}

