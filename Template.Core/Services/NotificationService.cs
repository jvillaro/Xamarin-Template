#region --- usings ---

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
        public Page MainPage 
        { 
            get; 
            set; 
        }

        public async Task ConfirmAsync(string title, string message, string yesText, string noText, Action<bool> callback)
        {
            var result = await Application.Current.MainPage.DisplayAlert(title, message, yesText, noText);
            callback(result);
        }

        public async Task NotifyAsync(string title, string message, string buttonText = "")
        {
            await Application.Current.MainPage.DisplayAlert(title, message, buttonText);
            return;
        }
    }
}
