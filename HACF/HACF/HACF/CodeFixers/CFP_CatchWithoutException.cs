using HACF.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HACF.CodeFixers
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CFP_CatchWithoutException)), Shared]
    public class CFP_CatchWithoutException : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(SettingsHelper.DiagnosticIds[DiagnosticId.CatchWithouException]);

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            Diagnostic diag = context.Diagnostics.First();
            context.RegisterCodeFix(CodeAction.Create(SettingsHelper.CodeFixTitles[DiagnosticId.CatchWithouException], x => InsertExceptionToCatch(context.Document, diag, x), $"{nameof(CFP_CatchWithoutException)}{nameof(InsertExceptionToCatch)}"), diag);
            return Task.FromResult(0);
        }

        private async Task<Document> InsertExceptionToCatch(Document document, Diagnostic diagnostic, CancellationToken cancellationToken)
        {
            SyntaxNode sn = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            CatchClauseSyntax ccs = sn.FindNode(diagnostic.Location.SourceSpan)
                                      .DescendantNodesAndSelf(null, false)
                                      .OfType<CatchClauseSyntax>().First();

            CatchClauseSyntax catchString = SyntaxFactory.CatchClause()
                                                         .WithDeclaration(SyntaxFactory.CatchDeclaration(SyntaxFactory.IdentifierName("Exception"))
                                                                         .WithIdentifier(SyntaxFactory.Identifier("ex"))
                                                                         .WithAdditionalAnnotations(Formatter.Annotation))
                                                         .WithBlock(ccs.Block);

            return document.WithSyntaxRoot(sn.ReplaceNode(ccs, catchString));
        }
    }
}
