import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private apiUrl = 'http://localhost:5163/api/courses';

  constructor(private http: HttpClient) {}

  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(this.apiUrl);
  }

  getCoursesWithoutSubjects(): Observable<Course[]> {
    return this.http.get<Course[]>(`${this.apiUrl}/no-subjects`);
  }

  getCoursesWithoutSubjectsCount(): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}/count-no-subjects`);
  }
}