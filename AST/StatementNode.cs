using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_LIPO.AST
{
    class StatementNode : ExpressionNode
    {
        List<ExpressionNode> _codeStrings = new List<ExpressionNode>();

        public void AddNode(ExpressionNode node)
        {
            _codeStrings.Add(node);
        }
    }
}
