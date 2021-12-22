using Data.DTO;
using Services.Config;
using System;

namespace Services.Models
{
    public class HarFileTreeModel : IMapFrom<HarFile>
    {
        public string Id { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }
    }
}
