using System;
using System.Collections.Generic;
using System.Text;
using antrl4CS.Nodes;

namespace antrl4CS
{
    public class AstBuilderVisitor : construccion_semana2ParserBaseVisitor<AstNode>
    {
        //override el program de alguna forma
        //override 
        public override AstNode VisitProgram([Antlr4.Runtime.Misc.NotNull] construccion_semana2Parser.ProgramContext context)
        {
            var prog = new ProgramNode();
            foreach (var stmt in context.children)
            {
                var node = Visit(stmt);
                //switch (node

                if (node is UseNode s)
                    prog.Uses.Add(s);
                if (node is ClassNode c)
                    prog.Classes.Add(c);

            }
            return prog;
        }

        public override AstNode VisitLogicalOr(construccion_semana2Parser.LogicalOrContext context)
        {
            return new BinaryExpressionNode
            {
                Operator = "or",
                Left = (ExpressionNode)Visit(context.expression(0)),
                Right = (ExpressionNode)Visit(context.expression(1)),
                line = context.Start.Line,
                column = context.Start.Column
            };
        }

        public override AstNode VisitLogicalAnd(construccion_semana2Parser.LogicalAndContext context)
        {
            return new BinaryExpressionNode
            {
                Operator = "and",
                Left = (ExpressionNode)Visit(context.expression(0)),
                Right = (ExpressionNode)Visit(context.expression(1)),
                line = context.Start.Line,
                column = context.Start.Column
            };
        }

        public override AstNode VisitRelational(construccion_semana2Parser.RelationalContext context)
        {
            return new BinaryExpressionNode
            {
                Operator = context.comparador().GetText(),
                Left = (ExpressionNode)Visit(context.expression(0)),
                Right = (ExpressionNode)Visit(context.expression(1)),
                line = context.Start.Line,
                column = context.Start.Column
            };
        }


        public override AstNode VisitAddSub(construccion_semana2Parser.AddSubContext context)
        {
            return new BinaryExpressionNode
            {
                Operator = context.PLUS() != null ? "+" : "-",
                Left = (ExpressionNode)Visit(context.expression(0)),
                Right = (ExpressionNode)Visit(context.expression(1)),
                line = context.Start.Line,
                column = context.Start.Column
            };
        }


        public override AstNode VisitMulDiv(construccion_semana2Parser.MulDivContext context)
        {
            string op = context.MULTIPLY() != null ? "*" :
                        context.DIVIDE() != null ? "/" : "%";

            return new BinaryExpressionNode
            {
                Operator = op,
                Left = (ExpressionNode)Visit(context.expression(0)),
                Right = (ExpressionNode)Visit(context.expression(1)),
                line = context.Start.Line,
                column = context.Start.Column
            };
        }


        public override AstNode VisitUnaryMinus(construccion_semana2Parser.UnaryMinusContext context)
        {
            return new UnaryExpressionNode
            {
                Operator = "-",
                Operand = (ExpressionNode)Visit(context.expression()),
                line = context.Start.Line,
                column = context.Start.Column
            };
        }

        public override AstNode VisitLogicalNot(construccion_semana2Parser.LogicalNotContext context)
        {
            return new UnaryExpressionNode
            {
                Operator = "not",
                Operand = (ExpressionNode)Visit(context.expression()),
                line = context.Start.Line,
                column = context.Start.Column
            };
        }

        public override AstNode VisitAtom(construccion_semana2Parser.AtomContext context)
        {
            return Visit(context.factor());
        }


        public override AstNode VisitLiteral(construccion_semana2Parser.LiteralContext context)
        {
            var lit = new LiteralNode();
            lit.line = context.Start.Line;
            lit.column = context.Start.Column;

            if (context.INT() != null)
                lit.Value = int.Parse(context.INT().GetText());
            else if (context.FLOAT() != null)
                lit.Value = float.Parse(context.FLOAT().GetText());
            else if (context.STRING() != null)
                lit.Value = context.STRING().GetText().Trim('"');
            else if (context.BOOL() != null)
                lit.Value = context.BOOL().GetText() == "true";
            else
                lit.Value = null;

            return lit;
        }


    }

}
