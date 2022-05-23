import axios from 'axios';
import useAuth from '../context/AuthProvider';

axios.defaults.headers.common['Authorization'] = encodeURIComponent('bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbG…hiiDkhvU5P_T0cTiP1SG8F3cj65RTlySmqSuSD6fMpx5P7nSA');

export default axios.create({
    baseURL: 'https://localhost:44393/api/'
});