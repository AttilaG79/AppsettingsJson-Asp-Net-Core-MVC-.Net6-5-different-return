namespace AppsettingsJson.Models
{
    public class DataModel
    {
        public const string AdminInfo = "AdminInfo";

        public string AdminName { get; set; } = string.Empty;
        public int AdminId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
