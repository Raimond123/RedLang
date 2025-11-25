using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrl4CS.Nodes
{
   public class LoopNode : StatementNode
  {
      public AstNode? Init; // VariableNode o SetNode, LoopInit
      public ExpressionNode Condition = null!;
      public SetNode Iteration = null!; //accionLoop
      public BlockNode Body = null!;
  }
}
