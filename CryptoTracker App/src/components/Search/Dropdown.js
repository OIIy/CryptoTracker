import React, { useState, useEffect } from "react";
import axios from "../../api/axios";
import './Dropdown.css';

function Dropdown(props) {
    const [dropdownResults, setDropdownResults] = useState([]);

    useEffect(() => {
        if (props.data) {
            setDropdownResults(props.data);
        }
    }, [props])

    useEffect(() => {
    }, [dropdownResults])

    const getCryptoByCode = code => {
        axios.get(`/crypto?BNC2Code=${code}`).then(res => {
            console.log(res);
        })
    }

    return (
        <ul className="container">
            <li className="dropdown">
                {dropdownResults.length && dropdownResults.map((result) => (<div className="dropdown-item" onClick={() => {getCryptoByCode(result.CodeName)}}>{result.CodeDescription}</div>))}
            </li>
        </ul>
    )
}

export default Dropdown;