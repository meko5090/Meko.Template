import { AuthGuard } from './../../../auth/auth-guard.service';
import { Component, OnDestroy, OnInit } from "@angular/core";
import {
  NbLayoutDirection,
  NbLayoutDirectionService,
  NbMediaBreakpointsService,
  NbMenuService,
  NbSidebarService,
  NbThemeService,
} from "@nebular/theme";

import { UserData } from "../../../@core/data/users";
import { LayoutService } from "../../../@core/utils";
import { filter, map, takeUntil } from "rxjs/operators";
import { Subject } from "rxjs";
import { NbAuthJWTToken, NbAuthService } from "@nebular/auth";

@Component({
  selector: "ngx-header",
  styleUrls: ["./header.component.scss"],
  templateUrl: "./header.component.html",
})
export class HeaderComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();
  userPictureOnly: boolean = false;
  user: any;

  themes = [
    {
      value: "default",
      name: "Light",
    },
    {
      value: "dark",
      name: "Dark",
    },
    {
      value: "cosmic",
      name: "Cosmic",
    },
    {
      value: "corporate",
      name: "Corporate",
    },
  ];

  layouts = [
    {
      value: "LTR",
      name: "LTR",
    },
    {
      value: "RTL",
      name: "RTL",
    },
  ];
  currentTheme = "default";
  currentLayout = "RTL";

  userMenu = [{ title: "Profile" }, { title: "Log out" }];
  tag = 'user_menu';


onMenuItemClick() { this.menuService.onItemClick() .pipe(filter(({ tag }) => tag === this.tag)) .subscribe(bag => console.log(bag)); }
  constructor(
    private sidebarService: NbSidebarService,
    private menuService: NbMenuService,
    private themeService: NbThemeService,
    private userService: UserData,
    private layoutService: LayoutService,
    private layoutDirectionService: NbLayoutDirectionService,
    private authService: NbAuthService,
    private breakpointService: NbMediaBreakpointsService,
    private authGuard : AuthGuard
  ) {
    menuService.onItemClick()
    .pipe(filter(({ tag }) => tag === this.tag))
    .subscribe(bag => this.authGuard.logout());

    this.authService.onTokenChange().subscribe((token: NbAuthJWTToken) => {
      if (token.isValid()) {
        this.user = token.getPayload(); // here we receive a payload from the token and assigns it to our `user` variable
        console.log("User >>>", this.user);
        console.log("User >>>", token);
      }
    });
  }

  ngOnInit() {
    this.currentTheme = this.themeService.currentTheme;
    console.log(">>>>>>>>>", this.layoutDirectionService.getDirection());
    this.currentLayout = this.layoutDirectionService
      .getDirection()
      .toUpperCase()
      .toString();

    this.userService
      .getUsers()
      .pipe(takeUntil(this.destroy$))
      .subscribe((users: any) => (this.user = users.nick));

    const { xl } = this.breakpointService.getBreakpointsMap();
    this.themeService
      .onMediaQueryChange()
      .pipe(
        map(([, currentBreakpoint]) => currentBreakpoint.width < xl),
        takeUntil(this.destroy$)
      )
      .subscribe(
        (isLessThanXl: boolean) => (this.userPictureOnly = isLessThanXl)
      );

    this.themeService
      .onThemeChange()
      .pipe(
        map(({ name }) => name),
        takeUntil(this.destroy$)
      )
      .subscribe((themeName) => (this.currentTheme = themeName));
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  changeTheme(themeName: string) {
    this.themeService.changeTheme(themeName);
  }
  changeLayout(layout: string) {
    if (layout == "RTL") {
      this.layoutDirectionService.setDirection(NbLayoutDirection.RTL);
      //this.sidebarService.(NbLayoutDirection.RTL);
    } else {
      this.layoutDirectionService.setDirection(NbLayoutDirection.LTR);
    }
  }

  toggleSidebar(): boolean {
    this.sidebarService.toggle(true, "menu-sidebar");
    this.layoutService.changeLayoutSize();

    return false;
  }

  navigateHome() {
    this.menuService.navigateHome();
    return false;
  }
}
