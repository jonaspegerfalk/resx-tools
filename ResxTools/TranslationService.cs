using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;

namespace ResxTools
{
    public class TranslationService
    {
        private string language;
        private TranslationClient translationClient;

        public TranslationService(string language)
        {
            this.language = language;
            this.translationClient = TranslationClient.Create();
        }
        public static TranslationService CreateTranslationService(string language)
        {
            return new TranslationService(language);
        }

        public string TranslateText (string text)
        {
            Console.Write(".");
            var response = translationClient.TranslateText(text, language);
            return response.TranslatedText;
        }


    }
}
