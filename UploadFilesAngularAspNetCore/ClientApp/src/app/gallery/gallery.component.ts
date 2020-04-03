import { Component, OnInit, Inject } from '@angular/core';
import { GalleryService } from '../services/gallery.service';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html'
})
export class GalleryComponent implements OnInit {

  galleries = [];

  constructor(
    private galleryService: GalleryService,
    @Inject('BASE_URL') public baseUrl: string, ) { }

  ngOnInit() {
    this.galleries = this.galleryService.get();
  }

}
