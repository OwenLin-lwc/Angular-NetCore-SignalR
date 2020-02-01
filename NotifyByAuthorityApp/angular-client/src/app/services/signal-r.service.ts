import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;
  messageHistory: any[] = [];

  constructor(private messageService: MessageService) {}

  public startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/notify')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public addToGroup(groupName: string) {
    this.hubConnection
      .invoke('addtogroup', groupName)
      .catch(err => console.error(err));
  }

  public removeFromGroup(groupName: string) {
    this.hubConnection
      .invoke('removefromgroup', groupName)
      .catch(err => console.error(err));
  }

  public addGroupMessageListener() {
    this.hubConnection.on('notifymessage', (type: string, payload: string) => {
      const displayMsg = { severity: type, summary: payload, detail: 'Via SignalR' };
      this.messageService.addAll([displayMsg]);
      this.messageHistory.push(displayMsg);
    });
  }
}
