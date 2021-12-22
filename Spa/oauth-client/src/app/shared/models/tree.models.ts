export class FolderModel {
  name: string;
  folders: FolderModel[] = [];
  files: FileModel[] = [];
};

export class FileModel {
  id: string;
  fileName: string;
}
