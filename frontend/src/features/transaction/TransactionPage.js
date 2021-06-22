import React, { Component } from 'react'
import { connect } from 'react-redux'
import {getTransactions} from '../../redux/selectors/transactionSelectors';
export class TransactionPage extends Component {
    render() {
        return (
            <div>
                <TransactionList transactions={this.props.transactions}/>
            </div>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        transactions : getTransactions(state)
    }   
}

export default connect(mapStateToProps)(TransactionPage);