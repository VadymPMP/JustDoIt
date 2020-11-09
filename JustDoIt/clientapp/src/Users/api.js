import axios from "axios";

const baseUrl = "https://localhost:5001/api/";



export default {

    Users(url = baseUrl + 'users/') {
        return {
            getUsers: () => axios.get(url),
            fetchById: id => axios.get(url + id),
            createUser: user => axios.post(url, user),
            update: (id, updateRecord) => axios.put(url + id, updateRecord),
            deleteUser: id => axios.delete(url + id)
        }
    }
}