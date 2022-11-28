import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { Sighting } from "../Sighting";


@Component({
  templateUrl: "update.html"
})
export class Update {
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

  constructor(private http: HttpClient, private fb: FormBuilder,
              private route: ActivatedRoute, private router: Router) {
      this.UFOform = fb.group(this.validering);
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.updateSighting(params.id);
    })
  }

  onSubmit() {
      this.updateASighting();
  }

  public localData: Object[] = [
    { Id: 'Seconds', Unit:'Seconds' },
    { Id: 'Minutes', Unit:'Minutes' },
    { Id: 'Hours', Unit: 'Hours' },
    { Id: 'Days', Unit:'Days' }
  ];


  updateSighting(id: number) {
    this.http.get<Sighting>("api/sighting/" + id)
      .subscribe(
        sighting => {
          this.UFOform.patchValue({ id: sighting.id });
          this.UFOform.patchValue({ city: sighting.city });
          this.UFOform.patchValue({ country: sighting.country });
          this.UFOform.patchValue({ duration: sighting.duration });
          this.UFOform.patchValue({ datetime: sighting.datetime });
          this.UFOform.patchValue({ dateposted: sighting.dateposted });
          this.UFOform.patchValue({ comments: sighting.comments });
        },
        error => console.log(error)
      );
  }

  updateASighting() {
    const updatedSighting = new Sighting();
    updatedSighting.id = this.UFOform.value.id;
    updatedSighting.city = this.UFOform.value.city;
    updatedSighting.country = this.UFOform.value.country;
    updatedSighting.duration = this.UFOform.value.duration;
    updatedSighting.datetime = this.UFOform.value.datetime;
    updatedSighting.dateposted = this.UFOform.value.dateposted;
    updatedSighting.comments = this.UFOform.value.comments;

    this.http.put("api/sighting/", updatedSighting)
      .subscribe(
        returned => {
          this.router.navigate(['/read']);
        },
        error => console.log(error)
      );
  }
}
