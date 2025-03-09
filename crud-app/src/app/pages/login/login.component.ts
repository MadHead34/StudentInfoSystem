import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; 

@Component({
  selector: 'app-login',
  standalone: true, 
  templateUrl: './login.component.html',
  imports: [FormsModule] 
})
export class LoginComponent {
  email: string = '';  
  password: string = '';
  errorMessage: string = '';

  login() {
    if (!this.email || !this.password) {
      this.errorMessage = 'Email and password are required.';
    } else {
      this.errorMessage = '';
      console.log('Logging in with:', this.email, this.password);
    }
  }
}