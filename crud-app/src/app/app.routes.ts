import { Routes } from '@angular/router';
import { StudentListComponent } from './components/student-list/student-list.component';
import { HomeComponent } from './components/home/home.component';
import { CourseListComponent } from './components/course-list/course-list.component';
import { SubjectListComponent } from './components/subject-list/subject-list.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guard/auth.guard';

export const routes: Routes = [{ path: 'login', component: LoginComponent },
    { path: '', component: HomeComponent, canActivate: [AuthGuard]}, 
    { path: 'students', component: StudentListComponent, canActivate: [AuthGuard]},
    { path: 'courses', component: CourseListComponent, canActivate: [AuthGuard] },
    { path: 'subjects', component: SubjectListComponent, canActivate: [AuthGuard] }];
