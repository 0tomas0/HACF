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
            ThrowStatementSyntax source = (ThrowStatementSyntax)context.Node;

            if (source == null) return;

            var exp = source.Expression;
            if (exp != null)
            {
                var catchIdentifier = ((CatchClauseSyntax)source.Parent.Parent).Declaration.Identifier;
                if (catchIdentifier.ToString() == exp.ToString())
                {
                    context.ReportDiagnostic(Diagnostic.Create(Rules.Rule[DiagnosticId.ThrowOriginalOrInnerException], source.GetLocation()));
                }
            }
        }
    }
}
