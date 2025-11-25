using System.Collections.Generic;

namespace antrl4CS.Nodes
{
    public class BlockNode : AstNode
    {
        public List<AstNode> Statements { get; set; }

        public BlockNode()
        {
            Statements = new List<AstNode>();
        }
    }
}
