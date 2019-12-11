#region --- Usings ---

using Template.Core.Enums;

#endregion

namespace Template.Core.Models
{
    /// <summary>
    /// Menu item
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Menu item key
        /// </summary>
        public MenuItemKey Key { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Item description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Item icon
        /// </summary>
        public string Icon { get; set; }
    }
}
