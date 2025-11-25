using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrl4CS.Nodes
{
  public class VariableNode : DeclarationNode
  {
      //Creado en: VisitDeclare_stmt y VisitDecl_head (cuando es decl con posible inicializador).
      public ExpressionNode? Expression; //? por si es opcional
      
  }
}
