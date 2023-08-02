import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Candidate } from '../models/candidate.model';
import { CandidateURLConstants } from '../../shared/constants/url-constants';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor(private http: HttpClient) { }

  createCandidate(candidate: Candidate, formData: FormData) {
    formData.append('candidate', JSON.stringify(candidate));
    return this.http.post(CandidateURLConstants.SAVE_APPLICANT, formData);
  }

  getCandidates() {
    return this.http.get<Candidate[]>(CandidateURLConstants.GET_ALL_APPLICANTS);
  }

  getCandidateById(applicantId: string) {
    return this.http.get<Candidate>(`${CandidateURLConstants.GET_APPLICANT_BY_ID}/${applicantId}`);
  }

  deleteCandidate(id: number) {
    return this.http.delete(`${CandidateURLConstants.DELETE_APPLICANT}/${id}`);
  }

  downloadCandidate(id: number) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/pdf', 'Accept': 'application/pdf' });
    return this.http.post(`${CandidateURLConstants.DOWNLOAD_APPLICANT}/${id}`, {}, { headers: headers, responseType: 'blob', });
  }
}