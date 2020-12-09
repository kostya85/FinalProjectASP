using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FinalProjectASP;
using System.IO;
namespace UnitTestASP
{
    [TestClass]
    public class UnitTest
    {//Все исходники на всякий случай дополнительно добавил в папку Test в проект FinalProjectASP
        [TestMethod]
        public void TestTXTFiles()
        {
            string s = $"бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!!\nу ъящэячэц ъэюоык, едщ бдв саэацкшгнбяр гчеа кчфцшубп цу ьгщпя вщвсящ, эвэчрысй юяуъщнщхо шпуъликугбз чъцшья с цощъвчщ ъфмес ю лгюлэ ёъяяр! с моыящш шпмоец щаярдш цяэубфъ аьгэотызуа дщ, щръ кй юцкъщчьуац уыхэцэ ясч юбюяуяг ыовзсгюамщщ. внютвж тхыч эядкъябе цн юкъль, мэсццогл шяьфыоэьь ть эщсщжнашанэ ыюцен, уёюяыцчан мах гъъьуун шпмоыъй ч яяьпщъхэтпык яущм бпйэае! чэьюмуд, оээ скфч саьбрвчёыа эядуцйт ъ уьгфщуяяёу фси а эацэтшцэч юпапёи, ьь уъубфмч ысь хффы ужц чьяцнааущ эгъщйаъф, ч п эиттпьк ярвчг гмубзньцы! щб ьшяо шачюрэсч FirstLineSoftware ц ешчтфщацдпбр шыыь, р ыоф ячцсвкрщве бттй а ядсецсцкюкх эшашёрэсуъ якжще увюгщр в# уфн ысвчюпжзцж! чй ёюычъ бщххыибй еьюхечр п хкъмэншёцч юятщвфцшчщ с хчю ъэ ч аачсюсчыщачрняун в шъюьэжцясиьццч агфуо ацаьяычсцы .Net, чэбф ыуюбпьщо с чыдпяхбцйг щктрж!";
            Assert.AreEqual("",WorkWithText.GetTXTData(AppDomain.CurrentDomain.BaseDirectory+@"\Test\exitfile.txt")); //корректность работы программы при пустом файле
            Assert.AreEqual("скорпион", WorkWithText.GetTXTData(AppDomain.CurrentDomain.BaseDirectory + @"\Test\key.txt"));//корректность работы программы при .txt с кодировкой utf8
            Assert.AreEqual(s.Substring(0,5), WorkWithText.GetTXTData(AppDomain.CurrentDomain.BaseDirectory + @"\Test\Result_v5.txt").Substring(0,5));//корректность работы программы при .txt файле с кодировкой ANSI
        }
        [TestMethod]
        public void TestDocxFiles()
        {
            string s = $"бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!!\nу ъящэячэц ъэюоык, едщ бдв саэацкшгнбяр гчеа кчфцшубп цу ьгщпя вщвсящ, эвэчрысй юяуъщнщхо шпуъликугбз чъцшья с цощъвчщ ъфмес ю лгюлэ ёъяяр! с моыящш шпмоец щаярдш цяэубфъ аьгэотызуа дщ, щръ кй юцкъщчьуац уыхэцэ ясч юбюяуяг ыовзсгюамщщ. внютвж тхыч эядкъябе цн юкъль, мэсццогл шяьфыоэьь ть эщсщжнашанэ ыюцен, уёюяыцчан мах гъъьуун шпмоыъй ч яяьпщъхэтпык яущм бпйэае! чэьюмуд, оээ скфч саьбрвчёыа эядуцйт ъ уьгфщуяяёу фси а эацэтшцэч юпапёи, ьь уъубфмч ысь хффы ужц чьяцнааущ эгъщйаъф, ч п эиттпьк ярвчг гмубзньцы! щб ьшяо шачюрэсч FirstLineSoftware ц ешчтфщацдпбр шыыь, р ыоф ячцсвкрщве бттй а ядсецсцкюкх эшашёрэсуъ якжще увюгщр в# уфн ысвчюпжзцж! чй ёюычъ бщххыибй еьюхечр п хкъмэншёцч юятщвфцшчщ с хчю ъэ ч аачсюсчыщачрняун в шъюьэжцясиьццч агфуо ацаьяычсцы .Net, чэбф ыуюбпьщо с чыдпяхбцйг щктрж!";
            Assert.AreEqual(s.Substring(0, 5), WorkWithText.ParseWord(AppDomain.CurrentDomain.BaseDirectory + @"\Test\Result_v5.docx").Substring(0,5));
            Assert.AreEqual("", WorkWithText.ParseWord(AppDomain.CurrentDomain.BaseDirectory + @"\Test\AppDataDocx.docx"));
        }
        [TestMethod]
        public void TestEncrypt()
        {
            Assert.AreEqual("1233skjv", Crypto.Encrypt("1233skjv","мама"));//сообщение не должно измениться, если оно состоит не из букв русского алфавита
            Assert.AreEqual(null, Crypto.Encrypt("мама", "скорпион"));//должно вернуться null, если длина ключа больше длины сообщения
            Assert.AreEqual(null, Crypto.Encrypt("мама", "sк0r"));//должно вернуться null, если в ключе есть символ(-ы) не из русского алфавита
            Assert.AreEqual("бщцфаирщри", Crypto.Encrypt("поздравляю", "скорпион"));
        }
        [TestMethod]
        public void TestDecrypt()
        {
            Assert.AreEqual("1233skjv", Crypto.Decrypt("1233skjv", "мама"));//сообщение не должно измениться, если оно состоит не из букв русского алфавита
            Assert.AreEqual(null, Crypto.Decrypt("мама", "скорпион"));//должно вернуться null, если длина ключа больше длины сообщения
            Assert.AreEqual(null, Crypto.Decrypt("мама", "sк0r"));//должно вернуться null, если в ключе есть символ(-ы) не из русского алфавита
            Assert.AreEqual("поздравляю", Crypto.Decrypt("бщцфаирщри", "скорпион"));
           
        }
    }
}
