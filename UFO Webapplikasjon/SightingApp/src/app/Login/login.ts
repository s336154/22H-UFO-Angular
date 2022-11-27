import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: "app-root",
  templateUrl: "app.component.html"
})
export class AppComponent {

  LoginForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.LoginForm = fb.group({
      username: ["", Validators.required],
      password: ["", Validators.pattern("[0-9]{6,15}")]
    });
  }

  onSubmit() {
    console.log("User logged in successfully:");
    console.log(this.LoginForm);
    console.log(this.LoginForm.value.username);
    console.log(this.LoginForm.touched);
  }
}

