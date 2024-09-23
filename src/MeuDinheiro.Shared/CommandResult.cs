using System;

namespace MeuDinheiro.Shared
{
    public class CommandResult : ICommand
    {
        public bool IsSuccess { get; private set; }

        public string Message { get; private set; }

        public object Data { get; private set; }

        public CommandResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public CommandResult(bool isSuccess, string message, object data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
    }
}
