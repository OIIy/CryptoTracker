import React, { useState, useEffect } from "react";

function Dropdown(props) {
    const [dropdownResults, setDropdownResults] = useState([]);

    useEffect(() => {
        setDropdownResults(props.data);
    }, [props])

    useEffect(() => {
    }, [dropdownResults])

    return (
        <div className="dropdown-container">
            {dropdownResults.length && dropdownResults.map((result) => (
                <span>{result.CodeDescription}</span>
            ))}
        </div>
    )
}

export default Dropdown;