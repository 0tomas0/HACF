using HACF.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace HACF.Analyzers
{
    /// <summary>
    /// Analyzer for finding string.format.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class A_StringFormat : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rules.Rule[DiagnosticId.StringToInterpolated]);

        public override void Initialize(AnalysisContext context) => context.RegisterSyntaxNodeAction(AnalyzeCode, SyntaxKind.InvocationExpression);

        private static void AnalyzeCode(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is InvocationExpressionSyntax source))
            {
                return;
            }

            if (source.ToString().ToLower().StartsWith("string.format") &&
                source.ToString().ToLower().IndexOf("{0}") > 0 &&
                source.ToString().ToLower().IndexOf("string.format", 5) < 0)
            {
                context.ReportDiagnostic(Diagnostic.Create(Rules.Rule[DiagnosticId.StringToInterpolated], source.GetLocation(), new object[1] { source.ToString() }));
            }
        }
    }
}
