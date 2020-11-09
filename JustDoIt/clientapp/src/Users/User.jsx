import * as React from 'react';
import './user.css';




class User extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.user };
        this.onClick = this.onClick.bind(this);
    }
    onClick(e) {
        this.props.onRemove(this.state.data);
    }
    render() {
        return <div>
            <p><b>Name - {this.state.data.firstName}</b></p>
            <p>Second name -  {this.state.data.secondName}</p>
            <p><button onClick={this.onClick}>Delete</button></p>
        </div>;
    }
}

export default User;