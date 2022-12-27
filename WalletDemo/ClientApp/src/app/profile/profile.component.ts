import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {

  public profile: Profile = {
    profileId: 1,
    firstName: '',
    lastName: '',
    emailAddress: '',
    mobileNumber: '',
    address: '',
    city: '',
    state: '',
    postal: ''  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Profile>(baseUrl + 'profile').subscribe(result => {
      this.profile = result;
    }, error => console.error(error));
  }
}

interface Profile {
  profileId: number;
  firstName: string;
  lastName: string;
  emailAddress: string;
  mobileNumber: string;
  address: string;
  city: string;
  state: string;
  postal: string;
}
