import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { DoughnutTreeNode } from '../../../_models/DoughnutTreeNode';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {
  @Input() treeNode: DoughnutTreeNode;
  @Input() showResult: boolean;
  
  buildTree: boolean = false;
  @Output() onPositiveAnswer: EventEmitter<DoughnutTreeNode> = new EventEmitter<DoughnutTreeNode>();
  @Output() onNegativeAnswer: EventEmitter<DoughnutTreeNode> = new EventEmitter<DoughnutTreeNode>();
  @Output() onPlayAgain: EventEmitter<string> = new EventEmitter<string>();
  @Output() onShowResult: EventEmitter<string> = new EventEmitter<string>();

  yesBtnConfig = {
    styles: {
      position: 'relative',
      width: '150px',
      height: '60px',
      backgroundColor: '#57bb8a',
      color: '#fff',
      fontFamily: 'sans-serif',
      fontSize: '20px',
      borderRadius: '10px',
      marginTop: '30px',
      curson: 'pointer',
      marginLeft: '5px'
    },
    text: 'Yes'
  };

  noBtnConfig = {
    styles: {
      position: 'relative',
      width: '150px',
      height: '60px',
      backgroundColor: '#d33a2c',
      color: '#fff',
      fontFamily: 'sans-serif',
      fontSize: '20px',
      borderRadius: '10px',
      marginTop: '30px',
      curson: 'pointer',
      marginLeft: '5px'
    },
    text: 'No'
  };

  playAgainBtnConfig = {
    styles: {
      position: 'relative',
      width: '150px',
      height: '60px',
      backgroundColor: '#f92672',
      color: '#fff',
      fontFamily: 'sans-serif',
      fontSize: '20px',
      borderRadius: '10px',
      marginTop: '30px',
      curson: 'pointer'
    },
    text: 'Play again!'
  };

   showResultsBtnConfig = {
    styles: {
      position: 'relative',
      width: '150px',
      height: '60px',
      backgroundColor: '#ff9f02',
      color: '#fff',
      fontFamily: 'sans-serif',
      fontSize: '20px',
      borderRadius: '10px',
      marginTop: '30px',
      curson: 'pointer'
    },
    text: 'Show result'
  };

  constructor() { }

  ngOnInit() {
  }

  yesButtonClicked() {
    this.onPositiveAnswer.emit(this.treeNode);
  }

  noButtonClicked() {
    this.onNegativeAnswer.emit(this.treeNode);
  }

  playAgainButtonClicked() {
    this.onPlayAgain.emit();
  }

  showResultsButtonClicked() {
    this.onShowResult.emit();
  }
}
