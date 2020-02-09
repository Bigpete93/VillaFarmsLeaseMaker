using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{

    //There was probably a library for this, but didn't find it and was time crunched.
    static class MathExtensions
    {
        public static string ToWrittenWord(this string number)
        {
            //Int to String
            var dict = new Dictionary<string, string>();
            dict.Add("1", "one");
            dict.Add("2", "two");
            dict.Add("3", "three");
            dict.Add("4", "four");
            dict.Add("5", "five");
            dict.Add("6", "six");
            dict.Add("7", "seven");
            dict.Add("8", "eight");
            dict.Add("9", "nine");

            dict.Add("10", "ten");
            dict.Add("11", "eleven");
            dict.Add("12", "twelve");
            dict.Add("13", "thirteen");
            dict.Add("14", "fourteen");
            dict.Add("15", "fifteen");
            dict.Add("16", "sixteen");
            dict.Add("17", "seventeen");
            dict.Add("18", "eighteen");
            dict.Add("19", "nineteen");

            dict.Add("20", "twenty");
            dict.Add("21", "twenty " + dict["1"]);
            dict.Add("22", "twenty " + dict["2"]);
            dict.Add("23", "twenty " + dict["3"]);
            dict.Add("24", "twenty " + dict["4"]);
            dict.Add("25", "twenty " + dict["5"]);
            dict.Add("26", "twenty " + dict["6"]);
            dict.Add("27", "twenty " + dict["7"]);
            dict.Add("28", "twenty " + dict["8"]);
            dict.Add("29", "twenty " + dict["9"]);


            dict.Add("30", "thirty");
            dict.Add("31", "thirty " + dict["1"]);
            dict.Add("32", "thirty " + dict["2"]);
            dict.Add("33", "thirty " + dict["3"]);
            dict.Add("34", "thirty " + dict["4"]);
            dict.Add("35", "thirty " + dict["5"]);
            dict.Add("36", "thirty " + dict["6"]);
            dict.Add("37", "thirty " + dict["7"]);
            dict.Add("38", "thirty " + dict["8"]);
            dict.Add("39", "thirty " + dict["9"]);

            dict.Add("40", "forty");
            dict.Add("41", "forty " + dict["1"]);
            dict.Add("42", "forty " + dict["2"]);
            dict.Add("43", "forty " + dict["3"]);
            dict.Add("44", "forty " + dict["4"]);
            dict.Add("45", "forty " + dict["5"]);
            dict.Add("46", "forty " + dict["6"]);
            dict.Add("47", "forty " + dict["7"]);
            dict.Add("48", "forty " + dict["8"]);
            dict.Add("49", "forty " + dict["9"]);

            dict.Add("50", "fifty");
            dict.Add("51", "fifty " + dict["1"]);
            dict.Add("52", "fifty " + dict["2"]);
            dict.Add("53", "fifty " + dict["3"]);
            dict.Add("54", "fifty " + dict["4"]);
            dict.Add("55", "fifty " + dict["5"]);
            dict.Add("56", "fifty " + dict["6"]);
            dict.Add("57", "fifty " + dict["7"]);
            dict.Add("58", "fifty " + dict["8"]);
            dict.Add("59", "fifty " + dict["9"]);

            dict.Add("60", "sixty");      
            dict.Add("61", "sixty " + dict["1"]);
            dict.Add("62", "sixty " + dict["2"]);
            dict.Add("63", "sixty " + dict["3"]);
            dict.Add("64", "sixty " + dict["4"]);
            dict.Add("65", "sixty " + dict["5"]);
            dict.Add("66", "sixty " + dict["6"]);
            dict.Add("67", "sixty " + dict["7"]);
            dict.Add("68", "sixty " + dict["8"]);
            dict.Add("69", "sixty " + dict["9"]);

            dict.Add("70", "seventy"); 
            dict.Add("71", "seventy " + dict["1"]);
            dict.Add("72", "seventy " + dict["2"]);
            dict.Add("73", "seventy " + dict["3"]);
            dict.Add("74", "seventy " + dict["4"]);
            dict.Add("75", "seventy " + dict["5"]);
            dict.Add("76", "seventy " + dict["6"]);
            dict.Add("77", "seventy " + dict["7"]);
            dict.Add("78", "seventy " + dict["8"]);
            dict.Add("79", "seventy " + dict["9"]);

            dict.Add("80", "eighty");
            dict.Add("81", "eighty " + dict["1"]);
            dict.Add("82", "eighty " + dict["2"]);
            dict.Add("83", "eighty " + dict["3"]);
            dict.Add("84", "eighty " + dict["4"]);
            dict.Add("85", "eighty " + dict["5"]);
            dict.Add("86", "eighty " + dict["6"]);
            dict.Add("87", "eighty " + dict["7"]);
            dict.Add("88", "eighty " + dict["8"]);
            dict.Add("89", "eighty " + dict["9"]);

            dict.Add("90", "ninety");
            dict.Add("91", "ninety " + dict["1"]); 
            dict.Add("92", "ninety " + dict["2"]);
            dict.Add("93", "ninety " + dict["3"]);
            dict.Add("94", "ninety " + dict["4"]);
            dict.Add("95", "ninety " + dict["5"]);
            dict.Add("96", "ninety " + dict["6"]);
            dict.Add("97", "ninety " + dict["7"]);
            dict.Add("98", "ninety " + dict["8"]);
            dict.Add("99", "ninety " + dict["9"]);

            if (!dict.ContainsKey(number)) return number;
            else return dict[number];
            
        }
        public static string ToOrdinal(this long number)
        {
            if (number < 0) return number.ToString();
            long rem = number % 100;
            if (rem >= 11 && rem <= 13) return number + "th";

            switch (number % 10)
            {
                case 1:
                    return number + "st";
                case 2:
                    return number + "nd";
                case 3:
                    return number + "rd";
                default:
                    return number + "th";
            }
        }

        public static string ToOrdinal(this int number)
        {
            return ((long)number).ToOrdinal();
        }

        public static string ToOrdinal(this string number)
        {
            if (String.IsNullOrEmpty(number)) return number;

            var dict = new Dictionary<string, string>();
            dict.Add("zero", "zeroth");
            dict.Add("nought", "noughth");
            dict.Add("one", "first");
            dict.Add("two", "second");
            dict.Add("three", "third");
            dict.Add("four", "fourth");
            dict.Add("five", "fifth");
            dict.Add("six", "sixth");
            dict.Add("seven", "seventh");
            dict.Add("eight", "eighth");
            dict.Add("nine", "ninth");
            dict.Add("ten", "tenth");
            dict.Add("eleven", "eleventh");
            dict.Add("twelve", "twelfth");
            dict.Add("thirteen", "thirteenth");
            dict.Add("fourteen", "fourteenth");
            dict.Add("fifteen", "fifteenth");
            dict.Add("sixteen", "sixteenth");
            dict.Add("seventeen", "seventeenth");
            dict.Add("eighteen", "eighteenth");
            dict.Add("nineteen", "nineteenth");
            dict.Add("twenty", "twentieth");
            dict.Add("thirty", "thirtieth");
            dict.Add("forty", "fortieth");
            dict.Add("fifty", "fiftieth");
            dict.Add("sixty", "sixtieth");
            dict.Add("seventy", "seventieth");
            dict.Add("eighty", "eightieth");
            dict.Add("ninety", "ninetieth");
            dict.Add("hundred", "hundredth");
            dict.Add("thousand", "thousandth");
            dict.Add("million", "millionth");
            dict.Add("billion", "billionth");
            dict.Add("trillion", "trillionth");
            dict.Add("quadrillion", "quadrillionth");
            dict.Add("quintillion", "quintillionth");

            string temp = number.ToLower().Trim().Replace(" and ", " ");
            string[] words = temp.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (!dict.ContainsKey(word)) return number;
            }

            number = number.TrimEnd().TrimEnd('-');
            int index = number.LastIndexOfAny(new char[] { ' ', '-' });
            string last = number.Substring(index + 1);

            
            if (last == last.ToLower())
            {
                last = dict[last];
            }
            else if (last == last.ToUpper())
            {
                last = dict[last.ToLower()].ToUpper();
            }
            else
            {
                last = last.ToLower();
                last = Char.ToUpper(dict[last][0]) + dict[last].Substring(1);
            }

            return number.Substring(0, index + 1) + last;
        }
        public static string MonthDic(this int number)
        {
            var dict = new Dictionary<int, string>();
            dict.Add(1, "January");
            dict.Add(2, "January");
            dict.Add(3, "January");
            dict.Add(4, "January");
            dict.Add(5, "January");
            dict.Add(6, "January");
            dict.Add(7, "January");
            dict.Add(8, "January");
            dict.Add(9, "January");
            dict.Add(10, "January");
            dict.Add(11, "January");
            dict.Add(12, "January");

            if (number < 13 && number > 0) return dict[number];
            else
            {

                return "CLERICAL ERROR";
            }
        }
    }
}