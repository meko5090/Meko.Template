import { Component, OnInit } from '@angular/core';
import {  NbAuthService } from '@nebular/auth';

@Component({
  selector: 'ngx-logout',
  templateUrl: './logout.component.html',
  styles: [
  ]
})

export class LogoutComponent  implements OnInit{
  constructor(private authService:NbAuthService) {
    this.logout('email');
  }
  ngOnInit(): void {

  }


  logout(strategy: string): void {
   this.authService.logout(strategy);
  console.log('token ?', this.authService.getToken());
  }
  }
