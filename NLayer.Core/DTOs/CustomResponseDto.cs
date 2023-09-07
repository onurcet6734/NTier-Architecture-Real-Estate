using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<TEntity>
    {
        public TEntity Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }


        public List<String> Errors { get; set; }


        public static CustomResponseDto<TEntity> Success(int statusCode, TEntity data)
        {
            return new CustomResponseDto<TEntity> { Data = data, StatusCode = statusCode };
        }
        public static CustomResponseDto<TEntity> Success(int statusCode)
        {
            return new CustomResponseDto<TEntity> { StatusCode = statusCode };
        }

        public static CustomResponseDto<TEntity> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<TEntity> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDto<TEntity> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<TEntity> { StatusCode = statusCode, Errors = new List<string> { error } };
        }

    }
}