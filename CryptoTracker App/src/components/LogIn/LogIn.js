import React, { useState, useRef, useEffect, useContext } from 'react'
import AuthContext from '../../context/AuthProvider';
import { FaLock } from 'react-icons/fa'
import axios from '../../api/axios'

function Login() {
    const { setAuth } = useContext(AuthContext);
    const userRef = useRef();
    const errorRef = useRef();

    const [userDetails, setUserDetails] = useState({});
    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');

    useEffect(() => {
        userRef.current.focus();
    }, []);

    useEffect(() => {
        setError('');

        if (userDetails.accessToken) {
            setAuth({...userDetails})
            console.log(userDetails);
        }
    }, [userDetails])

    const submitHandler = e => {
        e.preventDefault();
        
        LogUserIn(userDetails);
    }
    const LogUserIn = details => {
        try {
            axios.post('Auth/login', 
                {
                    ...details
                },
                {
                    headers: { withCredentials: true }
                })
            .then(res => {
                const accessToken = res?.data;
                setUserDetails({...userDetails, accessToken: accessToken})
            });
        } catch (e) {
            if (!e?.response) {
                setError('No server response')
            } else if (e.response?.status === 400) {
                setError('Missing username or password');
            } else if (e.response?.status === 401) {
                setError('Unauthorized');
            } else {
                setError('Login Failed');
            }
        }
    }

    // Todo: Add error message to DOM <p ref={errorRef} className={error ? 'error-message' : 'off-screen'} aria-live='assertive'>{error}</p> 
            
    // If Log In is successful then display username instead of log in form
    return (
        <>
            {success ? (
                <span>{userDetails.username} testing</span>

            ) : (<form onSubmit={submitHandler}>
                    <div className='input-group'>
                        <div className="input-group-prepend">
                            <span className="input-group-text" id="basic-addon1">@</span>
                        </div>
                        <input type="text" className="form-control" placeholder="Username" aria-label="Username" name="username" id="username"
                            onChange={e => setUserDetails({...userDetails, username: e.target.value})} 
                            value={userDetails.username}
                            ref={userRef}
                            autoComplete="off"
                            required
                        />
                        <input type="password" className="form-control" placeholder="Password" aria-label="Password" name="password" id="password"
                            onChange={e => setUserDetails({...userDetails, password: e.target.value})} 
                            value={userDetails.password}
                            required
                        />
                        <button type="Submit" className="btn btn-primary">Sign In</button>
                    </div>
                </form>
            )}
        </>
    )
}

export default Login;