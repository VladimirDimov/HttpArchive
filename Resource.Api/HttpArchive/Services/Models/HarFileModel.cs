using AutoMapper;
using Data.DTO;
using Services.Config;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Services.Models
{
    public class HarFileModel : IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FilePath { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public object FileContent { get; set; }

        public string FileName { get; set; }

        public IEnumerable<string> SharedWith { get; set; } = new List<string>();

        public void CreateCustomMapping(Profile profile)
        {
            profile.CreateMap<HarFile, HarFileModel>()
                .ForMember(t => t.FileContent, o => o.MapFrom(s => JsonSerializer.Deserialize<object>(s.FileContent, null)));
        }
    }
}
