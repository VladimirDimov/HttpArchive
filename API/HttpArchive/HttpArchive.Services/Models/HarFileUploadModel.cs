using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Services.Models
{
    public class HarFileUploadModel
    {
        public string FilePath { get; set; }

        public IFormFile FileContent { get; set; }

        public class HarFileUploadModelValidator : AbstractValidator<HarFileUploadModel>
        {
            private const string MAX_FILE_SIZE_IN_MB = "The .har file size can't exceed 10 MB.";

            public HarFileUploadModelValidator()
            {
                RuleFor(x => x.FileContent)
                    .Must(fc => fc.Length / 1024 / 1024 < 10)
                    .WithMessage(x => MAX_FILE_SIZE_IN_MB);
            }
        }
    }
}
