using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrl4CS.Nodes
{
   public class ArrayLiteralNode : ExpressionNode
  {
      //arg_list
      public List<ExpressionNode> Elements { get; } = [];
  }
}
