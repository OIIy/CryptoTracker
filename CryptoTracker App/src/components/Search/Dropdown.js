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
        <div className="dropdown container">
            <ul>
                {dropdownResults.length && dropdownResults.map((result) => (<li>{result.CodeDescription}</li>))}
            </ul>
        </div>
    )
}

export default Dropdown;