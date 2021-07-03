import React from "react";

export default function TransactionItem({ transaction }) {
  return (
    <div>
      <li className="collection-item" key={transaction.transactionIdentifier}>
        <div>
            <a onClick={} href="!">
{transaction.isCompleted?
<span style={{textDecoration: "line-through"}} className="grey-text lighten-2">
    {transaction.ISOCode}
</span>: <span className="black-text darken-2">{todo.ISOCode}</span> }

            </a>
        </div>
      </li>
    </div>
  );
}
