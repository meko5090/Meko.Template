import { AuthGuard } from "./../auth-guard.service";
import { Router } from "@angular/router";
import { Component, OnInit } from "@angular/core";
import { NbAuthService } from "@nebular/auth";

@Component({
  selector: "ngx-logout",
  template: "",
  styles: [],
})
export class LogoutComponent {
  constructor(private authGuard: AuthGuard, private router: Router) {
    this.authGuard.logout();
    this.router.navigate(["/"]);
  }
}
