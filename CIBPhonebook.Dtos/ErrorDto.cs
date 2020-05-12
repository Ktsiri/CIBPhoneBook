using System;
namespace CIBPhonebook.Dtos
{
    public class ErrorDto
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }
}
