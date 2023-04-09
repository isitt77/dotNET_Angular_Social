import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  providers: [{
    provide: BsDropdownConfig, useValue:
      { isAnimated: true, autoClose: true }
  }]
})
export class NavComponent implements OnInit {
  title = 'The Dating App';
  isNavbarOpen: boolean = false;
  // isLogoutDropdownOpen: boolean = false
  model: any = {};
  // isLoggedIn: boolean = false;
  // currentUser$: Observable<User | null> = of(null);

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
    // this.currentUser$ = this.accountService.currentUser$;
  }

  toggleNavbar() {
    this.isNavbarOpen = !this.isNavbarOpen;
  }

  // toggleDropdown() {
  //   this.isLogoutDropdownOpen = !this.isLogoutDropdownOpen;
  // }

  // getCurrentUser() {
  //   this.accountService.currentUser$.subscribe({
  //     // checks if currentUser$ (observable) is logged in...
  //     next: user => this.isLoggedIn = !!user, // <-- !! converts non-bool into bool.
  //     error: e => console.log(e)
  //   })
  // }

  login() {
    console.log(this.model)
    this.accountService.login(this.model).subscribe({
      next: res => {
        console.log(res);
      },
      error: e => { console.log(e) }
    })
  }

  logout() {
    this.accountService.logout();
  }

}

