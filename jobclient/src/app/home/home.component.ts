import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    sessionStorage.setItem('url', 'http://localhost:44398/api');
    localStorage.setItem('url', 'http://localhost:44398/api');
  }

}
