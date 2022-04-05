import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerFormGroup: FormGroup;
  loading: boolean = false;
  userSuccessfullyCreated: boolean = false;
  userCreationFailed: boolean = false;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router
  ) {
    this.registerFormGroup = this.fb.group(
      {
        username: ['', Validators.required],
        password: ['', [Validators.required, Validators.minLength(4)]],
        repeatedPassword: ['', [Validators.required]],
      },
      { validator: this.checkPassword }
    );
  }

  ngOnInit(): void {}

  register(): void {
    this.loading = true;
    const user: User = {
      username: this.registerFormGroup.value.username,
      password: this.registerFormGroup.value.password,
    };

    this.userService.registrationHandler(user).subscribe(
      (data) => {
        this.userSuccessfullyCreated = true;
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 2000);
      },
      (error) => {
        this.loading = false;
        this.registerFormGroup.reset();
        this.userCreationFailed = true;
        setTimeout(() => {
          this.userCreationFailed = false;
        }, 3000);
      }
    );
    this.loading = false;
  }

  checkPassword(group: FormGroup): any {
    const password = group.controls['password'].value;
    const repeatedPassword = group.controls['repeatedPassword'].value;

    return password === repeatedPassword ? null : { notSame: true };
  }
}
