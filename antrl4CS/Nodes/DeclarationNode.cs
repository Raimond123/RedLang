using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace antrl4CS.Nodes
{
    public abstract class DeclarationNode : AstNode
    {
        public string name = null!;
        public TypeNode typeNode = null!;
    }
}
