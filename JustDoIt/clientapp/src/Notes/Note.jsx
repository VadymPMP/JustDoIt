import * as React from 'react';
//import './user.css';


class Note extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.note };
        this.onClick = this.onClick.bind(this);
        
    }
    onClick(e) {
        this.props.onRemove(this.state.data);
    }
    render() {
        return <div>          
            <p>Id of user-  {this.state.data.userId}</p>
            <p>Note -  {this.state.data.note}</p>
            <p>User name - {this.state.data.user.firstName}</p> 
            <p><button onClick={this.onClick}>Delete</button></p>
        </div>;
    }
}

export default Note;