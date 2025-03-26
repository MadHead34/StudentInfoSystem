import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private apiUrl = 'http://localhost:5163/api/students'; 

  constructor(private http: HttpClient) {}

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(this.apiUrl);
  }

  getStudentsWithoutCourses(): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.apiUrl}/no-course`);
  }

  getStudentsWithoutCoursesCount(): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}/count-no-course`);
  }
}