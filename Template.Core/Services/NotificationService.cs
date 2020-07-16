#region --- usings ---

using MvvmCross;
using MvvmCross.Plugin.JsonLocalization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Interfaces;
using Xamarin.Forms;

#endregion

namespace Template.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMvxTextProviderBuilder textProviderBuilder;
     
        public Page MainPage { get; set; }

        public NotificationService()
        {
            this.textProviderBuilder = Mvx.IoCProvider.GetSingleton<IMvxTextProviderBuilder>();
        }

        public async Task NotifyAsync(string title, string message, string buttonText = "")
        {
            await Application.Current.MainPage.DisplayAlert(GetText(title), GetText(message), GetText(buttonText));
            return;
        }


        public async Task ConfirmAsync(string title, string message, string yesText, string noText, Action<bool> callback)
        {
            var result = await Application.Current.MainPage.DisplayAlert(GetText(title), GetText(message), GetText(yesText), GetText(noText));
            callback(result);
        }


        #region --- GetText ---

        /// <summary>
        /// Helper method for getting a localized text
        /// </summary>
        /// <param name="text">Text to get</param>
        /// <returns>Localized text</returns>
        public string GetText(string text)
        {
            var outText = this.textProviderBuilder.TextProvider.GetText(
                TextProviderConstants.GeneralNamespace, TextProviderConstants.ClassName, text);

            return outText;
        }

        #endregion
    }
}
