import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = false;
  user: User;

  constructor(private http: HttpClient) { }

  login(userName: string): Observable<User> {
    const headOption = { headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' }) };
    const httpParams = new HttpParams().set('userName', userName);
    return this.http.post<User>('https://localhost:5001/api/Auth/Login', httpParams, headOption)
      .pipe(tap(val => {
        this.user = val;
        this.isLoggedIn = !!val ? true : false;
      }));
  }

  logout(): void {
    this.isLoggedIn = false;
  }
}
