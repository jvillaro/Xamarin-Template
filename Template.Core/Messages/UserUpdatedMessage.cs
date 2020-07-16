#region --- usings ---

using MvvmCross.Plugin.Messenger;
using Template.Models;

#endregion

namespace Template.Core.Messages
{
    /// <summary>
    /// Message sent when the user is updated 
    /// </summary>
    public class UserUpdatedMessage : MvxMessage
    {
        /// <summary>
        /// New user information
        /// </summary>
        public User User { get; }


        /// <summary>
        /// Constructor
        /// </summary>
        public UserUpdatedMessage(object sender, User user) : base(sender)
        {
            this.User = user;
        }
    }
}
