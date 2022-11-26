import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Modal } from './deleteModal';
import { Sighting } from "../Sighting";

@Component({
  templateUrl: "read.html"
})
export class Read {
  allSightings: Array<Sighting>;
  loading: boolean;
  sightingToDelete: string;
  deleteOK: boolean;

  constructor(private http: HttpClient, private router: Router, private modalService: NgbModal) { }

  ngOnInit() {
    this.loading = true;
    this.readAllSightings();
  }

  readAllSightings() {
    this.http.get<Sighting[]>("api/sighting/")
      .subscribe(sightings => {
        this.allSightings = sightings;
        this.loading = false;
      },
       error => console.log(error)
      );
  };

  // denne slette funksjonen blir litt komplisert da vi har to asynkrone kall inne i hverandre
  deleteSighting(id: number) {

    // først hent navnet på kunden
    this.http.get<Sighting>("api/sighting/" + id)
      .subscribe(sighting => {
        this.sightingToDelete = sighting.city + "  " + sighting.country + "  " + sighting.datetime;

        // så vis modalen og evt. kall til slett
        this.viewModalAndDelete(id);
      },
        error => console.log(error)
      );
  }

  viewModalAndDelete(id: number) {
    const modalRef = this.modalService.open(Modal);

    modalRef.componentInstance.name = this.sightingToDelete;

    modalRef.result.then(returned => {
        console.log('Closed with:' + returned);
        if (returned == "Delete") {

          // kall til server for sletting
          this.http.delete("api/sighting/" + id)
            .subscribe(returned => {
              this.readAllSightings();
            },
              error => console.log(error)
            );
        }
        this.router.navigate(['/read']);
     });
  }
}
