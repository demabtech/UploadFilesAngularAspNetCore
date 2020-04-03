import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GalleryService {

  private galleries = [];

  add(gallery) {
    this.galleries.push(gallery);
  }

  get() {
    return this.galleries;
  }

}
