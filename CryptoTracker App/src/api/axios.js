import axios from 'axios';
import useAuth from '../context/AuthProvider';

// const AUTH_TOKEN = 'eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3RyaW5nIiwiZXhwIjoxNjUzNDI4NTM2fQ.QplRIHiaqfun6f8A2HYOsfTCFRWJPqnGGykixka0FQcZ21YEQDHxxA0uTYZ8uaGdV5JUV7LPf0FpKhCz761MTg'
// axios.defaults.headers.common['Authorization'] = `bearer ${AUTH_TOKEN}`;

export default axios.create({
    baseURL: 'https://localhost:44393/api/'
});