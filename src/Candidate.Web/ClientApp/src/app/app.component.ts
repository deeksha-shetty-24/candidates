import { Component } from '@angular/core';
import { AuthenticationService } from './core/services/authentication.service';
import { AuthModel } from './login/models/auth.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'candidates';
  currentUser: AuthModel;
  
  constructor(private authenticationService: AuthenticationService) {
    this.authenticationService.currentUserSubject.subscribe(
      (x) => (
        this.currentUser = x
      )
    );
  }
}
