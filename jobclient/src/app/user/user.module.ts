import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user.component';
import { UserLoginComponent } from './components/user-login/user-login.component';
import { UserRegistrationComponent } from './components/user-registration/user-registration.component';
import { ProfileComponent } from './components/profile/profile.component';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';


@NgModule({
  declarations: [UserComponent, UserLoginComponent, UserRegistrationComponent, ProfileComponent, EditProfileComponent, UserDashboardComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
  ReactiveFormsModule
  ],
  exports:[]
})
export class UserModule { }
