import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent implements OnInit {
registerForm:FormGroup;
  submitted = false;
  registerUserData = {
    userName: '', email: '', password: '', confirmPassword: ''
  }
  constructor(public _auth: AuthService, private _router: Router, private _fb:FormBuilder) { 
    this.registerForm=this._fb.group({
      userName:['', Validators.required],
      email: ['', Validators.email],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    })
  }

  ngOnInit() {
  }
  get f() { return this.registerForm.controls; }
  registerUser() {
    if(this.registerForm.valid){
      console.log(this.registerForm.value)

      this._auth.registerUser(this.registerForm.value).subscribe(res => {
        this.registerUserData = res;
        console.log(this.registerForm.value)
        this._router.navigate(['/user/login'])
      },
        err => console.log(err)
      )
    }
  }
  registerEmployee() {
    this._auth.registerEmployee(this.registerForm.value).subscribe(res => {
      this.registerUserData = res;
      console.log(this.registerUserData)
      this._router.navigate(['/user/login'])
    },
      err => console.log(err)
    )
  }
}

