import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthService } from 'src/app/auth/services/auth.service';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  loginUserData = { userName: '', password: '', }
  isLoginError: boolean;
  loginForm:FormGroup;

  constructor(private _auth: AuthService, private _router: Router, private _fb:FormBuilder) { 
    this.loginForm=this._fb.group({
      userName:['', Validators.required],
      password: ['', Validators.required],
    })
  }
   get f() { return this.loginForm.controls; }

  ngOnInit() {
  }
  OnSubmit(userName: string, password: string) {
    this._auth.loginUser(userName, password).subscribe((data: any) => {
      console.log("lksf")
      localStorage.setItem('token', data.access_token);
      this._router.navigate(['/user/profile']);
    },
      (err: HttpErrorResponse) => {
        alert("Input ")
        this.isLoginError = true;
      });
  }

}