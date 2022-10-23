using System;
using System.Linq;

namespace ElCaminoDeCostaRica.Models
{
    public class CodeGenerator
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const string numbers = "1234567890";

        public CodeGenerator() { }

        public string generateRegisterCode (int size)
        {
            Random random = new Random();
            char[] charactersCode = new char[size];
            for (int counter = 0; counter < size; ++counter)
            {
                charactersCode[counter] = characters[random.Next(characters.Length)];
            }

            string code = new string(charactersCode);

            return code;
        }

        //Generate a numeric code
        public string generateStageCode (int size)
        {
            Random random = new Random();
            char[] charactersCode = new char[size];
            for (int counter = 0; counter < size; ++counter)
            {
                charactersCode[counter] = numbers[random.Next(numbers.Length)];
            }

            string code = new string(charactersCode);
            return code;
        }
    }
}