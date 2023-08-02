import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { loadCandidates } from "../actions/candidate.action";
import { State } from "../reducers/candidate.reducer";

@Injectable({ providedIn: "root" })
export class CandidateDispatcher {
    constructor(private _store: Store<State>) {}

    loadCandidates() {
        this._store.dispatch(loadCandidates());
    }
}