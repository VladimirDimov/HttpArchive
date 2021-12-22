import { Component, Input, OnInit } from '@angular/core';
import { HarFileService } from 'src/app/services/har-file-upload.service';
import { HarFileModel } from 'src/app/shared/models/har-file.model';
import { FileModel, FolderModel } from 'src/app/shared/models/tree.models';

@Component({
  selector: 'app-files-tree-folder',
  templateUrl: './files-tree-folder.component.html',
  styleUrls: ['./files-tree-folder.component.sass']
})
export class FilesTreeFolderComponent implements OnInit {


  constructor(private service: HarFileService) { }

  public isToggled: boolean = false;
  @Input() data: FolderModel;

  ngOnInit() {
  }

  public clickFolder() {
    this.isToggled = !this.isToggled;
  }

  loadFile(file: FileModel) {
    this.service.getHarFileById(file.id).subscribe((data: HarFileModel) => {
      this.service.emitFileDetailsLoaded(data);
    });
  }
}
