using HACF.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace HACF.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class A_CatchEmptyBlock : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rules.Rule[DiagnosticId.CatchEmptyBlock]);

        public override void Initialize(AnalysisContext context) => context.RegisterSyntaxNodeAction(AnalyzeCode, SyntaxKind.CatchClause);

        private static void AnalyzeCode(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is CatchClauseSyntax source))
            {
                return;
            }

            if (source.Block?.Statements.Count == 0)
            {
                context.ReportDiagnostic(Diagnostic.Create(Rules.Rule[DiagnosticId.CatchEmptyBlock], source.GetLocation()));
            }
        }
    }
}
