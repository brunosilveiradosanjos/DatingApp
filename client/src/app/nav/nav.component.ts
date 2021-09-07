import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  model: any = {};
  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    // console.log(this.model);
    this.accountService.login(this.model).subscribe(response => {
      // console.log(response);
      this.router.navigateByUrl('/members');
    }, error => {
      console.log(error);
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  getCurrentUser() {
    this.accountService.currentUser$.subscribe(user => {
    }, error => {
      console.log('getCurrentUser ', error);
    })
  }
}
