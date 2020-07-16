#region --- usings ---

using System;
using System.Threading.Tasks;
using Xamarin.Forms;

#endregion

namespace Template.Core.Interfaces
{   
    /// <summary>
    /// Notification service.
    /// </summary>
    public interface INotificationService
    {
        Page MainPage { get; set; }


        /// <summary>
        /// Shows a pop up to the user (Xamarin.Forms DisplayAlert)
        /// </summary>
        /// <returns></returns>
        Task NotifyAsync(string title, string message, string buttonText = "");


        /// <summary>
        /// Shows a pop up to the user with confirmation (Xamarin.Forms DisplayAlert)
        /// </summary>   
        Task ConfirmAsync(string title, string message, string yesText, string noText, Action<bool> callback);
       
    }
}
