import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-courses',
  templateUrl: './course-list.component.html',
})
export class CoursesComponent implements OnInit {
  courses: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchCourses();
  }

  fetchCourses(): void {
    this.http.get<any[]>('http://localhost:5000/api/courses')
      .subscribe(data => {
        this.courses = data;
      });
  }
}