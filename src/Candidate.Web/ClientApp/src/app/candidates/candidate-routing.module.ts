import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateComponent } from './candidate.component';
import { CandidateFormComponent } from './components/candidate-form/candidate-form.component';

const routes: Routes = [
    {
        path: '',
        component: CandidateComponent,
    },
    {
        path: 'create',
        component: CandidateFormComponent
    },
    {
        path: 'edit/:id',
        component: CandidateFormComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CandidateRoutingModule { }