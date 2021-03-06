import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from 'src/app/auth/services/auth.service';
import { Observable } from 'rxjs';
import { Personaldetail } from '../models/user.model';
import { TokenInterceptorService } from 'src/app/auth/services/token-interceptor.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient, private authService: AuthService, private token: TokenInterceptorService) { }

  public getPersonalInfo() {
    return this.http.get<Observable<Array<Personaldetail>>>(this.rootURl + 
      '/PersonalDetail/GetPersonalDetailList', { headers: new HttpHeaders({ 'Authorization': 'Bearer' + this.authService.getToken() }) });
  }
  public getById(id: number): Observable<Personaldetail> {
    return this.http.get<Personaldetail>(this.rootURl + '/PersonalDetail/getbyId/' + id);
  }
  public update(model: Personaldetail): Observable<Personaldetail> {
    console.log(model);
    return this.http.put<Personaldetail>(this.rootURl + '/PersonalDetail/update', model)
  }
  public add(model: Personaldetail): Observable<Personaldetail> {
    console.log(model);
    return this.http.post<Personaldetail>(this.rootURl + '/PersonalDetail/post', model)
  }
  public addUpdate(model: any): Observable<any> {
    return this.http.put<any>(this.rootURl + '/PersonalDetail/addressUpdate', model)
  }
}
