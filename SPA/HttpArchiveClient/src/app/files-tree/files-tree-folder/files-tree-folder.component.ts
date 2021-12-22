import { Component, Input, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { HarFileService } from 'src/app/services/har-file-upload.service';
import { HarFileModel } from 'src/app/shared/models/har-file.model';
import { FileModel, FolderModel } from 'src/app/shared/models/tree.models';

@Component({
  selector: 'app-files-tree-folder',
  templateUrl: './files-tree-folder.component.html',
  styleUrls: ['./files-tree-folder.component.sass']
})
export class FilesTreeFolderComponent implements OnInit {


  constructor(private service: HarFileService, private spinner: NgxSpinnerService) { }

  public isToggled: boolean = false;
  @Input() data: FolderModel;

  ngOnInit() {
  }

  public clickFolder() {
    this.isToggled = !this.isToggled;
  }

  loadFile(file: FileModel) {
    this.spinner.show();
    this.service.getHarFileById(file.id)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe((data: HarFileModel) => {
        this.service.emitFileDetailsLoaded(data);
      });
  }
}
