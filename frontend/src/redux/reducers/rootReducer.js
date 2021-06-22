import {combineReducers} from 'redux';
import * as fromTransaction from './transactionsReducer';

export const initialState = {

}

export const rootReducer = combineReducers({
    transactions : fromTransaction.reducer
});