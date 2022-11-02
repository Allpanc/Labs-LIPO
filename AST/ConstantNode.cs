using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_LIPO.AST
{
    class ConstantNode : ExpressionNode
    {
        public Token _number;

        public ConstantNode(Token number)
        {
            _number = number;
        }
    }
}
