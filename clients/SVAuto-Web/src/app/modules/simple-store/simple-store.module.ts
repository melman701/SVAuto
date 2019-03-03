import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { 
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatTableModule,
    MatInputModule
} from '@angular/material';

import { SimpleStoreComponent } from './components/simple-store.component';
import { SimpleStoreService } from './services/simple-store.service';


@NgModule({
    declarations: [
        SimpleStoreComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        MatPaginatorModule,
        MatSortModule,
        MatFormFieldModule,
        MatTableModule,
        MatInputModule
    ],
    exports: [
    ],
    providers: [
        SimpleStoreService
    ],
    bootstrap: [ SimpleStoreComponent ]
})
export class SimpleStoreModule { }