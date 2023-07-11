import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Candidate } from '../models/candidate';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {
  private baseUrl = 'http://localhost:3000/candidates';

  constructor(private http: HttpClient) {}

  createCandidate(candidate: Candidate) {
    return this.http.post(this.baseUrl, candidate);
  }

  getCandidates() {
    return this.http.get<Candidate[]>(this.baseUrl);
  }

  getCandidateById(id: string) {
    return this.http.get<Candidate>(`${this.baseUrl}/${id}`);
  }

  updateCandidate(id: string, candidate: Candidate) {
    return this.http.put(`${this.baseUrl}/${id}`, candidate);
  }

  deleteCandidate(id: string) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}