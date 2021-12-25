import React, { Component } from 'react'
import TransactionForm from './TransactionForm'

class TransactionList extends Component {
    state = {
        list: this.returnList()
    }

    returnList() {
        if(localStorage.getItem("transactions") == null)
            localStorage.setItem("transactions", JSON.stringify([]))
        return JSON.parse(localStorage.getItem("transactions"))
    }

    onAddOrEdit = (data) => {
        var list = this.returnList();
        list.push(data);
        localStorage.setItem("transactions", JSON.stringify(list));
        this.setState({list: list})
    }

    render() {
        return (
            <div>
                <TransactionForm onAddOrEdit={this.onAddOrEdit} />
                <hr />
                <table>
                    <tbody>
                        {
                            this.state.list.map((item, index) => {
                                return <tr key={index}>
                                    <td>{item.beneficiaryAccountNo}</td>
                                    <td>{item.swiftCode}</td>
                                    <td>{item.beneficiaryName}</td>
                                    <td>{item.amount}</td>
                                </tr>
                            })
                        }
                    </tbody>
                </table>
            </div>
        )
    }
}

export default TransactionList
