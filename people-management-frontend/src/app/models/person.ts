import { Address } from "./address";

export interface Person {
  personId?: string;
  name?:string;
  dateOfBirth?: Date;
  addresses?: Address[];
}