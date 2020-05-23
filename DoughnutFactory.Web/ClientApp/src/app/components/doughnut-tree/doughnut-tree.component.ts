import { Component, OnInit, Input } from '@angular/core';
import { AppService } from '../../../_services/app.service';
declare var $: any;

@Component({
  selector: 'app-doughnut-tree',
  templateUrl: './doughnut-tree.component.html',
  styleUrls: ['./doughnut-tree.component.css']
})
export class DoughnutTreeComponent implements OnInit {
  @Input() selectedNodes: any[];

  constructor(private appService: AppService) { }

  ngOnInit() {
    this.getDoughnutTree();
  }

  getDoughnutTree() {
    this.appService.getDoughnutTree().subscribe(data => {

      this.selectedNodes.forEach(node => {
         this.searchTree(data, node);
      })
     
      $('#build-tree').orgchart({
        data: data,
        nodeTemplate: this.questionNodeTemplate
      });
    });
  }

  searchTree(element, matchingTitle) {
    if (element.id == matchingTitle) {
      element.isSelected = true;
    }
    else if (element.children != null) {
    var i;
    var result = null;
    for (i = 0; result == null && i < element.children.length; i++) {
      result = this.searchTree(element.children[i], matchingTitle);

      if (result) {
        element.isSelected = true;
      }
    }     
  }
  return null;
}

  questionNodeTemplate = function (data) {
    if (data.isSelected) {
      return `
    <div  class="tree-node">${data.text}</div>
  `;
    }
    else {
      return `
    <div class="office">${data.text}</div>
  `;
    }
  }
}
