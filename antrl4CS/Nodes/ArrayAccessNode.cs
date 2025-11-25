using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrl4CS.Nodes
{
    public class ArrayAccessNode : ExpressionNode
    {
        public ExpressionNode Array { get; set; }
        public ExpressionNode Index { get; set; }
    }
}
