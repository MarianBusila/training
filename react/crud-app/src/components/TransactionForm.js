import React, { Component } from 'react'

class TransactionForm extends Component {
    state = {
        ...this.returnStateObject()
    }

    returnStateObject() {
        if(this.props.currentIndex === -1)
            return {
                beneficiaryAccountNo: '',
                swiftCode: '',
                beneficiaryName: '',
                amount: ''
            }
        else
            return this.props.list[this.props.currentIndex]
    }

    componentDidUpdate(prevProps) {
        if(prevProps.currentIndex !== this.props.currentIndex || prevProps.list.length !== this.props.list.length)
            this.setState({...this.returnStateObject()})
    }

    handleInputChange = e => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    handleSubmit = e => {
        e.preventDefault();
        this.props.onAddOrEdit(this.state); // calls parent's onAddOrEdit to update the list of transactions and the local storage
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit} autoComplete="off">
                <input name="beneficiaryAccountNo" placeholder="Beneficiary Account Number" value={this.state.beneficiaryAccountNo} onChange={this.handleInputChange} /> <br/>
                <input name="swiftCode" placeholder="Swift Code" value={this.state.swiftCode} onChange={this.handleInputChange} /> <br/>
                <input name="beneficiaryName" placeholder="Beneficiary Name" value={this.state.beneficiaryName} onChange={this.handleInputChange} /> <br/>
                <input name="amount" placeholder="Amount" value={this.state.amount} onChange={this.handleInputChange} /> <br/>
                <button type="submit">Submit</button>
            </form>
        )
    }
}

export default TransactionForm
