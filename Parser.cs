using Labs_LIPO.AST;
using System;
using System.Collections.Generic;

namespace Labs_LIPO
{
    class Parser
    {
        List<Token> _tokens;
        int _position = 0;
        Object _scope;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
        }

        public void Run(ExpressionNode node)
        {
            if (node.GetType() == typeof(ConstantNode))
            {
                ConstantNode constant = (ConstantNode)node;
                //return constant._number;
            }
            if (node.GetType() == typeof(UnaryOperatorNode))
            {
                UnaryOperatorNode unary = (UnaryOperatorNode)node;
                switch (unary._operator._type._name)
                {
                }
            }
        }

        Token Match(List<TokenType> expectedTokenTypes)
        {
            if (_position < _tokens.Count)
            {
                Token currentToken = _tokens[_position];

                if (expectedTokenTypes.Find(type => type._name == currentToken._type._name) != null)
                {
                    _position++;
                    return currentToken;
                }

            }
            return null;
        }

        Token Require(List<TokenType> expectedTokenTypes)
        {
            Token token = Match(expectedTokenTypes);
            if (token != null)
            {
                throw new Exception("на позиции " + _position + " ожидается " + expectedTokenTypes[0]._name);
            }
            return token;
        }


        ExpressionNode ParseCode()
        {
            // Корневой узел, содержит список узлов, каждыцй из которых является строкой
            StatementNode root = new StatementNode();
            while (_position < _tokens.Count)
            {
                var codeStringNode = ParseExpression();
                // Требуется точка с запятой
                Require(new List<TokenType> { TokenType.tokenTypesDictionary[TokenType.TokenTypes.SEMICOLON] });
                root.AddNode(codeStringNode);
            }
            return root;
        }

        // Функция для парсинга отдельной строки
        private ExpressionNode ParseExpression()
        {
            if (Match(new List<TokenType> { TokenType.tokenTypesDictionary[TokenType.TokenTypes.VARIABLE] }) != null)
            {
                _position -= 1;
                VariableNode variableNode = (VariableNode)ParseVariableOrConstant();
                Token assignOperator = Match(new List<TokenType> { TokenType.tokenTypesDictionary[TokenType.TokenTypes.ASSIGN] });
                if (assignOperator != null)
                {
                    ExpressionNode rightFormulaNode = ParseFormula();
                    BinaryOperatorNode binaryOperatorNode = new BinaryOperatorNode(assignOperator, variableNode, rightFormulaNode);
                    return binaryOperatorNode;
                }           
            }
            throw new Exception("После переменной ожидается оператор присваивания на позиции " + _position);
        }

        // Рекурсивное построение дерева
        private ExpressionNode ParseFormula()
        {
            ExpressionNode leftNode = new ExpressionNode();
            Token @operator = Match(new List<TokenType> {   TokenType.tokenTypesDictionary[TokenType.TokenTypes.UNARY_OPERATOR],
                                                            TokenType.tokenTypesDictionary[TokenType.TokenTypes.UNARY_OPERATOR]});
            
            while (@operator != null)
            {
                ExpressionNode rightNode = new ExpressionNode();
                leftNode = new BinaryOperatorNode(@operator, leftNode, rightNode);
                @operator = Match(new List<TokenType> {     TokenType.tokenTypesDictionary[TokenType.TokenTypes.UNARY_OPERATOR],
                                                            TokenType.tokenTypesDictionary[TokenType.TokenTypes.UNARY_OPERATOR]});
            }
            return leftNode;
        }

        private ExpressionNode ParsePrint()
        {
            Token @operator = Match(new List<TokenType> { TokenType.tokenTypesDictionary[TokenType.TokenTypes.UNARY_OPERATOR] });
            if (@operator != null)
                return new UnaryOperatorNode(@operator, ParseFormula());
            throw new Exception("Ожидается унарный оператор на позиции " + _position);
        }

        private ExpressionNode ParseBrackets()
        {
            if (Match(new List<TokenType> { TokenType.tokenTypesDictionary[TokenType.TokenTypes.LEFT_BRACKET] }) != null)
            {
                ExpressionNode node = ParseFormula();
                Require(new List<TokenType> { TokenType.tokenTypesDictionary[TokenType.TokenTypes.RIGHT_BRACKET] });
                return node;
            }
            else
            {
                return ParseVariableOrConstant();
            }
        }

        private ExpressionNode ParseVariableOrConstant()
        {
            Token constant = Match(new List<TokenType> { TokenType.tokenTypesDictionary[TokenType.TokenTypes.CONSTANT] });
            if (constant != null)
                return new ConstantNode(constant);

            Token variable = Match(new List<TokenType> { TokenType.tokenTypesDictionary[TokenType.TokenTypes.CONSTANT] });
            if (variable != null)
                return new VariableNode(variable);

            throw new Exception("Ожидается переменная или число на позиции " + _position);
        }
    }
}
