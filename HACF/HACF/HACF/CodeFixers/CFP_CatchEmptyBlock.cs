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
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CFP_CatchEmptyBlock)), Shared]
    public class CFP_CatchEmptyBlock : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(SettingsHelper.DiagnosticIds[DiagnosticId.CatchEmptyBlock]);

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            Diagnostic diag = context.Diagnostics.First();
            context.RegisterCodeFix(CodeAction.Create(SettingsHelper.CodeFixTitles[DiagnosticId.CatchEmptyBlock], x => InsertThrowToCatch(context.Document, diag, x), $"{nameof(CFP_CatchEmptyBlock)}{nameof(InsertThrowToCatch)}"), diag);
            return Task.FromResult(0);
        }

        private async Task<Document> InsertThrowToCatch(Document document, Diagnostic diagnostic, CancellationToken cancellationToken)
        {
            SyntaxNode sn = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            CatchClauseSyntax ccs = sn.FindNode(diagnostic.Location.SourceSpan)
                                      .DescendantNodesAndSelf(null, false)
                                      .OfType<CatchClauseSyntax>().First();

            CatchClauseSyntax throwString = SyntaxFactory.CatchClause()
                                                         .WithDeclaration(ccs.Declaration)
                                                         .WithBlock(SyntaxFactory.Block(new StatementSyntax[] { SyntaxFactory.ThrowStatement() }))
                                                         .WithAdditionalAnnotations(Formatter.Annotation);

            return document.WithSyntaxRoot(sn.ReplaceNode(ccs, throwString));
        }
    }
}
