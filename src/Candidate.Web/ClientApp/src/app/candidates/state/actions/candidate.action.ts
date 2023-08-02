import { createAction, props } from '@ngrx/store';
import { Candidate } from '../../models/candidate.model';

export const loadCandidates = createAction('LOAD ALL CANDIDATES');
export const loadCandidatesComplete = createAction('LOAD ALL CANDIDATES COMPLETE', props<{ candidates: Candidate[] }>());
export const getCandidateById = createAction('GET CANDIDATE', props<{ candidateId: number }>());
