using HACF.Analyzers;
using HACF.CodeFixers;
using Xunit;

namespace HACF.Tests.TestClasses.Analyzers
{
    public class A_StringFormatTest : CodeFixVerifier<A_StringFormat, CFP_StringFormatToInterpolatedString>
    {
        [Fact]
        public void NoDiagnosticForString()
        {
            const string source = @"using System;
                                    namespace TestAppp
                                    {
                                        class TypeName
                                        {
                                            void Foo()
                                            {
                                                var string a = ""ahoj"";
                                            }
                                        }
                                    }";
            VerifyCSharpDiagnostic(source);
        }

        [Fact]
        public void NoDiagnosticForStringCompare()
        {
            const string source = @"using System;
                                    namespace TestAppp
                                    {
                                        class TypeName
                                        {
                                            void Foo()
                                            {
                                                var string a = string.Compare(""ahoj"", ""cau"");
                                            }
                                        }
                                    }";
            VerifyCSharpDiagnostic(source);
        }

        [Fact]
        public void NoDiagnosticForStringvalue()
        {
            const string source = @"using System;
                                    namespace TestAppp
                                    {
                                        class TypeName
                                        {
                                            void Foo()
                                            {
                                                var stringformat a = ""ahoj"";
                                            }
                                        }
                                    }";
            VerifyCSharpDiagnostic(source);
        }
    }
}
