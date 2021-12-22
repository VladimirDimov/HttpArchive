import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HarFileService } from '../services/har-file-upload.service';
import { HarFileModel } from '../shared/models/har-file.model';

@Component({
  selector: 'app-har-file-details',
  templateUrl: './har-file-details.component.html',
  styleUrls: ['./har-file-details.component.scss']
})
export class HarFileDetailsComponent implements OnInit {

  constructor(private service: HarFileService, private fb: FormBuilder) { }

  public data: HarFileModel;
  public fileShareForm: FormGroup;

  ngOnInit() {
    this.service.onFileDetailsLoaded.subscribe((fileDetails: HarFileModel) => {
      this.data = fileDetails;

      this.fileShareForm = this.fb.group({
        id: this.fb.control(fileDetails.id),
        emails: this.fb.control(fileDetails.sharedWith.join(', '))
      });
      console.log(fileDetails);
    });
  }

  public share(): void {
    const requestData = this.fileShareForm.getRawValue();
    console.log(requestData);
    this.service.share(requestData).subscribe(_ => {
      this.service.emitFileShared();
    });
  }

}
