import { OrderStatus } from "./order-status";

export class Order {
  public id: number;
  public client: string;
  public phone: string;
  public car: string;
  public part: string;
  public cost: number;
  public creationDate: Date;
  public modificationDate: Date;

  public status: OrderStatus;
}
