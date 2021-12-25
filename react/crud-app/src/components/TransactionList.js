import React, { Component } from 'react'
import TransactionForm from './TransactionForm'

class TransactionList extends Component {
    state = {
        currentIndex: -1,
        list: this.returnList()
    }

    returnList() {
        if(localStorage.getItem("transactions") == null)
            localStorage.setItem("transactions", JSON.stringify([]))
        return JSON.parse(localStorage.getItem("transactions"))
    }

    onAddOrEdit = (data) => {
        var list = this.returnList();
        if(this.state.currentIndex === -1)
            list.push(data);
        else
            list[this.state.currentIndex] = data
        localStorage.setItem("transactions", JSON.stringify(list));
        this.setState({list: list, currentIndex: -1}) // we set the currentIndex to -1 to reset the form
    }

    handleEdit = index => {
        this.setState({currentIndex: index})
    }

    handleDelete = index => {
        var list = this.state.list;
        list.splice(index, 1);
        localStorage.setItem("transactions", JSON.stringify(list));
        this.setState({list: list, currentIndex: -1})
    }

    render() {
        return (
            <div>
                <TransactionForm 
                    onAddOrEdit={this.onAddOrEdit} 
                    currentIndex={this.state.currentIndex}
                    list = {this.state.list}
                />
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
                                    <td><button onClick={() => this.handleEdit(index)}>Edit</button></td>
                                    <td><button onClick={() => this.handleDelete(index)}>Delete</button></td>
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
