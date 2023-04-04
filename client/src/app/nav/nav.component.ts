import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';

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
  isLoggedIn: boolean = false;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {

  }

  toggleNavbar() {
    this.isNavbarOpen = !this.isNavbarOpen;
  }

  // toggleDropdown() {
  //   this.isLogoutDropdownOpen = !this.isLogoutDropdownOpen;
  // }

  login() {
    console.log(this.model)
    this.accountService.login(this.model).subscribe({
      next: res => {
        console.log(res);
        this.isLoggedIn = true;
      },
      error: e => { console.log(e) }
    })
  }

  logout() {
    this.isLoggedIn = false;
  }

}

