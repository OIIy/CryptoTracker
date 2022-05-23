import axios from '../api/axios';
import useAuth from '../context/AuthProvider';

const useRefreshToken = () => {
    const { setAuth } = useAuth();

    const refresh = async () => {
        const response = await axios.get('/refresh', {
            withCredentials: true
        })
    }

    return (
    <div>useRefreshToken</div>
    )
}

export default useRefreshToken