import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HarFileService } from '../services/har-file-upload.service';

@Component({
  selector: 'app-har-file-upload',
  templateUrl: './har-file-upload.component.html',
  styleUrls: ['./har-file-upload.component.sass']
})
export class HarFileUploadComponent implements OnInit {
  fileUploadForm: FormGroup;

  constructor(private fb: FormBuilder, private harFileService: HarFileService) { }

  ngOnInit() {
    this.fileUploadForm = this.fb.group({
      path: this.fb.control('', [Validators.maxLength(200)]),
      fileContent: this.fb.control(null, [Validators.required]),
      fileSource: this.fb.control(null, [Validators.required]),
    });
  }

  public onFileChange(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.fileUploadForm.patchValue({
        fileSource: file
      });
    }
  }

  public submit() {
    const formData = new FormData();
    formData.append('fileContent', this.fileUploadForm.get('fileSource').value);
    formData.append('filePath', this.fileUploadForm.get('path').value);
    console.log(formData);
    this.harFileService.upload(formData).subscribe(_response => {
      this.harFileService.emitFileUploaded();
    });
  }
}
