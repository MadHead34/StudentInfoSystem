import { Component, OnInit, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SubjectService } from '../../services/subject.service';
import { Subject } from '../../models/subject.model';
import { initFlowbite } from 'flowbite';

@Component({
  selector: 'app-subject-list',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  templateUrl: './subject-list.component.html',
})
export class SubjectListComponent implements OnInit, AfterViewInit {
  subjects: Subject[] = [];
  filteredSubjects: Subject[] = [];
  totalSubjects = 0;
  selectedFilter = 'all';

  constructor(private subjectService: SubjectService) {}

  ngOnInit(): void {
    this.fetchSubjects();
  }

  ngAfterViewInit(): void {
    initFlowbite();
  }

  fetchSubjects(): void {
    this.subjectService.getSubjects().subscribe((data) => {
      this.subjects = data;
      this.filteredSubjects = data;
      this.totalSubjects = data.length;
    });
  }


  filterSubjects(filter: string): void {
    if (filter === 'all') {
      this.filteredSubjects = [...this.subjects];
    } else if (filter === 'students') {
      this.subjectService.getSubjectwithStudents().subscribe((data) => {
        this.filteredSubjects = [...data];
        this.totalSubjects = data.length;
      });
    }
    this.filteredSubjects = this.filteredSubjects.filter(subject => subject !== null);
  }
}