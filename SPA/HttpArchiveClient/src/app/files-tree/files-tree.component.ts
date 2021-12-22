import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { Observable } from 'rxjs';
import { HarFileService } from '../services/har-file-upload.service';
import { FolderModel } from '../shared/models/tree.models';

@Component({
  selector: 'app-files-tree',
  templateUrl: './files-tree.component.html',
  styleUrls: ['./files-tree.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class FilesTreeComponent implements OnInit {

  data: FolderModel = new FolderModel();

  constructor(private service: HarFileService) { }

  @Input() $data: Observable<FolderModel>;
  @Input() $refreshOn: Observable<FolderModel>;
  @Input() title: string;

  ngOnInit() {
    this.fetchData();
    this.$refreshOn.subscribe(_ => this.fetchData());
  }

  fetchData() {
    this.$data.subscribe((data: FolderModel) => {
      this.data = data;
      console.log(data);
    });
  }
}
