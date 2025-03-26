import { Component, OnInit, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { initFlowbite } from 'flowbite';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  templateUrl: './course-list.component.html',
})
export class CourseListComponent implements OnInit, AfterViewInit {
  courses: Course[] = [];
  filteredCourses: Course[] = [];
  totalCourses = 0;
  coursesWithoutSubjectsCount = 0;
  selectedFilter = 'all';

  constructor(private courseService: CourseService) {}

  ngOnInit(): void {
    this.fetchCourses();
    this.fetchCoursesWithoutSubjectsCount();
  }

  ngAfterViewInit(): void {
    initFlowbite();
  }

  fetchCourses(): void {
    this.courseService.getCourses().subscribe((data) => {
      this.courses = data;
      this.filteredCourses = data;
      this.totalCourses = data.length;
    });
  }

  fetchCoursesWithoutSubjectsCount(): void {
    this.courseService.getCoursesWithoutSubjectsCount().subscribe((count) => {
    this.coursesWithoutSubjectsCount = count;
    });
  }

  filterCourses(filter: string): void {
    // this.selectedFilter = filter;
    if (filter === 'all') {
      this.filteredCourses = [...this.courses];
      this.totalCourses = this.courses.length;
    } else if (filter === 'no-subjects') {
      this.courseService.getCoursesWithoutSubjects().subscribe((data) => {
        this.filteredCourses = [...data];
        this.totalCourses = data.length;
      });
    }
    this.filteredCourses = this.filteredCourses.filter(course => course !== null)
  }
}