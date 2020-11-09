import * as React from 'react';
class UsersForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { firstName: "", secondName: "" };

        this.onSubmit = this.onSubmit.bind(this);
        this.onNameChange = this.onNameChange.bind(this);
        this.onSecondNameChange = this.onSecondNameChange.bind(this);
    }
    onNameChange(e) {
        this.setState({ firstName: e.target.value });
    }
    onSecondNameChange(e) {
        this.setState({ secondName: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var FirstName = this.state.firstName;
        var SecondName = this.state.secondName;
        if (!FirstName || !SecondName) {
            return;
        }
        this.props.onPhoneSubmit({ firstName: FirstName, secondName: SecondName });
        this.setState({ firstName: "", secondName: "" });
    }
    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input type="text"
                        placeholder="Name"
                        value={this.state.firstName}
                        onChange={this.onNameChange} />
                </p>
                <p>
                    <input type="text"
                        placeholder="Second Name"
                        value={this.state.secondName}
                        onChange={this.onSecondNameChange} />
                </p>
                <input type="submit" value="Save" />
            </form>
        );
    }
}

export default UsersForm;