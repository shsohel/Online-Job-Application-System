import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Router } from '@angular/router'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  rootURl = localStorage.getItem('url');
  //public _loginUrl = "http://localhost:51654/api/token";

  constructor(private http: HttpClient, private _router: Router) { }

  registerUser(user) {
    console.log("Register Method");
    return this.http.post<any>(this.rootURl + "/Account/Register", user)
  }

  registerEmployee(user) {
    console.log("Register Employee Method");
    return this.http.post<any>(this.rootURl + "/Account/EmployeerRegister", user)
  }

  loginUser(userName: string, password: string) {
    console.log("Login Method")
    var data = "grant_type=password&userName=" + userName + "&password=" + password;
    console.log("ls")
    var reqHeader = new HttpHeaders({ 'content-Type': 'x-www-form-urlencoded' });
    return this.http.post<Observable<any>>(this.rootURl + '/token', data, { headers: reqHeader });
  }

  logoutUser() {
    localStorage.removeItem('token')
    this._router.navigate(['/user/login'])
  }

  getToken() {
    return localStorage.getItem('token')
  }

  loggedIn() {
    return !!localStorage.getItem('token')
  }
}
