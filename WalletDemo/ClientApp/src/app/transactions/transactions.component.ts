import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent  {

  public transactions: Transaction[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Transaction[]>(baseUrl + 'transaction').subscribe(result => {
      this.transactions = result;
      console.log('txn:'+this.transactions);
    }, error => console.error(error));
  }
}


interface Transaction {
  transactionId: string;
  requestAmount: number;
  dateCreated: Date;
  currencyCode: string;
  countrycode: string;
  statusId: number;
  statusName: string;
  vendorResponse: string;
  vendorFee: number;
  vendorReference: string;
  completedDate: Date;
  type: number;
}
