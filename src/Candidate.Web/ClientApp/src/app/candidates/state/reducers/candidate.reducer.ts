import { Candidate } from '../../models/candidate.model';
import { createReducer, on, } from '@ngrx/store';
import { loadCandidatesComplete } from '../actions/candidate.action';

export interface State {
    candidate: Candidate[] // Pass the entity type, on this case Entity[]
}
export const STATE_NAME = "candidate";
const initialState: State = { candidate: [] }


export const candidateReducer = createReducer(
    initialState,
    on(loadCandidatesComplete, (state, { candidates }) => ({
        ...state,
        candidate: candidates
    }))
)
