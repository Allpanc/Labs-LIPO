using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_LIPO.AST
{
    class BinaryOperatorNode : ExpressionNode
    {
        Token _operator;
        // Операнды
        ExpressionNode leftNode;
        ExpressionNode rightNode;

        public BinaryOperatorNode(Token @operator, ExpressionNode leftNode, ExpressionNode rightNode)
        {
            _operator = @operator;
            this.leftNode = leftNode;
            this.rightNode = rightNode;
        }
    }
}
