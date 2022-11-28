using Todo.Controllers.Helpers;
using System.Collections;
using System.Net;

namespace Todo.Controllers.Helpers
{
    /// <summary>
    public class Envelope<T>
    {
        private T result;
        public bool IsSuccess => String.IsNullOrEmpty(ErrorMessage);

        public Envelope()
        { }

        public T Result { get; set; }
        public string ErrorMessage { get; set; }
        public bool LimitationsReach { get; set; }
        public DateTime TimeGenerated { get; set; }

        // Nombre d'élément retournés par l'API dans le cas d'une collection
        public int? Count { get; }

        protected internal Envelope(string errorMessage)
        {
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }

        protected internal Envelope(T result)
        {
            Result = result;
            TimeGenerated = DateTime.UtcNow;
            if (result is ICollection<T>)
                Count = ((ICollection<T>)result).Count;
        }
    }
}

public class Envelope : Envelope<string>
{
    public Envelope(string result) : base(result)
    {
    }

    public Envelope(string errorMessage, HttpStatusCode code) : base(errorMessage)
    {
    }

    public static Envelope<T> Error<T>(string errorMessage)
    {
        return new Envelope<T>(errorMessage);
    }

    public static Envelope Error(string errorMessage)
    {
        return new Envelope(errorMessage);
    }

    public static Envelope<T> Ok<T>(T result)
    {
        return new Envelope<T>(result);
    }
}