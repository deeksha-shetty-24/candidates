import { exhaustMap, map } from "rxjs";
import { CandidateService } from "../../services/candidate.service";
import { loadCandidates, loadCandidatesComplete } from "../actions/candidate.action";
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Injectable } from "@angular/core";

@Injectable()
export class CandidateEffects {

    loadCandidates$ = createEffect(() => this.actions$.pipe(
        ofType(loadCandidates),
        exhaustMap(() => this.candidateService.getCandidates()
            .pipe(map(cand => loadCandidatesComplete({ candidates: cand }))))
    ))

    constructor(
        private actions$: Actions,
        private candidateService: CandidateService
    ) { }
}
