import { Routes } from '@angular/router';
// import { LoginComponent } from './pages/login/login.component';
// import { RegisterComponent } from './pages/register/register.component';
import { StudentListComponent } from './components/student-list/student-list.component';

export const routes: Routes = [{ path: '', redirectTo: '/students', pathMatch: 'full' },
    { path: 'students', component: StudentListComponent }];
