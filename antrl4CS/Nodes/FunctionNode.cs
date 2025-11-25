using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrl4CS.Nodes
{
   public class FunctionNode : DeclarationNode
  {
      public bool IsEntry; //si es una funcion de entrada o no
      public List<ParameterNode>? Parameters = [];
      public BlockNode Body = null!;
      
  }
}
