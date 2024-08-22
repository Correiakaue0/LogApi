namespace LogApi.Models
{
    public class Settings
    {
        public Settings()
        {
            ConnectionString = string.Empty;
            Database = string.Empty;
        }

        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}