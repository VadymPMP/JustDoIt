import * as React from 'react';
import Note from './Note.jsx'
import NotesForm from './NotesForm.jsx'
import apiNote from './apiNote.js'

class NoteList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { notes: [] };

        this.onAddUser = this.onAddUser.bind(this);
        this.onRemoveUser = this.onRemoveUser.bind(this);
    }
    //load data
    loadData() {
        apiNote.Notes().getNote()
        .then(response => this.setState({ notes: response.data }))
        .catch(err => console.log(err));
        
    }
    componentDidMount() {
        this.loadData();
    }
    // add object
    async onAddUser(note) {
        if (note) {
            apiNote.Notes().createNote(note).then(response => this.loadData()).catch(err => console.log(err));
        }
    }
    // delete object
    onRemoveUser(note) {
        if (note) {
            apiNote.Notes().deleteNote(note.id).then(response => this.loadData()).catch(err => console.log(err));
        }
    }
    render() {

        var remove = this.onRemoveUser;
        return <div>
            <NotesForm onPhoneSubmit={this.onAddUser} />
            <h2>List of notest</h2>
            <div >
                {
                    this.state.notes.map(function (note) {

                        return <Note key={note.id} note={note} onRemove={remove} />
                    })
                }
            </div>
        </div>;
    }
}

export default NoteList;