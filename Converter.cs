using System.Text;

namespace Converter
{
    public class RomanConverter
    {
        public RomanConverter() { }

        public string NumberToRoman(int number)
        {
            if (number == 0) return "N";

            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] numerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < values.Length; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    result.Append(numerals[i]);
                }
            }

            return result.ToString();
        }

        public int RomanToNumber(string number)
        {
            int FinalValue = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int CurrentValue = GetValue(number[i]);
                if (CurrentValue == -1) return -1;

                int NextValue = 0;
                if (i + 1 < number.Length)
                    NextValue = GetValue(number[i + 1]);

                if (NextValue > CurrentValue)
                {
                    FinalValue += NextValue - CurrentValue;
                    i++;
                }
                else
                {
                    FinalValue += CurrentValue;
                }
            }

            return FinalValue;
        }

        private int GetValue(char c)
        {
            return c switch
            {
                'M' => 1000,
                'D' => 500,
                'C' => 100,
                'L' => 50,
                'X' => 10,
                'V' => 5,
                'I' => 1,
                _ => -1
            };
        }
    }
}