using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Labs_LIPO
{
    class Lexer
    {
        string _code;
        int _position = 0;
        List<Token> _tokenList = new List<Token>();
        List<TokenType> tokenTypes = TokenType.tokenTypesDictionary.Values.ToList();

        public Lexer(string code)
        {
            _code = code;
        }

        public List<Token> Analyze()
        {
            //foreach (TokenType item in tokenTypes)
            //{
            //    Console.WriteLine(item);
            //}

            while (this.nextToken())
            {
                Console.WriteLine("Токен");
            }

            List<Token> filteredTokenList = _tokenList.FindAll(token => token._type != TokenType.tokenTypesDictionary[TokenType.TokenTypes.SPACE]);
            return filteredTokenList;
        }

        private bool nextToken()
        {
            if (_position >= _code.Length)
            {
                //Console.WriteLine("position " + _position + " >= " + _code.Length);
                return false;
            }

            for (int i = 0; i < tokenTypes.Count; i++)
            {
                TokenType tokenType = tokenTypes[i];
                Regex regex = new Regex("^" + tokenType._regex);
                Match result = regex.Match(_code.Substring(_position));

                if (result != null && result.Success)
                {
                    Token token = new Token(tokenType, result.Value, _position);
                    _position += result.Value.Length;                                                     
                    
                    _tokenList.Add(token);
                    Console.WriteLine("result = " + "\"" + result + "\"");
                    return true;
                }             
            }
            throw new Exception("На позиции " + _position + " обнаружена ошибка");
        }
    }
}
