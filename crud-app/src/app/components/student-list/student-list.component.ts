import { Component, OnInit, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StudentService } from '../../services/student.service';
import { Student } from '../../models/student.model';
import { initFlowbite } from 'flowbite';
import { CardComponent } from '../card/card.component';
import { TableComponent } from "../table/table.component";

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [CommonModule, FormsModule, CardComponent, TableComponent], 
  templateUrl: './student-list.component.html',
})
export class StudentListComponent implements OnInit, AfterViewInit {
  students: Student[] = [];
  filteredStudents: Student[] = [];
  totalStudents = 0;
  studentsWithoutCoursesCount = 0;
  selectedFilter = 'all';

  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
    this.fetchStudents();
    this.fetchStudentsWithoutCoursesCount();
  }

  ngAfterViewInit(): void {
    initFlowbite();
  }

  fetchStudents(): void {
    this.studentService.getStudents().subscribe((data) => {
      this.students = data;
      this.filteredStudents = data;
      this.totalStudents = data.length;
    });
  }

  fetchStudentsWithoutCoursesCount(): void {
    this.studentService.getStudentsWithoutCoursesCount().subscribe((count) => {
      this.studentsWithoutCoursesCount = count;
    });
  }

  filterStudents(filter: string): void {
    console.log('Selected filter:', filter); // Debugging log

    if (filter === 'all') {
      this.filteredStudents = [...this.students]; // Ensure a new reference
      this.totalStudents = this.students.length;
      console.log('All students:', this.filteredStudents.length);
    } else if (filter === 'no-course') {
      this.studentService.getStudentsWithoutCourses().subscribe((data) => {
        console.log('Filtered students:', data.length);
        this.filteredStudents = [...data];
        this.totalStudents = data.length;
      });
    }
    this.filteredStudents = this.filteredStudents.filter(student => student !== null);
  }
}