using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace antrl4CS.Nodes
{
    public class FunctionCallNode : ExpressionNode
    {
        public string Name { get; set; }
        public List<ExpressionNode> Arguments { get; set; }

        public FunctionCallNode()
        {
            Arguments = new List<ExpressionNode>();
        }
    }
}
