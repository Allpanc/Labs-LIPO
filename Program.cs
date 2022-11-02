using System;
using System.Collections.Generic;

namespace Labs_LIPO
{
    class Program
    {
        static void Main(string[] args)
        {
            #region("Tests")
            // Правильный пример
            string test = "a = 5; b = 11; c = 2; sum = a + (b - c); sum -= 1;";
            string test1 = "Var a,    b,c,sum :Integer; Begin a = 5; b = 11; c = 2; sum = a + (b - c); sum -= 1; End.";
            // Неправильный пример: Нет Begin
            string test2 = "Var a,b,c, sum :Integer; a = 5; b = 11; c = 2; sum = a + b - c; sum -= 1; End.";
            // Неправильный пример: c := 2
            string test3 = "Var a1,b,c :Integer, sum :Integer; Begin {a = 5; b = 11; c := 2; 5 -= 6; sum =- a + b - c; sum -= 1; sum *= 1; End.}";
            // Неправильный пример: Нет Var
            string test4 = "a,b,c, sum :Integer; Begin a = 5; b = 11; c = 2; sum = a + b - c; sum -= 1; End.";
            // Есть лишный символ {}
            string test5 = "a,b,c, sum :Integer{}; Begin a = 5; b = 11; c = 2; sum = a + b - c; sum -= 1; End.";
            // Два символа разделителя подряд
            string test6 = "Var a,b,c, sum ::Integer; Begin a = 5; b = 11; c = 2; sum = a + (b - c); sum -= 1; End.";
            #endregion

            Lexer lexer = new Lexer(test1);
            List<Token> tokens = lexer.Analyze();

            foreach (Token token in tokens)
            {
                Console.WriteLine(token);
            }

            Parser parser = new Parser(tokens);
            Parser.

            Console.ReadLine();
        }
    }
}
