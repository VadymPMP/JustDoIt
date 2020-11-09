import axios from "axios";

const baseUrl = "https://localhost:5001/api/";



export default {

    Notes(url = baseUrl + 'notes/') {
        return {
            getNote: () => axios.get(url),
            fetchById: id => axios.get(url + id),
            createNote: note => axios.post(url, note),
            update: (id, updateRecord) => axios.put(url + id, updateRecord),
            deleteNote: id => axios.delete(url + id)
        }
    }
}