using System;

namespace MeuDinheiro.Shared
{
    public abstract class Command : ICommand
    {
        public List<string> Errors { get; protected set; } = new List<string>();

        public bool IsValid => Errors.Count() > 0;

        protected void AddError(string error)
        {
            Errors.Add(error);
        }

        public abstract bool Validate();
    }
}
