namespace Utilities
{
    public class OperationResult
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        private OperationResult(bool isSuccess, string message = "Empty message")
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        
        public static OperationResult Success()
        {
            return new OperationResult(true);
        }

        
        public static OperationResult Failure(string errorMessage)
        {
            return new OperationResult(false, errorMessage);
        }
    }
}