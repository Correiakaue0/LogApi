namespace LogApi.Models.ViewModels
{
    public class LogViewModel
    {
        public LogViewModel()
        {
            ProcessName = string.Empty;
            Message = string.Empty;
            Details = string.Empty;
        }

        public string ProcessName { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}