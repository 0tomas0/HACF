﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HACF {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HACF.Resources", typeof(Resources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert throw to catch block.
        /// </summary>
        internal static string CFT_CatchEmptyBlock {
            get {
                return ResourceManager.GetString("CFT_CatchEmptyBlock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert Exception.
        /// </summary>
        internal static string CFT_CatchWithoutException {
            get {
                return ResourceManager.GetString("CFT_CatchWithoutException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Change to interpolated string.
        /// </summary>
        internal static string CFT_StringFormat {
            get {
                return ResourceManager.GetString("CFT_StringFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Original exception throw;Inner exception throw.
        /// </summary>
        internal static string CFT_ThrowOriginalOrInnerException {
            get {
                return ResourceManager.GetString("CFT_ThrowOriginalOrInnerException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Catch block can insert throw..
        /// </summary>
        internal static string Description_CatchEmptyBlock {
            get {
                return ResourceManager.GetString("Description_CatchEmptyBlock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Catch code can insert Exception..
        /// </summary>
        internal static string Description_CatchWithoutException {
            get {
                return ResourceManager.GetString("Description_CatchWithoutException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Code can by change to Interpolated string..
        /// </summary>
        internal static string Description_StringFormat {
            get {
                return ResourceManager.GetString("Description_StringFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When is throw exception and he is throw with parameter the original stack trace can be lost..
        /// </summary>
        internal static string Description_ThrowOriginalOrInnerException {
            get {
                return ResourceManager.GetString("Description_ThrowOriginalOrInnerException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can insert throw to catch block..
        /// </summary>
        internal static string MessageFormat_CatchEmptyBlock {
            get {
                return ResourceManager.GetString("MessageFormat_CatchEmptyBlock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can insert Exception in catch..
        /// </summary>
        internal static string MessageFormat_CatchWithoutException {
            get {
                return ResourceManager.GetString("MessageFormat_CatchWithoutException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Code &apos;{0}&apos; can by transform to interpolated string code..
        /// </summary>
        internal static string MessageFormat_StringFormat {
            get {
                return ResourceManager.GetString("MessageFormat_StringFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When is throwed catched exception can be lost original stack trace..
        /// </summary>
        internal static string MessageFormat_ThrowOriginalOrInnerException {
            get {
                return ResourceManager.GetString("MessageFormat_ThrowOriginalOrInnerException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Catch block is empty can insert throw.
        /// </summary>
        internal static string Title_CatchEmptyBlock {
            get {
                return ResourceManager.GetString("Title_CatchEmptyBlock", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Catch can include Exception.
        /// </summary>
        internal static string Title_CatchWithoutException {
            get {
                return ResourceManager.GetString("Title_CatchWithoutException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Code with String.Format can change to Interpolated string.
        /// </summary>
        internal static string Title_StringFormat {
            get {
                return ResourceManager.GetString("Title_StringFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Throw can lost stack trace.
        /// </summary>
        internal static string Title_ThrowOriginalOrInnerException {
            get {
                return ResourceManager.GetString("Title_ThrowOriginalOrInnerException", resourceCulture);
            }
        }
    }
}