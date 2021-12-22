import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/core/authentication/auth.service';
import { HarFileService } from 'src/app/services/har-file-upload.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit, OnDestroy {
  isAuthenticated: boolean;
  subscription: Subscription;

  constructor(private authService: AuthService, public service: HarFileService) { }

  ngOnInit() {
    this.subscription = this.authService.authNavStatus$.subscribe(status => this.isAuthenticated = status);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
