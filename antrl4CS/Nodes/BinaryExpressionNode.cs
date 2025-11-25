using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrl4CS.Nodes
{
    public class BinaryExpressionNode : ExpressionNode
    {
        public string Operator { get; set; }
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }
    }
}
