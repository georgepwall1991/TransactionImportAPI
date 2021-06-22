import {createSelector} from 'reselect'

const getTransactionState = (state) => state.transactions;

export const getTransactions = createSelector(
    [getTransactionState],
    s => s.transactions
);