using AutoMapper;
using Data.DTO;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;
using Services.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HarFileService : IHarFileService
    {
        private readonly IHarFileRepository harFileRepository;
        private readonly IMapper mapper;

        public HarFileService(IHarFileRepository harFileRepository, IMapper mapper)
        {
            this.harFileRepository = harFileRepository;
            this.mapper = mapper;
        }

        public async Task UploadAsync(HarFileUploadModel form, string userId)
        {
            var harFileDto = new HarFile();
            harFileDto.UserId = userId;
            harFileDto.FilePath = form.FilePath;
            var fileContent = await ReadAsStringAsync(form.FileContent);
            harFileDto.FileContent = fileContent;
            harFileDto.FileName = form.FileContent.FileName;

            await harFileRepository.CreateAsync(harFileDto);
        }

        public async Task<FolderModel> GetByUserIdAsync([NotNull] string userId)
        {
            var harFiles = await harFileRepository.ByUserIdAsync(userId);
            var harFilesModels = harFiles
                .Select(f => mapper.Map<HarFileTreeModel>(f));

            var root = new FolderModel { Name = "Root" };

            foreach (var harFile in harFilesModels)
            {
                AppendFile(harFile, harFile.FilePath?.Split('/'), root);
            }

            return root;
        }

        public async Task<HarFileModel> GetByFileIdAsync([NotNull] string fileId, [NotNull] string userId, [NotNull] string email)
        {
            var harFile = await harFileRepository.ByIdAsync(fileId);

            if (harFile == null)
                throw new ArgumentException($"Invalid harFileId = {fileId}.");

            if (!UserHasAccessToFile(userId, email, harFile))
                throw new ArgumentException($"User don't have access to required resource.");

            return mapper.Map<HarFileModel>(harFile);
        }

        public async Task ShareAsync(FileShareModel form, string userId)
        {
            var harFile = await harFileRepository.ByIdAsync(form.Id);
            harFile.SharedWith = form.Emails?
                .Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.Trim());

            await harFileRepository.UpdateAsync(harFile);
        }

        public async Task<FolderModel> GetSharedWithMe(string userEmail)
        {
            var sharedFiles = (await harFileRepository.SharedFiles(userEmail));
            var harFilesModels = sharedFiles
                .Select(f => mapper.Map<HarFileTreeModel>(f))
                .ToList();

            var sharedFolder = new FolderModel { Name = "Shared", Files = harFilesModels };

            return sharedFolder;
        }

        private static bool UserHasAccessToFile(string userId, string email, HarFile harFile)
        {
            return harFile.UserId == userId || harFile.SharedWith.Any(u => u?.ToLower() == email.ToLower());
        }

        private void AppendFile(HarFileTreeModel harFile, string[] folders, FolderModel root)
        {
            if (folders is null || !folders.Any())
            {
                root.Files.Add(harFile);

                return;
            }

            var firstPath = folders.First();

            var existingFolder = root.Folders.FirstOrDefault(f => f.Name?.ToLower() == firstPath.ToLower());

            if (existingFolder is null)
            {
                var newFolder = new FolderModel { Name = firstPath };
                root.Folders.Add(newFolder);
                AppendFile(harFile, folders.Skip(1).ToArray(), newFolder);
            }
            else
            {
                AppendFile(harFile, folders.Skip(1).ToArray(), existingFolder);
            }
        }

        private async Task<string> ReadAsStringAsync(IFormFile file)
        {
            var result = new StringBuilder();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }

            return result.ToString();
        }
    }
}
