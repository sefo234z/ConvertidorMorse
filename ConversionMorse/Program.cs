using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConversionMorse
{
    internal class Program
    {
        static Dictionary<char, string> morseDict = new Dictionary<char, string>()
        {
            { 'A', ".-" }, { 'B', "-..." }, { 'C', "-.-." }, { 'D', "-.." },
            { 'E', "." }, { 'F', "..-." }, { 'G', "--." }, { 'H', "...." },
            { 'I', ".." }, { 'J', ".---" }, { 'K', "-.-" }, { 'L', ".-.." },
            { 'M', "--" }, { 'N', "-." }, { 'O', "---" }, { 'P', ".--." },
            { 'Q', "--.-" }, { 'R', ".-." }, { 'S', "..." }, { 'T', "-" },
            { 'U', "..-" }, { 'V', "...-" }, { 'W', ".--" }, { 'X', "-..-" },
            { 'Y', "-.--" }, { 'Z', "--.." },
            { '0', "-----" }, { '1', ".----" }, { '2', "..---" },
            { '3', "...--" }, { '4', "....-" }, { '5', "....." },
            { '6', "-...." }, { '7', "--..." }, { '8', "---.." },
            { '9', "----." }, { ' ', "/" }
        };

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("---------------MENU----------------");
            Console.WriteLine("1-Convertir texto a morse.");
            Console.WriteLine("2-Convertir morse a texto.");
            Console.WriteLine("3-Salir.");
            Console.Write("Opcion(1-3): ");

            int opcionMenu = Convert.ToInt32(Console.ReadLine());

            switch (opcionMenu)
            {
                case 1:
                    Console.WriteLine(ConversionMorse());
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine(ConversionTexto());
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Adios!");
                    break;
                default:
                    Console.WriteLine("No has seleccionado un numero entre 1-3");
                    Menu();
                    break;
            }
        }

        static string ConversionMorse()
        {
            Console.WriteLine("Dime el Texto que quieres convertir: ");
            string texto = Console.ReadLine();

            return string.Join(" ",
                texto.ToUpper()
                     .Where(c => morseDict.ContainsKey(c))
                     .Select(c => morseDict[c]));
        }

        static string ConversionTexto()
        {
            Console.Write("Dime el codigo Morse que quieres convertir: ");
            string morse = Console.ReadLine();

            var morseInverso = morseDict.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

            return string.Join("",
                morse.Split(' ')
                     .Where(s => morseInverso.ContainsKey(s))
                     .Select(s => morseInverso[s]));
        }
    }
}
