import * as React from 'react';

class NotesForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = {userId: 0, note: "" };

        this.onSubmit = this.onSubmit.bind(this);
        
        this.onSecondNameChange = this.onSecondNameChange.bind(this);
        this.onNoteChange = this.onNoteChange.bind(this);
    }

    onSecondNameChange(e) {
        this.setState({ userId: e.target.value });
    }
    onNoteChange(e) {
        this.setState({ note: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var Id = this.state.userId;
        var Note = this.state.note;
        
        if (Id <=0 || !Note ) {
            return;
        }
        this.props.onPhoneSubmit({ userId: Id, note: Note });
        this.setState({userId: 0, note: "" });
    }
    render() {
        return (
            <form onSubmit={this.onSubmit}>
                
                <p>
                    <input type="number"
                        placeholder="Id of user"
                        value={this.state.userId}
                        onChange={this.onSecondNameChange} />
                </p>
                <p>
                    <input type="text"
                        placeholder="Note"
                        value={this.state.note}
                        onChange={this.onNoteChange} />
                </p>
                <input type="submit" value="Save" />
            </form>
        );
    }
}

export default NotesForm;