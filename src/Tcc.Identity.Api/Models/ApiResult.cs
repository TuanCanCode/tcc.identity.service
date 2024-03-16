namespace Tcc.Identity.Api.Models
{
    /// <summary>
    /// ApiResult
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        private ApiResult(bool succeeded, T? result, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Result = result;
            Errors = errors;
        }

        /// <summary>
        /// Succeeded
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// Errors
        /// </summary>
        public IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ApiResult<T> Success(T result)
        {
            return new ApiResult<T>(true, result, new List<string>());
        }

        /// <summary>
        /// Failure
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static ApiResult<T> Failure(IEnumerable<string> errors)
        {
            return new ApiResult<T>(false, default, errors);
        }
    }

}
