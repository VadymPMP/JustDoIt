import * as React from 'react';
import classes from './Login.module.css'
import { NavLink } from 'react-router-dom';

class Login extends React.Component {

    constructor(props) {
        super(props);
        this.state = { Email: "", Password: "" };
        this.onNameChange = this.onNameChange.bind(this);
        this.onSecondNameChange = this.onSecondNameChange.bind(this);
    }
    onNameChange(e) {
        this.setState({ Email: e.target.value });
    }
    onSecondNameChange(e) {
        this.setState({ Password: e.target.value });
    }
    
    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input type="text"
                        placeholder="Email"
                        value={this.state.Email}
                        onChange={this.onNameChange} />
                </p>
                <p>
                    <input type="text"
                        placeholder="Password"
                        value={this.state.Password}
                        onChange={this.onSecondNameChange} />
                </p>
                <button className = {classes.item} onClick={this.onClick}>
                    <NavLink to = '/Users'  >Login</NavLink>
                    </button>
                <button className = {classes.item} onClick={this.onClick}>
                    <NavLink to = '/Registration'>Registration</NavLink>
                </button>
            </form>)
    }
}


export default Login;