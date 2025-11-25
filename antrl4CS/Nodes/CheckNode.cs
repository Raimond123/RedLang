using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrl4CS.Nodes
{
   public class CheckNode : StatementNode
  {
      public ExpressionNode Condition = null!;
      public BlockNode ThenBlock = null!;
      public BlockNode? ElseBlock;  // opcional (otherwiseOpcional)
  }
}
