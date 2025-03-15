import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StudentService } from '../../services/student.service';
import { Student } from '../../models/student.model';

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  templateUrl: './student-list.component.html',
})
export class StudentListComponent implements OnInit {
  students: Student[] = [];
  filteredStudents: Student[] = [];
  totalStudents = 0;
  selectedFilter = 'all';

  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
    this.fetchStudents();
  }

  fetchStudents(): void {
    this.studentService.getStudents().subscribe((data) => {
      this.students = data;
      this.filteredStudents = data;
      this.totalStudents = data.length;
    });
  }

  filterStudents(filter: string): void {
    this.selectedFilter = filter;
    if (filter === 'all') {
      this.filteredStudents = this.students;
    } else if (filter === 'no-subjects') {
      this.studentService.getStudentsWithoutSubjects().subscribe((data) => {
        this.filteredStudents = data;
      });
    }
  }
}