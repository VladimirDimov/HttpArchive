using System.Collections.Generic;

namespace Services.Models
{
    public class FolderModel
    {
        public string Name { get; set; }

        public List<FolderModel> Folders { get; set; } = new List<FolderModel> { };

        public List<HarFileTreeModel> Files { get; set; } = new List<HarFileTreeModel> { };
    }
}
