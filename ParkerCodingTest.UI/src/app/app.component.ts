import { Component } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent {
  title = "ParkerCodingTestUI";
  registerForm: FormGroup;
  submitted: boolean = false;
  constructor(private formBuilder: FormBuilder, private http: HttpClient) {}
  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      firstName: ["", [Validators.required]],
      lastName: ["", [Validators.required]],
      email: ["", [Validators.required]],
      password: ["", [Validators.required]],
      confirmPassword: ["", [Validators.required]],
      securityQuestion: ["", [Validators.required]],
      securityAnswer: ["", [Validators.required]],
      phone: ["", [Validators.required]],
      gender: ["Male", [Validators.required]],
    });
  }

  get f() {
    return this.registerForm.controls;
  }

  Save() {
    this.submitted = true;
    if (!this.registerForm.valid) return;
    let API_URL = "http://localhost:5000/employee";
    this.http.post(API_URL, this.registerForm.value).subscribe(
      (data) => {
        this.registerForm.reset();
        this.submitted = false;
        alert("Data Saved Successfully");
      },
      (error) => {
        alert("Error saving data. Please try again.");
      }
    );
  }
}
