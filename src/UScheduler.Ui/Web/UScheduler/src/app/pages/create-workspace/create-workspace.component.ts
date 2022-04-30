import { Component, NgModule, OnInit } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DxButtonModule, DxFormModule, DxPopupModule, DxSelectBoxModule, DxTextAreaModule } from 'devextreme-angular';
import { DxiItemModule } from 'devextreme-angular/ui/nested';
import ArrayStore from 'devextreme/data/array_store';
import DataSource from 'devextreme/data/data_source';
import { Workspace, WorkspacesService } from '../../shared/services/workspaces.service';

@Component({
  selector: 'app-create-workspace',
  templateUrl: './create-workspace.component.html',
  styleUrls: ['./create-workspace.component.scss']
})
export class CreateWorkspaceComponent{
  workspace: Workspace;
  accessLevels: DataSource;
  workspaceTemplates: DataSource;
  labelMode: string;

  constructor(private workspacesService: WorkspacesService) { 
    this.workspace = new Workspace();

    this.accessLevels = new DataSource({
      store: {
          type: "array",
          data: [ 'Private', 'Public' ]
      }
    });

    this.workspaceTemplates = new DataSource({
      store: {
          type: "array",
          data: [ 'Empty', 'Basic' ]
      }
    });

    this.labelMode = 'floating';
  }

  createWorkspace(e: any) {
    e.preventDefault();
    console.log(`Creating workspace:\'${this.workspace.title}\'`);
    this.workspacesService.createWorkspace(this.workspace)
  }
}

@NgModule({
  imports: [
    BrowserModule,
    DxFormModule,
    DxiItemModule,
    DxTextAreaModule,
    DxPopupModule,
    DxSelectBoxModule,
    DxButtonModule
  ],
  declarations: [ ],
  exports: [ ]
})
export class CreateWorkspaceModule { }