using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrl4CS.Nodes
{
    public class ParameterNode: AstNode
  {
       public string Name = null!;
      public TypeNode Type = null!;
  }
}
