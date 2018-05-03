using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace HACF.Helpers
{
    public static class Rules
    {
        public static Dictionary<DiagnosticId, DiagnosticDescriptor> Rule = new Dictionary<DiagnosticId, DiagnosticDescriptor>{
             { DiagnosticId.StringToInterpolated, CreateDiagnosticDescriptor(DiagnosticId.StringToInterpolated, Categories.Refactor, DiagnosticSeverity.Info) },
             { DiagnosticId.CatchWithouException, CreateDiagnosticDescriptor(DiagnosticId.CatchWithouException, Categories.Usable, DiagnosticSeverity.Info) },
             { DiagnosticId.CatchEmptyBlock, CreateDiagnosticDescriptor(DiagnosticId.CatchEmptyBlock, Categories.Usable, DiagnosticSeverity.Info) },
             { DiagnosticId.ThrowOriginalOrInnerException, CreateDiagnosticDescriptor(DiagnosticId.ThrowOriginalOrInnerException, Categories.Help, DiagnosticSeverity.Info) },
        };


        private static DiagnosticDescriptor CreateDiagnosticDescriptor(DiagnosticId diagnosticId, string categories, DiagnosticSeverity diagnosticSeverity)
        {
            return new DiagnosticDescriptor(SettingsHelper.DiagnosticIds[diagnosticId],
                                            SettingsHelper.AnalyzerTitles[diagnosticId],
                                            SettingsHelper.MessageFormats[diagnosticId],
                                            categories,
                                            diagnosticSeverity,
                                            isEnabledByDefault: true,
                                            description: SettingsHelper.Descriptions[diagnosticId]);
        }

    }
}
