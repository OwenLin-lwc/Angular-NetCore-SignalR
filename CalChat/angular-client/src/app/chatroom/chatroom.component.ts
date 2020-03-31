import { Component, OnInit, NgZone } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { SignalRService } from '../services/signal-r.service';
import { Message } from '../models/message';

@Component({
  selector: 'app-chatroom',
  templateUrl: './chatroom.component.html',
  styleUrls: ['./chatroom.component.css']
})
export class ChatroomComponent implements OnInit {
  inputId = '1';
  inputMessage = '';
  uniqueID: string = new Date().getTime().toString();
  messages = new Array<Message>();
  message = new Message();

  constructor(public authService: AuthService, public signalRService: SignalRService, private _ngZone: NgZone) {
    this.subscribeToEvents();
  }

  ngOnInit(): void {
  }

  sendMessage(): void {
    if (this.inputMessage) {
      this.message = new Message();
      this.message.userId = this.authService.user.id;
      this.message.nickname = this.authService.user.nickname;
      this.message.department = this.authService.user.department;
      this.message.chatGroup = this.authService.user.chatGroup;
      this.message.message = this.inputMessage;
      this.message.sendDate = new Date();
      this.messages.push(this.message);
      this.signalRService.sendMessage(this.message);
      this.inputMessage = '';
    }
  }
  private subscribeToEvents(): void {

    this.signalRService.messageReceived.subscribe((message: Message) => {
      this._ngZone.run(() => {
        console.log(message.userId, this.authService.user.id);
        if (message.userId !== this.authService.user.id) {
          this.messages.push(message);
        }
      });
    });
  }

  login() {
    this.authService.login(this.inputId).subscribe(() => {
      if (this.authService.isLoggedIn) {
        this.signalRService.addToGroup(this.authService.user.chatGroup);
      }
    });
  }

  logout() {
    this.authService.logout();
    this.signalRService.removeFromGroup(this.authService.user.chatGroup);
  }

}
