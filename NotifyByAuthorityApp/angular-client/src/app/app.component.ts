import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { SignalRService } from './services/signal-r.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  message: string;
  inputName = 'User1';
  inputMessage = '';

  constructor(public authService: AuthService, public signalRService: SignalRService) {
  }

  setMessage() {
    this.message = 'Logged ' +
      (this.authService.isLoggedIn ? 'in ' + this.authService.user.userName + ',' + this.authService.user.userGroup : 'out');
  }

  ngOnInit() {
    this.signalRService.startConnection();
  }

  login() {
    this.message = 'Trying to log in ...';

    this.authService.login(this.inputName).subscribe(() => {

      if (this.authService.isLoggedIn) {
        this.signalRService.addToGroup(this.authService.user.userGroup);
        this.signalRService.addGroupMessageListener();
      }
      this.setMessage();
    });
  }

  logout() {
    this.authService.logout();
    this.signalRService.removeFromGroup(this.authService.user.userGroup);
    this.setMessage();
  }
}
