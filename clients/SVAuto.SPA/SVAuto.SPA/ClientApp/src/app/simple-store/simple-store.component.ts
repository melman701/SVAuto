import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatFormField } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';

import { StoreService } from './store.service'
import { Order } from './order';


@Component({
  selector: 'app-simple-store',
  templateUrl: './simple-store.component.html',
  styleUrls: ['./simple-store.component.css'],
  providers: [StoreService]
})
export class SimpleStoreComponent {
  orders: Order[] = [];
  displayedColumns: string[] = ['id', 'client', 'phone', 'car', 'part', 'cost', 'status', 'modificationDate', 'creationDate'];
  readonly columnSortedByDefault: string = 'id';
  dataSource: MatTableDataSource<Order>;
  selection: SelectionModel<Order>;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private storeService: StoreService) {
    
  }

  ngOnInit() {
    this.orders = this.storeService.getOrders();
    this.dataSource = new MatTableDataSource(this.orders);

    this.dataSource.sortingDataAccessor = (item, property) => {
      switch (property) {
        case 'status':
          return item.status.name;
        default:
          return item[property];
      }
    }
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;

    this.selection = new SelectionModel<Order>(false, []);
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
