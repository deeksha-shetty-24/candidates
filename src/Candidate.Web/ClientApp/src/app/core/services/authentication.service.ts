import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from 'rxjs/operators';
import { AuthModel } from "../../login/models/auth.model";
import { LoginURLConstants } from "../../shared/constants/url-constants";
import { BehaviorSubject, Observable } from "rxjs";
import { Router } from "@angular/router";

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    currentUserSubject: BehaviorSubject<AuthModel>;

    constructor(private http: HttpClient, private router: Router) {
        const userJson = localStorage.getItem('currentUser');
        const currentUser = userJson !== null ? JSON.parse(userJson) : null;
        this.currentUserSubject = new BehaviorSubject<AuthModel>(currentUser);
    }

    login(username: string, password: string) {
        return this.http.post<AuthModel>(LoginURLConstants.LOGIN, { username, password })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
                return user;
            }));
    }

    setUserContext(user: AuthModel) {
        this.currentUserSubject.next(user);
    }

    public get currentUserValue(): AuthModel {
        return this.currentUserSubject.value;
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(new AuthModel());
        this.router.navigate(['/login'])
    }
}