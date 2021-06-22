import React, { Component } from "react";

export default function TransactionList({ transactions }) {
  const transactionList = transactions.length ? (
    transactions.map((transaction, idx) => (
      <TransactionItem key={idx} transaction={transaction} />
    ))
  ) : (
    <p className="center">You don't have any Transactions</p>
  );

  return <div>
      <h1 className="center red-text">Transactions</h1>
      <ul className="collection"></ul>
      {transactionList}
  </div>;
}
