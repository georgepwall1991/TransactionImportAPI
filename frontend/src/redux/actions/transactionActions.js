import axios from 'axios'

export const addTransactions = (transactions) => ({
    type:'ADD_TRANSACTION',
    transactions
});

export const startAddingTransactions = (transactions) => {
    return(dispatch, getState) => {
        axios
        .post(`${process.env.REACT_APP_TRANSACTION_SERVICE}/Api/AddTransactions`, transactions)
        .then(response => {dispatch(addTransactions(response.data))})
        .catch(error => console.log(error))
    }
}

