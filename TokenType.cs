using System.Collections.Generic;

namespace Labs_LIPO
{
    class TokenType
    {
        public string _name { get; private set; }
        public string _regex { get; private set; }

        public enum TokenTypes
        {
            VAR,
            BEGIN,
            END,
            VARIABLE,
            CONSTANT,
            SPACE,
            UNARY_OPERATOR,
            BINARY_OPERATOR,
            ASSIGN,
            SEMICOLON,
            COLON,
            COMMA,
            DOT,
            LEFT_BRACKET,
            RIGHT_BRACKET
        }
        public static Dictionary<TokenTypes, TokenType> tokenTypesDictionary = 
            new Dictionary<TokenTypes, TokenType>()
        {
                {TokenTypes.VAR, new TokenType("VAR", @"Var") },
                {TokenTypes.BEGIN, new TokenType("BEGIN", @"Begin") },
                {TokenTypes.END, new TokenType("END", @"End") },

                {TokenTypes.VARIABLE, new TokenType("VARIABLE", @"[a-zA-Zа-яА-Я]+") },
                {TokenTypes.CONSTANT, new TokenType("CONSTANT", @"[\d]+") },

                {TokenTypes.SPACE, new TokenType("SPACE", @"[ ]{1,}") },

                {TokenTypes.UNARY_OPERATOR, new TokenType("UNARY_OPERATOR", @"\=-") },
                {TokenTypes.BINARY_OPERATOR, new TokenType("BINARY_OPERATOR", @"(\+|\-|\*|\/)") },
                {TokenTypes.ASSIGN, new TokenType("ASSIGN", @"\=") },

                {TokenTypes.SEMICOLON, new TokenType("SEMICOLON", @"(;)") },
                {TokenTypes.COLON, new TokenType("COLON", @"(:)") },
                {TokenTypes.COMMA, new TokenType("COMMA", @"(,)") },
                {TokenTypes.DOT, new TokenType("DOT", @"(\.)") },

                {TokenTypes.LEFT_BRACKET, new TokenType("LEFT_BRACKET", @"\(") },
                {TokenTypes.RIGHT_BRACKET, new TokenType("RIGHT_BRACKET", @"\)") }
        };

        public TokenType(string name, string regex)
        {
            _name = name;
            _regex = regex;
        }

        public override string ToString()
        {
            return "name: " + _name + " regex: " + _regex;
        }
    }
}
