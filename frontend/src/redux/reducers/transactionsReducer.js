export const initialState = {
    transactions: [
        {transactionIdentifier: "GeorgeTest", transactionAmount : 23235.22, ISOCode: "GBP", TransactionDate : "2020-01-01", TransactionStatus : "Approved"},
        {transactionIdentifier: "GeorgeTest1", transactionAmount : 23523.22, ISOCode: "USD", TransactionDate : "2020-01-01", TransactionStatus : "Rejected"},
        {transactionIdentifier: "GeorgeTest2", transactionAmount : 23323.22, ISOCode: "JPY", TransactionDate : "2020-01-01", TransactionStatus : "Approved"},
        {transactionIdentifier: "GeorgeTest3", transactionAmount : 22323.22, ISOCode: "AUD", TransactionDate : "2020-01-01", TransactionStatus : "Failed"}
    ]
};

export const reducer = (state = initialState, action) => {
    switch(action.type){
    case 'ADD_TRANSACTION':
        return{...state, transactions : action.transactions }}
};