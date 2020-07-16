#region --- usings ---

using MvvmCross.IoC;
using MvvmCross.Plugin.JsonLocalization;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace Template.Core.Services
{
    /// <summary>
    /// Constants used for localizations values
    /// </summary>
    public static class TextProviderConstants
    {
        public const string RootFolderForResources = "Languages";
        public const string GeneralNamespace = "Template";
        public const string ClassName = "ViewModels";
        public const string FileName = "Texts";
    }


    /// <summary>
    /// Json localization provider
    /// </summary>
    public class TextProviderBuilder : MvxTextProviderBuilder
    {
        protected override IDictionary<string, string> ResourceFiles => new Dictionary<string, string>
        {
            {
                TextProviderConstants.ClassName,
                TextProviderConstants.FileName
            }
        };

        public TextProviderBuilder()
            : base(TextProviderConstants.GeneralNamespace, TextProviderConstants.RootFolderForResources)
        {
        }
    }
}
