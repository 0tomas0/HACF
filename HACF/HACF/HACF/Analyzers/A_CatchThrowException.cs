using HACF.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace HACF.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class A_CatchThrowException : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rules.Rule[DiagnosticId.ThrowOriginalOrInnerException]);

        public override void Initialize(AnalysisContext context) => context.RegisterSyntaxNodeAction(AnalyzeCode, SyntaxKind.ThrowStatement);

        private static void AnalyzeCode(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is ThrowStatementSyntax source))
            {
                return;
            }

            ExpressionSyntax exp = source.Expression;
            if (exp != null)
            {
                var catchIdentifier = (source.Parent.Parent as CatchClauseSyntax)?.Declaration.Identifier;
                if (catchIdentifier?.ToString() == exp.ToString())
                {
                    context.ReportDiagnostic(Diagnostic.Create(Rules.Rule[DiagnosticId.ThrowOriginalOrInnerException], source.GetLocation()));
                }
            }
        }
    }
}
