import './App.css';
import { Component } from 'react';

class App extends Component {

  state = {
    todoList: []
  }

  render() {
    return (
      <div>
        <div className="jumbotron jumbotron-fluid py-2">
          <div className="container">
            <h1 className="display-2">Todos App</h1>
          </div>
        </div>
        <form className="mb-3" onSubmit={this.handleSubmit}>
          <div className="input-group">
            <input type="text" name="todoTask" className="form-control" placeholder="Please enter your task" autoComplete="off" />
            <div className="input-group-append">
              <button type="submit" className="btn btn-outline-success">Add</button>
            </div>
          </div>
        </form>

        <ul className="list-group">
          {
            this.state.todoList.map(
              (item, index) => {
                return <li className="list-group-item" key={index}>
                  {item}
                  <button className="btn btn-sm btn-outline-danger float-right" onClick={(event) => { this.deleteTodoTask(event, index)}}>Delete</button>
                </li>
              }
            )
          }
        </ul>
      </div>
    );
  }

  handleSubmit = (event) => {
    var taskDesc = event.target.elements.todoTask.value;
    if(taskDesc.length > 0) {
      this.setState({
        todoList: [...this.state.todoList, taskDesc]
      });
      event.target.reset();
    }
    event.preventDefault()
  }

  deleteTodoTask = (event, index) => {
    var taskArray = [...this.state.todoList];
    taskArray.splice(index, 1);
    this.setState({todoList: taskArray});
  }
}

export default App;
