import { OrderStatus } from './order-status';
import { Order } from './order';

export class StoreService {

  private orderStatuses: OrderStatus[] = [
      { id: 1, name: "New", description: "" },
      { id: 2, name: "Stock", description: "" },
      { id: 3, name: "Complete", description: "" }
  ];

  private orders: Order[] = [
    {
      id: 1,
      client: "Ivanov",
      phone: "23423",
      car: "Audi",
      part: "Wheels",
      cost: 223,
      creationDate: new Date(Date.now()),
      modificationDate: new Date(Date.now()),
      statusId: 1
    }
  ];

  public getOrderStatuses(): OrderStatus[] {
    return this.orderStatuses;
  }

  public getOrders(): Order[] {
    return this.orders;
  }

  public getOrderStatus(id: number): OrderStatus {
    return this.orderStatuses.filter(x => x.id == id)[0];
  }
}
