using System;
using System.Collections.Generic;
using System.Text;

namespace antrl4CS.Nodes
{
    public class ProgramNode : AstNode
    {
        public List<UseNode> Uses { get; } = [];
        public List<ClassNode> Classes { get; } = [];
    }
}
