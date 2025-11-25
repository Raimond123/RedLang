using System;
using System.Collections.Generic;
using System.Text;

namespace antrl4CS.Nodes
{
    public class ClassNode : AstNode
    {
        public string ClassName = null!;
        public List<DeclarationNode> members { get; } = [];

    }
}
