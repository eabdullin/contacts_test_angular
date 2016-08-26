using System.Collections.Generic;

namespace BLL
{
    /// <summary>Represents the result of an identity operation</summary>
    public class Result
    {
        private static readonly Result _success = new Result(true);

        public bool Succeeded { get; private set; }


        public IEnumerable<string> Errors { get; private set; }


        public static Result Success
        {
            get
            {
                return Result._success;
            }
        }

        public Result(params string[] errors)
          : this((IEnumerable<string>)errors)
        {
        }

        public Result(IEnumerable<string> errors)
        {
            if (errors == null)
                errors = (IEnumerable<string>)new string[1]
                {"Unspecified error"
                };
            this.Succeeded = false;
            this.Errors = errors;
        }


        protected Result(bool success)
        {
            this.Succeeded = success;
            this.Errors = (IEnumerable<string>)new string[0];
        }

        /// <summary>Failed helper method</summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static Result Failed(params string[] errors)
        {
            return new Result(errors);
        }
    }

    public class Result<T> : Result
    {
        public Result(T data)
        {
            Data = data;
        }

        public T Data { get; private set; }
        public static Result<T> Success(T obj)
        {
            return new Result<T>(obj);
        }
    }
}