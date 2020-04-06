import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { FooterComponent } from './components/footer/footer.component';


@NgModule({
  declarations: [HomeComponent, NavigationComponent, FooterComponent],
  imports: [
    CommonModule,
    HomeRoutingModule
  ],
  exports: [HomeComponent,NavigationComponent, FooterComponent],
})
export class HomeModule { }
