import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.css']
})
export class BalanceComponent {

  public walletBalance: WalletBalance = {balance:0};

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WalletBalance>(baseUrl + 'balance').subscribe(result => {
      this.walletBalance = result;
    }, error => console.error(error));
  }
}

interface WalletBalance {
  balance: number;
}
