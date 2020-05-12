using System;
using System.Collections.Generic;

namespace CIBPhonebook.Dtos
{
    public class ValidationResponseDto
    {
        public List<ErrorDto> Errors { get; set; }
        public bool IsValid { get; set; }

    }
}
