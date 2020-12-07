using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectASP
{
    public static class Crypto
    {
        static string letters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        //генерация повторяющегося пароля
        public static string GetRepeatKey(string s, string str)
        {
            int i = 0;
            s = s.ToUpper();
            str = str.ToUpper();
            string res = "";
            foreach (var e in str)
            {
                if (letters.Contains(e))
                {
                    res += s[i];
                    if (i + 1 == s.Length) i = 0;
                    else i++;
                }
                else
                {
                    res += e;
                }
            }
            return res;
        }

        public static string Vigenere(string text, string password, bool encrypting = true)
        {
            var gamma = GetRepeatKey(password, text);
            gamma = gamma.ToUpper();
            text = text.ToUpper();
            var retValue = "";
            var q = letters.Length;

            for (int i = 0; i < text.Length; i++)
            {
                var letterIndex = letters.IndexOf(text[i]);
                var codeIndex = letters.IndexOf(gamma[i]);
                if (letterIndex < 0)
                {
                    //если буква не найдена, добавляем её в исходном виде
                    retValue += text[i].ToString();
                }
                else
                {
                    retValue += letters[(q+ letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString();
                }
            }

            return retValue;
        }

        //шифрование текста
        public static string Encrypt(string plainMessage, string password)
            => Vigenere(plainMessage, password);

        //дешифрование текста
        public static string Decrypt(string encryptedMessage, string password)
            => Vigenere(encryptedMessage, password, false);

    }
}