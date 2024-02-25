namespace school_management.shared.view_models
{
    public class ApplicationViewModel
    {
        public string Message { get; set; }
        public IList<String>? Errors { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }

        public ApplicationViewModel(string message, bool success, object? data, IList<String>? errors)
        {
            this.Errors = errors;
            this.Message = message;
            this.Success = success;
            this.Data = data;
        }

    }
}
