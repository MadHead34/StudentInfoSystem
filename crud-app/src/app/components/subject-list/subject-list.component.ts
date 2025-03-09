import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-subjects',
  templateUrl: './subject-list.component.html',
})
export class SubjectsComponent implements OnInit {
  subjects: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchSubjects();
  }

  fetchSubjects(): void {
    this.http.get<any[]>('http://localhost:5000/api/subjects')
      .subscribe(data => {
        this.subjects = data;
      });
  }
}