import { environment } from "../../../environments/environment";

const apiUrl = environment.apiUrl;

export class LoginURLConstants {
    static LOGIN = apiUrl + "/api/user";
}

export class CandidateURLConstants {
    static GET_ALL_APPLICANTS = apiUrl + "/api/applicant/GetAllApplicants";
    static SAVE_APPLICANT = apiUrl + "/api/applicant";
    static GET_APPLICANT_BY_ID = apiUrl + "/api/applicant/GetApplicantById";
    static UPDATE_APPLICANT = apiUrl + "/api/applicant/GetApplicantById";
    static DOWNLOAD_APPLICANT = apiUrl + "/api/applicant/DownloadFile";
    static DELETE_APPLICANT = apiUrl + "/api/applicant";
}