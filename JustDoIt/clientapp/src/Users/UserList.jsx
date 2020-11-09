import * as React from 'react';
import User from './User.jsx'
import UsersForm from './UsersForm.jsx'
import api from './api.js'

class UserList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { users: [] };

        this.onAddUser = this.onAddUser.bind(this);
        this.onRemoveUser = this.onRemoveUser.bind(this);
    }
    //load data
    loadData() {
        api.Users().getUsers()
        .then(response => this.setState({ users: response.data }))
        .catch(err => console.log(err));
    }
    componentDidMount() {
        this.loadData();
    }
    // add object
    async onAddUser(user) {
        if (user) {
            api.Users().createUser(user).then(response => this.loadData()).catch(err => console.log(err));
        }
    }
    // delete object
    onRemoveUser(user) {
        if (user) {
            api.Users().deleteUser(user.id).then(response => this.loadData()).catch(err => console.log(err));
        }
    }
    render() {

        var remove = this.onRemoveUser;
        return <div>
            <UsersForm onPhoneSubmit={this.onAddUser} />
            <h2>List of users</h2>
            <div >
                {
                    this.state.users.map(function (user) {

                        return <User key={user.id} user={user} onRemove={remove} />
                    })
                }
            </div>
        </div>;
    }
}

export default UserList;