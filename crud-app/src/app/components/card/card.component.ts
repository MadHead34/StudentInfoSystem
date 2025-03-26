import { Component, Input } from '@angular/core';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  standalone: true,
  imports: [NgClass]
})
export class CardComponent {
  @Input() title!: string;
  @Input() value!: number;
  @Input() color!: string;
}
