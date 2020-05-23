import { Component } from '@angular/core';
import { AppService } from '../../_services/app.service';
import { DoughnutTreeNode } from '../../_models/DoughnutTreeNode';
import { DoughnutTree } from '../../_models/DoughnutTree';

declare var $: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  doughnutTree: DoughnutTree;
  buildTree: boolean = false;
  question: string;
  treeNode: DoughnutTreeNode;
  selectedNodes: any[] = [];
  hideQuestions: boolean = false;
  showResult: boolean = false;

  constructor(private appService: AppService) { }

  ngOnInit() {
    this.getFirstNode();
  }

  getFirstNode() {
    this.appService.getFirstNode().subscribe(data => {
      this.treeNode = data;
      this.question = data.question;
      this.selectedNodes.push(1);
    });
  }

  getNodeById(id) {
    this.appService.getNodeById(id).subscribe(data => {

      this.treeNode = data;
      this.question = data.question;
      if (data.positiveNodeId || data.negativeNodeId) {
        this.showResult = false;
      }
      else {
        this.showResult = true;
      }
    });
  }

  onPositiveAnswer(event) {
    var positiveNodeId = event.positiveNodeId;

    this.getNodeById(positiveNodeId);
    this.selectedNodes.push(positiveNodeId);

    if (positiveNodeId) {
      this.showResult = false;
    } else {
      this.showResult = true;
    }
  }

  onNegativeAnswer(event) {
    var negativeNodeId = event.negativeNodeId;
   
    if (negativeNodeId) {
      this.selectedNodes.push(negativeNodeId);
      this.getNodeById(negativeNodeId);
    } else {
      this.buildTree = true;
    }  
  }

  onPlayAgain() {
    this.hideQuestions = false;
    this.buildTree = false;
    this.showResult = false;
    this.selectedNodes = [];
    this.getFirstNode();
  }

  onShowResult() {
    this.buildTree = true;
  }
}
