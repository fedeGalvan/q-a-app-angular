import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../../../models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginFormGroup: FormGroup;
  loading: boolean = false;
  constructor(private fb: FormBuilder, private router: Router) {
    this.loginFormGroup = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {}


  login(): void {
    const user: User = {
      username: this.loginFormGroup.value.username,
      password: this.loginFormGroup.value.password,
    };

    // if(user.isValid()){
    //   this.router.navigate(["/dashboard"]);
    // }else{
    //   this.showError();
    // this.loginFormGroup.reset();
    // }
  }
}
