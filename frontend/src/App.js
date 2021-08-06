import React from 'react'
import { useSelector } from "react-redux";


function App() {
  const transactions = useSelector(state => state.transactions);
  const useTransactionState = transactions.map(value => value.transactionIdentifier);
  return (
    <div className="App">
      <h1>{useTransactionState}</h1>
    </div>
  );
}

export default App;
