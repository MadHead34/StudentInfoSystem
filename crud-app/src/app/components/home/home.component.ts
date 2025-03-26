import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { StudentService } from '../../services/student.service';
import { CourseService } from '../../services/course.service';
import { SubjectService } from '../../services/subject.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule], // Import CommonModule for Tailwind and RouterModule for navigation
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  totalStudents = 0;
  totalCourses = 0;
  totalSubjects = 0;

  constructor(
    private studentService: StudentService,
    private courseService: CourseService,
    private subjectService: SubjectService
  ) {}

  ngOnInit(): void {
    this.fetchStats();
  }

  fetchStats(): void {
    this.studentService.getStudents().subscribe(data => this.totalStudents = data.length);
    this.courseService.getCourses().subscribe(data => this.totalCourses = data.length);
    this.subjectService.getSubjects().subscribe(data => this.totalSubjects = data.length);
  }
}