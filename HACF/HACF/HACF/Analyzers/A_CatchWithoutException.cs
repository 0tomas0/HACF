using HACF.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace HACF.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class A_CatchWithoutException : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rules.Rule[DiagnosticId.CatchWithouException]);

        public override void Initialize(AnalysisContext context) => context.RegisterSyntaxNodeAction(AnalyzeCode, SyntaxKind.CatchClause);

        private static void AnalyzeCode(SyntaxNodeAnalysisContext context)
        {
            CatchClauseSyntax source = (CatchClauseSyntax)context.Node;

            if (source == null) return;

            if (source.Declaration == null)
            {
                context.ReportDiagnostic(Diagnostic.Create(Rules.Rule[DiagnosticId.CatchWithouException], source.GetLocation()));
            }

        }
    }
}
