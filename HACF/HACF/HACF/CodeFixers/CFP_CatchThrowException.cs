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
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CFP_CatchThrowException)), Shared]
    public class CFP_CatchThrowException : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(SettingsHelper.DiagnosticIds[DiagnosticId.ThrowOriginalOrInnerException]);

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            Diagnostic diag = context.Diagnostics.First();
            var titles = SettingsHelper.CodeFixTitles[DiagnosticId.ThrowOriginalOrInnerException].Split(';');
            context.RegisterCodeFix(CodeAction.Create(titles[0], x => ThrowOriginalException(context.Document, diag, x), $"{nameof(CFP_CatchThrowException)}{nameof(ThrowOriginalException)}"), diag);
            context.RegisterCodeFix(CodeAction.Create(titles[1], x => ThrowInnerException(context.Document, diag, x), $"{nameof(CFP_CatchThrowException)}{nameof(ThrowInnerException)}"), diag);
            return Task.FromResult(0);
        }

        private async Task<Document> ThrowOriginalException(Document document, Diagnostic diagnostic, CancellationToken cancellationToken)
        {
            SyntaxNode sn = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            ThrowStatementSyntax ccs = sn.FindNode(diagnostic.Location.SourceSpan)
                                         .DescendantNodesAndSelf(null, false)
                                         .OfType<ThrowStatementSyntax>().First();

            ThrowStatementSyntax throwString = (ThrowStatementSyntax)SyntaxFactory.ParseStatement("throw ;")
                                                                                  .WithAdditionalAnnotations(Formatter.Annotation);

            return document.WithSyntaxRoot(sn.ReplaceNode(ccs, throwString));
        }

        private async Task<Document> ThrowInnerException(Document document, Diagnostic diagnostic, CancellationToken cancellationToken)
        {
            SyntaxNode sn = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            ThrowStatementSyntax tss = sn.FindNode(diagnostic.Location.SourceSpan)
                                         .DescendantNodesAndSelf(null, false)
                                         .OfType<ThrowStatementSyntax>().First();

            ThrowStatementSyntax throwStatement = SyntaxFactory.ThrowStatement(
                                                    SyntaxFactory.ObjectCreationExpression(
                                                        SyntaxFactory.ParseTypeName("System.Exception")).AddArgumentListArguments(
                                                                    new[]
                                                                    {
                                                                        SyntaxFactory.Argument(SyntaxFactory.ParseExpression("\"Make your text here for exception.\"")),
                                                                        SyntaxFactory.Argument(SyntaxFactory.ParseExpression(((CatchClauseSyntax)tss.Parent.Parent).Declaration.Identifier.ToString())),
                                                                    })).WithAdditionalAnnotations(Formatter.Annotation);


            return document.WithSyntaxRoot(sn.ReplaceNode(tss, throwStatement));
        }
    }
}
