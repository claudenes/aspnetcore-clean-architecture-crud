using FluentValidation.Results;

namespace Colorado.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Registro { get; set; }
        public ICollection<ErrorValidation>? Errors { get; set; }
        public static ResultService RequestError(string message, ValidationResult? validationResult = null, object? registro = null)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Registro = registro,
                Errors = validationResult?.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }
        public static ResultService RequestError<T>(string message, ValidationResult? validationResult = null, object? registro = null)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Registro = registro,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService Fail(string message) => new() { IsSuccess = false, Message = message };
        public static ResultService<T> Fail<T>(string message) => new() { IsSuccess = false, Message = message };
        public static ResultService Ok(string message) => new() { IsSuccess = false, Message = message };
        public static ResultService<T> Ok<T>(T data) => new() { IsSuccess = false, Data = data };

    }
    public class ResultService<T> : ResultService
    {
        public T? Data { get; set; }
    }
}
