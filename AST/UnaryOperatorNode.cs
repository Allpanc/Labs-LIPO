using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_LIPO.AST
{
    class UnaryOperatorNode : ExpressionNode
    {
        public Token _operator;
        public ExpressionNode _operand;

        public UnaryOperatorNode(Token @operator, ExpressionNode operand)
        {
            _operator = @operator;
            _operand = operand;
        }
    }
}
