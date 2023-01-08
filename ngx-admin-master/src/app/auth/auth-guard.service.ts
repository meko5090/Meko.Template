import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { NbAuthService } from '@nebular/auth';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  constructor(private authService: NbAuthService, private router: Router) {
  }

  canActivate() {
    return this.authService.isAuthenticated().pipe(
      tap(authenticated => {
        if (!authenticated) {
          this.router.navigate(['auth/login']);
        }
      }),
    );
    // canActive can return Observable<boolean>, which is exactly what isAuthenticated returns
  }

  logout(){
    localStorage.removeItem('auth_app_token');
    this.router.navigate(['auth/login']);
  }
}
