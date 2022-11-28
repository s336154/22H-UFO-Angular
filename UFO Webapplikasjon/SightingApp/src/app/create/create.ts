import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Sighting } from "../Sighting";

@Component({
  templateUrl: "create.html"
})
export class Create {
  UFOform: FormGroup;

  
  validering = {
    id: [""],
    city: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])
    ],
    country: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])
    ],
    duration: [
      null, Validators.compose([Validators.required, Validators.pattern("[0-9a-zA-ZøæåØÆÅ\\-. ]{2,30}")])
    ],
    dateposted: [
      null, Validators.compose([Validators.required, Validators.pattern("[0-9]{4}")])
    ],
    datetime: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])
    ],
    comments: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])
    ]
  }

  constructor(private http: HttpClient, private fb: FormBuilder, private router: Router) {
    this.UFOform = fb.group(this.validering);
  }

  onSubmit() {
      this.createSighting();
  }

  createSighting() {
    const createdSighting = new Sighting();
    createdSighting.id = this.UFOform.value.id;
    createdSighting.city = this.UFOform.value.city;
    createdSighting.country = this.UFOform.value.country;
    createdSighting.duration = this.UFOform.value.duration;
    createdSighting.datetime = this.UFOform.value.datetime;
    createdSighting.dateposted = this.UFOform.value.dateposted;
    createdSighting.comments = this.UFOform.value.comments;

    this.http.post("api/sighting", createdSighting)
      .subscribe(returned => {
        this.router.navigate(['/read']);
      },
       error => console.log(error)
      );
  };
}
