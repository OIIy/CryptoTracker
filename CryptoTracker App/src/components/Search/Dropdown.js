import React, { useState, useEffect } from "react";
import './Dropdown.css';

function Dropdown(props) {
    const [dropdownResults, setDropdownResults] = useState([]);

    useEffect(() => {
        if (props.data) {
            console.log('props exist');
            setDropdownResults(props.data);
        }
    }, [props])

    useEffect(() => {
    }, [dropdownResults])

    return (
        <ul className="container">
            <li className="dropdown">
                {dropdownResults.length && dropdownResults.map((result) => (<div className="dropdown-item">{result.CodeDescription})</div>))}
            </li>
        </ul>
    )
}

export default Dropdown;