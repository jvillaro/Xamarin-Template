using SQLite;

namespace Template.Core.Entities
{
    /// <summary>
    /// This is a test table for the template
    /// This is just for testing purposes, please remove when developing an actual app
    /// </summary>
    public class Test
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
