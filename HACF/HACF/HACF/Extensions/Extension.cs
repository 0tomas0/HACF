using HACF.Helpers;

namespace HACF.Extensions
{
    public static class Extension
    {
        /// <summary>
        /// Convert diagnosticId enum to analyze ID.
        /// </summary>
        /// <param name="diagnosticId"></param>
        /// <returns></returns>
        public static string ConvertDiagIdToAnalyzeId(this DiagnosticId diagnosticId) => $"TC{(int)diagnosticId:D4}";
    }
}
