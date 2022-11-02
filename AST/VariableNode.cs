using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_LIPO.AST
{
    class VariableNode : ExpressionNode
    {
        Token _variable;

        public VariableNode(Token variable)
        {
            _variable = variable;
        }
    }
}
