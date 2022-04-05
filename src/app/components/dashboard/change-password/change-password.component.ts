import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss'],
})
export class ChangePasswordComponent implements OnInit {
  changePassword: FormGroup;

  constructor(private fb: FormBuilder) {
    this.changePassword = this.fb.group(
      {
        prevPassword: ['', Validators.required],
        newPassword: ['', [Validators.required, Validators.minLength(4)]],
        confirmPassword: ['', Validators.required],
      },
      { validator: this.checkPassword }
    );
  }

  ngOnInit(): void {}

  checkPassword(group: FormGroup): any {
    const newPassword = group.controls['newPassword'].value;
    const confirmPassword = group.controls['confirmPassword'].value;

    return newPassword === confirmPassword ? null : { notSame: true };
  }

  savePassword(): void {
    
  }
}
