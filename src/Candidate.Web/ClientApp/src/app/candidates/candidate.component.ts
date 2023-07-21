import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Candidate } from './models/candidate.model.';
import { CandidateService } from './services/candidate.service';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements OnInit {

  candidates: Candidate[] = [];
  displayedColumns: string[] = ['firstName', 'lastName', 'phoneNumber', 'email', 'address', 'experienceInYears', 'actions'];

  constructor(private candidateService: CandidateService, private router: Router) { }

  ngOnInit(): void {
    this.getCandidates();
  }

  getCandidates() {
    this.candidateService.getCandidates().subscribe(data => {
      this.candidates = data;
    });
  }

  editCandidate(candidate: Candidate) {
    this.router.navigate(['/candidate/edit', candidate.id]);
  }

  deleteCandidate(candidate: Candidate) {
    this.candidateService.deleteCandidate(candidate.id).subscribe(() => {
      this.getCandidates();
    });
  }

  onCreateCandidate() {
    this.router.navigate(['/candidate/create']);
  }
}
