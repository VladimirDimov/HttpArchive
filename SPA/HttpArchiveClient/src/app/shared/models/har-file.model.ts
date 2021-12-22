export class HarFileModel {
  id: string;
  fileName: string;
  filePath: string;
  createdOn: Date;
  fileContent: any;
  sharedWith: string[] = [];
  userId: string;
  isSharedFile: boolean;
};
