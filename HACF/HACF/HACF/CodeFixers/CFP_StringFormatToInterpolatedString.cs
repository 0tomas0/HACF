using HACF.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HACF.CodeFixers
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CFP_StringFormatToInterpolatedString)), Shared]
    public class CFP_StringFormatToInterpolatedString : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(SettingsHelper.DiagnosticIds[DiagnosticId.StringToInterpolated]);

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            Diagnostic diag = context.Diagnostics.First();
            context.RegisterCodeFix(CodeAction.Create(SettingsHelper.CodeFixTitles[DiagnosticId.StringToInterpolated], x => ConvertToInterpolated(context.Document, diag, x), $"{nameof(CFP_StringFormatToInterpolatedString)}{nameof(ConvertToInterpolated)}"), diag);
            return Task.FromResult(0);
        }

        private async Task<Document> ConvertToInterpolated(Document document, Diagnostic diagnostic, CancellationToken cancellationToken)
        {
            SyntaxNode sn = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            InvocationExpressionSyntax ies = sn.FindNode(diagnostic.Location.SourceSpan)
                                               .DescendantNodesAndSelf(null, false)
                                               .OfType<InvocationExpressionSyntax>().First();

            var argumentList = ies.DescendantNodes(null, false)
                                  .Where(x => Microsoft.CodeAnalysis.CSharp.CSharpExtensions.Kind(x) == SyntaxKind.ArgumentList).ToList()[0];
            var arguments = argumentList.DescendantNodes(null, false)
                                        .Where(x => Microsoft.CodeAnalysis.CSharp.CSharpExtensions.Kind(x) == SyntaxKind.Argument && x.Parent == argumentList)
                                        .ToList();

            StringBuilder sb = new StringBuilder("$" + arguments[0]);
            for (int i = 1; i < arguments.Count; ++i)
            {
                var old = string.Format("{{{0}}}", Convert.ToString(i - 1));
                var newString = string.Format("{{{0}}}", Convert.ToString(arguments[i]));
                if (newString.Contains("?"))
                {
                    newString = $"{{({newString.TrimStart('{').TrimEnd('}')})}}";
                }
                sb = sb.Replace(old, newString);
            }
            SourceText st = (await document.GetTextAsync(cancellationToken)).Replace(ies.Span, sb.ToString());

            return document.WithText(st);
        }
    }
}
