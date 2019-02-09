import { Component } from '@angular/core';

import { StoreService } from './store.service'
import { Order } from './order';

@Component({
  selector: 'app-simple-store',
  templateUrl: './simple-store.component.html',
  providers: [StoreService]
})
export class SimpleStoreComponent {
  orders: Order[] = [];

  constructor(private storeService: StoreService) { }

  ngOnInit() {
    this.orders = this.storeService.getOrders();
  }
}
