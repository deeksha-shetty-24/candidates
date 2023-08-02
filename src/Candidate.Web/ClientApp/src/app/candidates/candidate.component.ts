import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Candidate } from './models/candidate.model';
import { CandidateService } from './services/candidate.service';
import { CandidateDispatcher } from './state/dispatchers/candidate.dispatcher';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements OnInit {

  candidates: Candidate[] = [];
  displayedColumns: string[] = ['firstName', 'lastName', 'phoneNumber', 'email', 'address', 'experienceInYears', 'actions'];
  candidates$: Observable<Candidate[]>

  constructor(private candidateService: CandidateService,
    private router: Router,
    private _candidateDispatcher: CandidateDispatcher,) { }

  ngOnInit(): void {
    this.getCandidates();
    this._candidateDispatcher.loadCandidates();
    // this.candidates$ = 
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
