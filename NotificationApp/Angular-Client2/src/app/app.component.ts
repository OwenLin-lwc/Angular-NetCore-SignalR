import { Component, OnInit } from '@angular/core';

import { MessageService } from 'primeng/api';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [MessageService]
})
export class AppComponent implements OnInit {
  messageHistory: any[] = [];

  constructor(private messageService: MessageService) { }

  ngOnInit() {
    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl('http://localhost:5000/notify')
      .build();

    connection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));

    connection.on('BroadcastMessage', (type: string, payload: string) => {
      const displayMsg = { severity: type, summary: payload, detail: 'Via SignalR' };
      this.messageService.add(displayMsg);
      this.messageHistory.push(displayMsg);
    });
  }
}
