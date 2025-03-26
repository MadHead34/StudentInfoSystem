import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: true,
  imports: [FormsModule]
})
export class LoginComponent {
  username = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) { }

  login() {
    this.authService.login(this.username, this.password).subscribe(
      (response: any) => {
        this.authService.saveToken(response.token);
        alert('Login successful');
        this.router.navigate(['/']);
      },
      (error) => {
        alert('Invalid username or password');
      }
    );
  }
}