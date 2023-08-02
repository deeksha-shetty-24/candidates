import { createFeatureSelector, createSelector, select } from "@ngrx/store";
import { STATE_NAME, State } from "../reducers/candidate.reducer";

const getState = createFeatureSelector<State>(STATE_NAME);

export const loadCandidates = createSelector(
    getState,
    (state: State) => state.candidate
);
