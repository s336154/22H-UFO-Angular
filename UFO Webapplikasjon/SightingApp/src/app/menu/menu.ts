import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './menu.html'
})
export class Menu {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
