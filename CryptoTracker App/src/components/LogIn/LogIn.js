import React, { useState } from 'react'
import { FaLock } from 'react-icons/fa'

function LogIn({ Login, error }) {
    const [details, setDetails] = useState({})

    const submitHandler = e => {
        e.preventDefault();
        Login(details);
    }

    return (
        <form onSubmit={submitHandler}>
            <div className='input-group'>
                <div className="input-group-prepend">
                    <span className="input-group-text" id="basic-addon1">@</span>
                </div>
                <input type="text" className="form-control" placeholder="Username" aria-label="Username" name="username" id="username"
                       onChange={e => setDetails({...details, username: e.target.value})} 
                       value={details.username}
                />
                <input type="password" className="form-control" placeholder="Password" aria-label="Password" name="password" id="password"
                       onChange={e => setDetails({...details, password: e.target.value})} 
                       value={details.password}
                />
                <button type="Submit" className="btn btn-primary">Sign In</button>
            </div>
        </form>
    )
}

export default LogIn