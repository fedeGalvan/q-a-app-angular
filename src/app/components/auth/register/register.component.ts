import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerFormGroup: FormGroup;

  constructor(private fb: FormBuilder) {
    this.registerFormGroup = this.fb.group(
      {
        username: ['', Validators.required],
        password: ['', [Validators.required, Validators.minLength(4)]],
        repeatedPassword: [''],
      },
      { validator: this.checkPassword }
    );
  }

  ngOnInit(): void {}

  register(): void {
    console.log(this.registerFormGroup);
  }
  
  checkPassword(group: FormGroup): any {
    const password = group.controls['password'].value;
    const repeatedPassword = group.controls['repeatedPassword'].value;

    return password === repeatedPassword ? null : { notSame: true };
  }
}
