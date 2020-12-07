using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectASP
{
    public static class Crypto
    {
        static char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я'};
        static int N = characters.Length;
        public static string Deciper(string input, string keyword)
        {
            //input = input.ToUpper();
            keyword = keyword.ToUpper();
            bool isLower = true;
            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                if (char.IsLower(symbol)) isLower = true;
                else isLower = false;
                if (!characters.Contains(char.ToUpper(symbol))) { result += symbol; continue; }
                int p = (Array.IndexOf(characters, char.ToUpper(symbol)) + N -
                    Array.IndexOf(characters, keyword[keyword_index])) % N;
                if(isLower) result += char.ToLower(characters[p]);
                else result += char.ToUpper(characters[p]);


                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
            
        }
        public static string Enciper(string input, string keyword)
        {
            bool isLower = true;
           // input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                if (char.IsLower(symbol)) isLower = true;
                else isLower = false;
                if (!characters.Contains(char.ToUpper(symbol))) { result += symbol; continue; }
                int c = (Array.IndexOf(characters, char.ToUpper(symbol)) +
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                if (isLower) result += char.ToLower(characters[c]);
                else result += char.ToUpper(characters[c]);

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
            
        }
    }
}