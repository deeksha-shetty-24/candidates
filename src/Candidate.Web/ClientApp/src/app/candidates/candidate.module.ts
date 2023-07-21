import { CommonModule } from "@angular/common";
import { CandidateRoutingModule } from "./candidate-routing.module";
import { CandidateComponent } from "./candidate.component";
import { CandidateFormComponent } from "./components/candidate-form/candidate-form.component";
import { SharedModule } from "../shared/shared.module";
import { NgModule } from "@angular/core";

@NgModule({
    declarations: [CandidateFormComponent, CandidateComponent],
    imports: [
        CandidateRoutingModule,
        CommonModule,
        SharedModule
    ]
})
export class CandidateModule { }