import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {
  @Input() buttonConfig: any;
  @Output() textBtnClickEmt: EventEmitter<string> = new EventEmitter<string>();
  @Output() imgBtnClickEmt: EventEmitter<string> = new EventEmitter<string>();
  constructor() { }

  ngOnInit() { }

  onTextBtnClick() {
    this.textBtnClickEmt.emit();
  }

  onImgBtnClick() {
    this.imgBtnClickEmt.emit();
  }
}
