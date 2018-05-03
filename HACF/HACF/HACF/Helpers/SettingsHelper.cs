using HACF.Extensions;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace HACF.Helpers
{
    public static class SettingsHelper
    {
        public static Dictionary<DiagnosticId, string> DiagnosticIds = new Dictionary<DiagnosticId, string>()
        {
            { DiagnosticId.StringToInterpolated, DiagnosticId.StringToInterpolated.ConvertDiagIdToAnalyzeId() },
            { DiagnosticId.CatchWithouException, DiagnosticId.CatchWithouException.ConvertDiagIdToAnalyzeId() },
            { DiagnosticId.CatchEmptyBlock, DiagnosticId.CatchEmptyBlock.ConvertDiagIdToAnalyzeId() },
            { DiagnosticId.ThrowOriginalOrInnerException, DiagnosticId.ThrowOriginalOrInnerException.ConvertDiagIdToAnalyzeId() },
        };

        public static readonly Dictionary<DiagnosticId, LocalizableString> AnalyzerTitles = new Dictionary<DiagnosticId, LocalizableString>()
        {
            { DiagnosticId.StringToInterpolated, new LocalizableResourceString(nameof(Resources.Title_StringFormat), Resources.ResourceManager, typeof(Resources)) },
            { DiagnosticId.CatchWithouException, new LocalizableResourceString(nameof(Resources.Title_CatchWithoutException), Resources.ResourceManager, typeof(Resources)) },
            { DiagnosticId.CatchEmptyBlock, new LocalizableResourceString(nameof(Resources.Title_CatchEmptyBlock), Resources.ResourceManager, typeof(Resources)) },
            { DiagnosticId.ThrowOriginalOrInnerException, new LocalizableResourceString(nameof(Resources.Title_ThrowOriginalOrInnerException), Resources.ResourceManager, typeof(Resources)) },
        };

        public static readonly Dictionary<DiagnosticId, LocalizableString> MessageFormats = new Dictionary<DiagnosticId, LocalizableString>()
        {
            { DiagnosticId.StringToInterpolated, new LocalizableResourceString(nameof(Resources.MessageFormat_StringFormat), Resources.ResourceManager, typeof(Resources)) },
            { DiagnosticId.CatchWithouException, new LocalizableResourceString(nameof(Resources.MessageFormat_CatchWithoutException), Resources.ResourceManager, typeof(Resources)) },
            { DiagnosticId.CatchEmptyBlock, new LocalizableResourceString(nameof(Resources.MessageFormat_CatchEmptyBlock), Resources.ResourceManager, typeof(Resources)) },
            { DiagnosticId.ThrowOriginalOrInnerException, new LocalizableResourceString(nameof(Resources.MessageFormat_ThrowOriginalOrInnerException), Resources.ResourceManager, typeof(Resources)) },
        };

        public static readonly Dictionary<DiagnosticId, LocalizableString> Descriptions = new Dictionary<DiagnosticId, LocalizableString>()
        {
            { DiagnosticId.StringToInterpolated, new LocalizableResourceString(nameof(Resources.Description_StringFormat), Resources.ResourceManager, typeof(Resources)) },
            { DiagnosticId.CatchWithouException, new LocalizableResourceString(nameof(Resources.Description_CatchWithoutException), Resources.ResourceManager, typeof(Resources)) },
            { DiagnosticId.CatchEmptyBlock, new LocalizableResourceString(nameof(Resources.Description_CatchEmptyBlock), Resources.ResourceManager, typeof(Resources)) },
            { DiagnosticId.ThrowOriginalOrInnerException, new LocalizableResourceString(nameof(Resources.Description_ThrowOriginalOrInnerException), Resources.ResourceManager, typeof(Resources)) },
        };

        public static readonly Dictionary<DiagnosticId, string> CodeFixTitles = new Dictionary<DiagnosticId, string>()
        {
            { DiagnosticId.StringToInterpolated, Resources.CFT_StringFormat },
            { DiagnosticId.CatchWithouException, Resources.CFT_CatchWithoutException },
            { DiagnosticId.CatchEmptyBlock, Resources.CFT_CatchEmptyBlock },
            { DiagnosticId.ThrowOriginalOrInnerException, Resources.CFT_ThrowOriginalOrInnerException },
        };
    }
}
