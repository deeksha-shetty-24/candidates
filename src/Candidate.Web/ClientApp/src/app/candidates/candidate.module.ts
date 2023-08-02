import { CommonModule } from "@angular/common";
import { CandidateRoutingModule } from "./candidate-routing.module";
import { CandidateComponent } from "./candidate.component";
import { CandidateFormComponent } from "./components/candidate-form/candidate-form.component";
import { SharedModule } from "../shared/shared.module";
import { NgModule } from "@angular/core";
import { StoreModule } from "@ngrx/store";
import { candidateReducer, STATE_NAME as CANDIDATE_STATE_NAME } from "./state/reducers/candidate.reducer";
import { EffectsModule } from "@ngrx/effects";
import { CandidateEffects } from "./state/effects/candidate.effects";

@NgModule({
    declarations: [CandidateFormComponent, CandidateComponent],
    imports: [
        CandidateRoutingModule,
        CommonModule,
        SharedModule,
        StoreModule.forFeature(CANDIDATE_STATE_NAME, candidateReducer),
        EffectsModule.forFeature([CandidateEffects])
    ]
})
export class CandidateModule { }