namespace antrl4CS.Node
{
    public class MemberAccessNode : AstNode
    {
        public AstNode Target { get; set; } = null!;
        public string MemberName { get; set; } = string.Empty;
    }
}