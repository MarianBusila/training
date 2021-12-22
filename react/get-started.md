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