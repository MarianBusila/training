## Get Started

Based on Pluralsight tutorial [React: Getting Started](https://app.pluralsight.com/library/courses/react-js-getting-started/table-of-contents)

### Concepts
- Components    
    - like functions, the take input and output something
    - Input: props, state | Output: UI
    - immutable props, mutable state
    - can manage a private state
    - function or class components

- Reactive updates
    - it updates the browser

- Virtual views in memory
    - virtual DOM
    - tree reconcilitation between virtual DOM and browser

### Function and Class Components

 - *props* cannot be changed
 - *state* can be changed


```js
const MyComponent = (props) => {
    return (
        <domElementOrComponent />
    );
    )
}
```

```js
class MyComponent extends React.Component {
    render() {
        return (
            <domElementOrComponent />
        );
    }
}
```
- JSX is not HTML: we use HTML like syntax to avoid calling the React API explicetly (ex: React.createElement("h1", null, "Getting started"))
- babel is responsible of converting JSX to react api calls

### Examples

- use jscomplete.com/playground to prototype react components, if you do not have a development env

```js
function Hello() {
  return <div>Hello React!</div>
}

ReactDOM.render(
  <Hello />,
  document.getElementById('mountNode')
);
```

- React Hook:  *useState(initialValue)* returns a state object (getter) and an updater function(setter). It uses java script array destructuring feature to return multiple values

```js
function Button() {
  const [counter, setCounter] = useState(0)
  return <button onClick={() => setCounter(counter+1)}>{counter}</button>
}

ReactDOM.render(
  <Button />,
  document.getElementById('mountNode')
);
```

- to pass a value from a parent state (App) to a child (Display) we use *props*. We can also pass behaviour from parent to child (see onClickFunction). This is called *one way data flow*

```js
function Button(props) {
  return (
    <button onClick={props.onClickFunction}>
        +1
    </button>
    )
}

function Display(props) {
  return (
    <div>{props.message}</div>
  )
}

function App() {
  const [counter, setCounter] = useState(42)
  const incrementCounter = () => setCounter(counter+1);
  return(
  <div>
    <Button onClickFunction={incrementCounter} />
    <Display message={counter} />
  </div>
    )
}

ReactDOM.render(
  <App />,
  document.getElementById('mountNode')
);
```

- make Button generic
```js
function Button(props) {
  const handleClick = () => props.onClickFunction(props.increment)
  return (
    <button onClick={handleClick}>
        {props.increment}
    </button>
    )
}

function Display(props) {
  return (
    <div>{props.message}</div>
  )
}

function App() {
  const [counter, setCounter] = useState(42)
  const incrementCounter = (incrementValue) => setCounter(counter+incrementValue);
  return(
  <div>
    <Button onClickFunction={incrementCounter} increment={1} />
    <Button onClickFunction={incrementCounter} increment={5} />
    <Button onClickFunction={incrementCounter} increment={10} />
    <Display message={counter} />
  </div>
    )
}

ReactDOM.render(
  <App />,
  document.getElementById('mountNode')
);
```

### Modern JavaScript
- variable and block scope
    - use *let* and *const* for variables
- arrow function
    - define a function without using *function* keyword
    ```js
    const X = function() { 
        // "this" here is the caller of X 
        };
    const Y = () => {
        // "this" here is not the caller of Y
        // it's the same "this" found in the Y's scope
        }
    ```
    - popular for array fucntions
    ```js
    [1, 2, 3, 4].map(a => a * a)
    ```
- destructuring and rest/spread
    - even if we pass a circle object to the function, it extracts the radius
    ```js
    const cricle = {
        label: 'circleX',
        radius: 2
    }

    const circleArea = ({radius}) = (PI * radius * radius).toFixed(2)

    console.log (circleArea(circle))
    ```

    ```js
    const [first, second,, forth] = [10, 20, 30, 40]
    const [first, ...restOfItems] = [10, 20, 30, 40] // restOfItems is an array of the last 3 elements
    ```
- template strings
    - you can define strings with "example" or with 'example'
    - a tempalte string is defined with ``
    ```js
    const html = `<div>${Math.random()}</div>`
    ```

- classes
    ```js
    class Person {
        constructor(name) {
            this.name = name;
        }
        greet() {
            console.log(`Hello ${this.name}`)
        }
    }

    const person = new Person("Max")
    person.greet()
    ```
- promisses and async/await
    ```js
    const fetchData = () => {
    fetch('https://api.github.com').then(resp => 
        resp.json().then(data => 
            console.log(data)
        )
        )
    }

    const fetchDataAsync = async () => {
        const resp = await fetch('https://api.github.com');
        const data = await resp.json();
        console.log(data)
    }

    fetchData()
    fetchDataAsync()
    ```

### Development env
- download latest node js
- ```npx create-react-app cra-test``` to create a react app. It install react, react-dom and react-scripts.
- ```npm start``` to start the app
- create-react-app wires all the tools needed, like *babel* (convert code to jsva script), webpack (bundle packages), etc
- for a manaul installation, see: https://jscomplete.com/reactful
- you can do server side or client side rendering of react components. With SSR, even when java script is disabled in the browser, you can still run react served by a web server

### GitHub Cards App
- you can style an app with CSS or using style attribute. Example:
```js
class ConditionalStyle extends React.Component {
  render() {
    return (
      <div style={{color: Math.random() < 0.5 ? 'green': 'red'}}>
        How do you like this?
      </div>

    )
  }
}

ReactDOM.render(
  <ConditionalStyle />,
  mountNode
);

```
- the GitHub Card App
```js
const CardList = (props) => (
      <div>
        {props.profiles.map(profile => <Card key={profile.id} {...profile} />)}
      </div>  
)

class Card extends React.Component {
  render() {
    const profile = this.props;
    return (
      <div className="github-profile">
        <img src={profile.avatar_url} />
        <div className="info">
          <div className="name">{profile.name}</div>
          <div className="company">{profile.company}</div>
        </div>
      </div>
    );
  }
}

class Form extends React.Component {
  state = {userName: ''}
  handleSubmit = async (event) => {
    event.preventDefault(); // prevent default form submission and let React handle it
    const resp = await axios.get(`https://api.github.com/users/${this.state.userName}`)
    this.props.onSubmit(resp.data);
    this.setState( {userName: ''}) // reset the textbox
  };
  render() {
    return (
        <form onSubmit={this.handleSubmit}>
          <input 
            type="text" 
            value = {this.state.userName}
            onChange={event => this.setState({userName: event.target.value})} // react is aware of the changes in the text box as the user is typing and it could provide feedback like number of chars typed, etc
            placeholder="GitHub username" 
            required />
          <button>Add card</button>
        </form>
    )
  }
}

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      profiles: [],
    };
  }
  
  addNewProfile = (profileData) => {
    this.setState(prevState => ({
      profiles: [...prevState.profiles, profileData]
    })
    );
  }
  render() {
    return (
      <div>
        <div className="header">{this.props.title}</div>
        <Form onSubmit = {this.addNewProfile} />
        <CardList profiles={this.state.profiles} />
      </div>
      )
  }
}

ReactDOM.render(
  <App title="The Github Cards App" />,
  mountNode
);
```

```css
.github-profile {
	margin: 1rem;
  img {
    width: 75px;
  }
  .info {
    display: inline-block;
    margin-left: 12px;
		.name {
    	font-size: 1.25rem;
      font-weight: bold;
    }
  }
}

form {
	border: thin solid #ddd;
  background-color: #fbfbfb;
  padding: 2rem;
  margin-bottom: 2rem;
  display: flex;
  justify-content: center;
}

.header {
	text-align: center;
  font-size: 1.5rem;
  margin-bottom: 1rem;
}
```
